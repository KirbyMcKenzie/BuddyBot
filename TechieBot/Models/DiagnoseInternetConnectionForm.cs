using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.FormFlow.Advanced;

namespace TechieBot.Models
{
    [Serializable]
    public class DiagnoseInternetConnectionForm
    {
        [Prompt("Has this fixed the problem?")]
        public bool ProblemResolved { get; set; }

        [Prompt("I think it's safe to assume you're having problems connecting on another device? {||}")]
        public bool CurrentDevice { get; set; }

        [Prompt("Have you tried turning it off and on? {||}")]
        public bool RestartedDevice { get; set; }

        [Prompt("Have you tried turning the router off and on recently? {||}")]
        public bool RestartedRouter { get; set; }

        public static IForm<DiagnoseInternetConnectionForm> BuildForm()
        {
            return new FormBuilder<DiagnoseInternetConnectionForm>()
                .Field(nameof(CurrentDevice))
                .Field(nameof(RestartedDevice))
                //.Message("Try resetting the device and if It doesnt work come back and we'll try something else")
                .Confirm(
                    prompt: "Has this fixed your problem? {||}",
                    condition: state => state.ProblemResolved = true)
                .Field(nameof(RestartedRouter))
                .Build();
        }
    }
}