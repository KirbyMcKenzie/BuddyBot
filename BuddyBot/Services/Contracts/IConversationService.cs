using System.Threading.Tasks;

namespace BuddyBot.Services.Contracts
{
    public interface IConversationService
    {
        Task<string> GetGreeting();

        Task<string> GetPoliteExpression();

        Task<string> GetHowsItPrompt();

        Task<string> GetHowsItResultGood();

        Task<string> GetHowsItResultBad();

    }
}