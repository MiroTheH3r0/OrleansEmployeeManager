using System.Threading.Tasks;
using Orleans;

namespace GrainInterfaces
{
    /// <summary>
    /// Grain interface IStockGrain
    /// </summary>
    public interface IStockGrain : IGrainWithStringKey
    {
        Task<string> GetPrice();
    }
}
