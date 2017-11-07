using System.Threading.Tasks;
using Orleans;
using GrainInterfaces;
using System.Collections.Generic;

namespace Grains
{
    public class Manager : Grain, IManager
    {
        private IEmployee _me;
        private List<IEmployee> _reports = new List<IEmployee>();

        public override Task OnActivateAsync()
        {
            _me = this.GrainFactory.GetGrain<IEmployee>(this.GetPrimaryKey());
            return base.OnActivateAsync();
        }

        public Task<List<IEmployee>> GetDirectReports()
        {
            return Task.FromResult(_reports);
        }

        public async Task AddDirectReport(IEmployee employee)
        {
            _reports.Add(employee);
            await employee.SetManager(this);
            await employee.Greeting(_me, "Welcome to my team!");
            //return Task.CompletedTask;
        }

        public Task<IEmployee> AsEmployee()
        {
            return Task.FromResult(_me);
        }

    }
}
