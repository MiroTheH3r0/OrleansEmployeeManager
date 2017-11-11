using System;
using GrainInterfaces;
using System.Threading;
using Orleans;
using Orleans.Runtime.Configuration;
using Orleans.Runtime.Host;
using Orleans.Runtime;

namespace Client
{
    /// <summary>
    /// Orleans test silo host
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Client";

            // Then configure and connect a client.
            var clientConfig = ClientConfiguration.LoadFromFile("ClientConfiguration.xml");

            while (true)
            {
                try
                {
                    GrainClient.Initialize(clientConfig);
                    Console.WriteLine("Connected to silo!");

                    /*
                    var grainFactory = GrainClient.GrainFactory;
                    var e0 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
                    var e1 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
                    var e2 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
                    var e3 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
                    var e4 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());

                    var m0 = grainFactory.GetGrain<IManager>(Guid.NewGuid());
                    var m1 = grainFactory.GetGrain<IManager>(Guid.NewGuid());
                    var m0e = m0.AsEmployee().Result;
                    var m1e = m1.AsEmployee().Result;

                    m0e.SetName("Mirek Dziuba");
                    m1e.SetName("Bartek Dziuba");
                    m0e.Promote(10);
                    m1e.Promote(11);

                    m0.AddDirectReport(e0).Wait();
                    m0.AddDirectReport(e1).Wait();
                    m0.AddDirectReport(e2).Wait();

                    m1.AddDirectReport(m0e).Wait();
                    m1.AddDirectReport(e3).Wait();

                    m1.AddDirectReport(e4).Wait();
                    */

                    var grain = GrainClient.GrainFactory.GetGrain<IStockGrain>("MSFT");
                    var price = grain.GetPrice().Result;
                    Console.WriteLine(price);

                    Console.ReadLine();
                    break;
                }
                catch (SiloUnavailableException)
                {
                    Console.WriteLine("Silo not available! Retrying in 3 seconds.");
                    Thread.Sleep(3000);
                }
            }
        }
    }
}
