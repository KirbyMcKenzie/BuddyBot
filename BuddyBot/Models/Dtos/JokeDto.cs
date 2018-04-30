using System;

namespace BuddyBot.Models.Dtos
{
    [Serializable]
    public class JokeDto
    {
        public string Id { get; set; }
        public string Joke { get; set; }
        public int Status { get; set; }
    }