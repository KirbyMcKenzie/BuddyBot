using Microsoft.Bot.Builder.PersonalityChat.Core;

namespace BuddyBot.Models
{
    public class PersonalityChoiceHeroCard
    {

        public PersonalityChoiceHeroCard(PersonalityChatPersona personalityType, string title, string subtitle, string  imageUrl)
        {
            personalityType = PersonalityType;
            title = Title;
            subtitle = Subtitle;
            imageUrl = ImageUrl;
        }

        public PersonalityChatPersona PersonalityType { get; set; }
        public string Title{ get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
    }
}