using System.Threading.Tasks;
using Orleans;
using System.Collections.Generic;

namespace GrainInterfaces
{
    /// <summary>
    /// Grain interface IMyGrain1
    /// </summary>
    public interface IManager : IGrainWithGuidKey
    {
        Task<IEmployee> AsEmployee();
        Task<List<IEmployee>> GetDirectReports();
        Task AddDirectReport(IEmployee employee);
    }
}
