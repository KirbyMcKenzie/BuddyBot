using System.Threading.Tasks;

namespace BuddyBot.Services.Contracts
{
    public interface IConversationService
    {
        Task<string> GetGreeting(string name = null);

    }
}