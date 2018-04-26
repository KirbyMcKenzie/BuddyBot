using Microsoft.Bot.Builder.FormFlow;
using System;
using Microsoft.Bot.Builder.FormFlow.Advanced;
using TechieBot.Models.Enums;

namespace TechieBot.Models
{
    [Serializable]
    [Template(TemplateUsage.NotUnderstood,
        "I'm sorry I don't understand what you mean by \"{0}\". " +
        "Please be more specific or type \"help\" to get more info.")]
    public class DiagnoseInternetConnectionForm
    {
        [Prompt("Has this fixed the problem? {||}")]
        public bool ProblemResolved { get; set; }

        [Prompt("I think it's safe to assume you're having problems connecting on another device? {||}")]
        public bool CurrentDevice { get; set; }

        [Prompt("What {&} is your device running? {||}")]
        public OperatingSystems OperatingSystem { get; set; }

        [Prompt("Have you tried turning it off and on? {||}")]
        public bool RestartedDevice { get; set; }

        [Prompt("Have you tried turning the router off and on recently? {||}")]
        public bool RestartedRouter { get; set; }

        public static IForm<DiagnoseInternetConnectionForm> BuildForm()
        {
            return new FormBuilder<DiagnoseInternetConnectionForm>()
                .Field(nameof(CurrentDevice))
                .Field(nameof(OperatingSystem))
                .Field(nameof(RestartedDevice))
                //.Message("Try resetting the device and if It doesnt work come back and we'll try something else")
                .Field(nameof(ProblemResolved))
                .Field(new FieldReflector<DiagnoseInternetConnectionForm>(nameof(RestartedRouter))
                    .SetType(typeof(bool))
                    .SetActive((state) => state.ProblemResolved == false))
                .Build();
        }
    }
}