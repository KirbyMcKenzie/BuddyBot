using System.Threading.Tasks;

namespace BuddyBot.Services.Contracts
{
    public interface IHeadTailsService
    {
        Task<string> GetRandomHeadsTails();
    }
}