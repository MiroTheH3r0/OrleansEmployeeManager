using System.Threading.Tasks;
using Orleans;

namespace GrainInterfaces
{
    /// <summary>
    /// Grain interface IGrain1
    /// </summary>
    public interface IEmployee : IGrainWithGuidKey
    {
        Task<int> GetLevel();
        Task Promote(int newLevel);
        Task SetName(string name);
        Task<string> GetName();
        Task<IManager> GetManager();
        Task SetManager(IManager manager);
        Task Greeting(IEmployee from, string message);
    }
}
