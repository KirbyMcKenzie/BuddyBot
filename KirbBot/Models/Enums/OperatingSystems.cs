using System;
using Microsoft.Bot.Builder.FormFlow;

namespace KirbBot.Models.Enums
{
    [Serializable]
    public enum OperatingSystems
    {
        Android,

        [Describe("iOS")]
        [Terms("iOS", "i OS", "iPhone", "i phone")]
        iOS,

        [Describe("MacOS")]
        [Terms("MacOS", "Mac OS", "OS X", "OSX", "Mac OS X", "Mac OSX")]
        MacOS,

        [Terms("PC", "Microsoft", "Window", "Windows 7", "Windows 8", "Windows 10")]
        Windows
    }
}