﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs.Interfaces
{
    public interface IDialogBuilder
    {
        ConfirmRobotDialog BuildConfirmRobotDialog(IMessageActivity message);

        GetWeatherForecastDialog BuilGetWeatherForecastDialog(IMessageActivity message,
            IList<EntityRecommendation> result);

        RandomNumberDialog BuildRandomNumberDialog(IMessageActivity message, IList<EntityRecommendation> result);

        BasicPersonalityChatBotDialog BuildBasicPersonalityChatBotDialog(IMessageActivity message, IList<EntityRecommendation> result);



    }
}