using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Web;
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

    [Serializable]
    public class JokeDto
    {
        public string Id { get; set; }
        public string Joke { get; set; }
        public int Status { get; set; }
    }
}