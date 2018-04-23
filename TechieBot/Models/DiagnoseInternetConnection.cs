using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechieBot.Models
{
    [Serializable]
    public class DiagnoseInternetConnection
    {
        public bool? CurrentDevice { get; set; }
        public bool? RestartedDevice { get; set; }
        public bool? RestartedRouter { get; set; }

        public static IForm<DiagnoseInternetConnection> BuildForm()
        {
            return new FormBuilder<DiagnoseInternetConnection>()
                .Message("Please answer the following questions & I'll do my best to help you")
                .Build();
        }
    }
}