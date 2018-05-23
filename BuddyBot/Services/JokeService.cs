using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BuddyBot.Contracts;
using BuddyBot.Models.Dtos;
using Newtonsoft.Json;

namespace BuddyBot.Services
{
    public class JokeService : IJokeService
    {
        private const string Url = "https://icanhazdadjoke.com/";

        public async Task<String> GetRandomJoke()
        {
            try
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri(Url) };
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(Url);
                if (response.IsSuccessStatusCode)
                {
                    String jokeString = await response.Content.ReadAsStringAsync();

                    var jokeDto = JsonConvert.DeserializeObject<JokeDto>(jokeString);

                    return jokeDto.Joke;
                }
                return "I'm having problems computing a joke. Please try again later";
            }
            catch (Exception e)
            {
                return "I'm having problems computing a joke. Please try again later";
            }
        }
    }
}