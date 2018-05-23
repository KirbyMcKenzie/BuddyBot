using System.Threading.Tasks;

namespace BuddyBot.Contracts
{
    public interface IHeadTailsService
    {
        Task<string> GetRandomHeadsTails();
    }
}