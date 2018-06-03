using BuddyBot.Contracts;
using BuddyBot.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Models;

namespace BuddyBot.Dialogs
{
    public class GetWeatherForecastDialog : IDialog<string>
    {
        private readonly IList<EntityRecommendation> _entities;

        public GetWeatherForecastDialog(IList<EntityRecommendation> entities)
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

            var cities = weatherService.GetCitiesFromEntityResults(_entities);

            IList<City> cityInformation = weatherService.GetDetailedCityInformation(cities);


           // var weatherResult = await weatherService.GetWeatherByLocationId(_entities);
           // Return weather result
            context.Done(cityInformation[1].ToString());
        }
    }
}