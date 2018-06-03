using BuddyBot.Contracts;
using BuddyBot.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BuddyBot.Dialogs
{
    public class GetForecastDialog : IDialog<string>
    {
        private readonly IList<EntityRecommendation> _entities;

        public GetForecastDialog(IList<EntityRecommendation> entities)
        {
            _entities = entities;
        }


        public async Task StartAsync(IDialogContext context)
        {
            await Respond(context);
        }

        public async Task Respond(IDialogContext context)
        {
            IWeatherService weatherService = new WeatherService();

            var weatherResult = await weatherService.GetWeatherByLocationId(_entities);

            context.Done(weatherResult);
        }
    }
}