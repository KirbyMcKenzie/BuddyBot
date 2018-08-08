using System.Threading.Tasks;

namespace BuddyBot.Services.Contracts
{
    public interface IConversationService
    {
        Task<string> GetGreeting(string name = null);

        Task<string> GetPoliteExpression();

        Task<string> GetHowsItPrompt();

        Task<string> GetHowsItResultGood();

        Task<string> GetHowsItResultBad();

    }
}