using System.Threading.Tasks;
using BuddyBot.Models.Enums;

namespace BuddyBot.Services.Contracts
{
    public interface IConversationService
    {
        Task<string> GetGreeting(string name = null);

        Task<string> GetResponseByIntentName(string intentName, PersonalityChatPersona persona);
    }
}