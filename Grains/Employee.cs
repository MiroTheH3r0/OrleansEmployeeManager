using System.Threading.Tasks;
using Orleans;
using GrainInterfaces;
using System;
using System.Threading;
using Orleans.Concurrency;

namespace Grains
{
    /// <summary>
    /// Grain implementation class Grain1.
    /// </summary>
    [Reentrant]
    public class Employee : Grain, IEmployee
    {
        private int _level;
        private IManager _manager;
        private string _name;

        public Task<int> GetLevel()
        {
            return Task.FromResult(_level);
        }

        public Task Promote(int newLevel)
        {
            _level = newLevel;
            return Task.CompletedTask;
        }

        public Task<IManager> GetManager()
        {
            return Task.FromResult(_manager);
        }

        public Task SetManager(IManager manager)
        {
            _manager = manager;
            return Task.CompletedTask;
        }

        public async Task Greeting(GreetingData data)
        {
            //Console.WriteLine("{0} said: {1}", from.GetPrimaryKey().ToString(), message);
            //Console.WriteLine("{0} said: {1}", await from.GetName(), message);
            //return Task.CompletedTask;
            Console.WriteLine("{0} said: {1}", data.From, data.Message);
            if (data.Count >= 3)
            {
                return;
            }

            var fromGrain = GrainFactory.GetGrain<IEmployee>(data.From);
            await fromGrain.Greeting(new GreetingData
            {
                From = this.GetPrimaryKey(),
                Message = "Thanks!",
                Count = data.Count + 1
            });
        }

        public Task SetName(string name)
        {
            _name = name;
            return Task.CompletedTask;
        }

        public Task<string> GetName()
        {
            return Task.FromResult(_name);
        }
    }
}
