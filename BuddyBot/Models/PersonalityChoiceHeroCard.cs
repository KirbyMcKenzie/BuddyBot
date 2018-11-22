using Microsoft.Bot.Builder.PersonalityChat.Core;

namespace BuddyBot.Models
{
    public class PersonalityChoiceHeroCard
    {
        public PersonalityChatPersona PersonalityType { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }

        public PersonalityChoiceHeroCard(PersonalityChatPersona personalityType, string title, string subtitle, string  imageUrl)
        {
            PersonalityType = personalityType;
            Title = title;
            Subtitle = subtitle;
            ImageUrl = imageUrl;
        }

        
    }
}