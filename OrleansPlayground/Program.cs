using System;
using System.Threading.Tasks;

using Orleans;
using Orleans.Runtime.Configuration;
using GrainInterfaces1;

namespace OrleansPlayground
{
    /// <summary>
    /// Orleans test silo host
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // The Orleans silo environment is initialized in its own app domain in order to more
            // closely emulate the distributed situation, when the client and the server cannot
            // pass data via shared memory.
            //AppDomain hostDomain = AppDomain.CreateDomain("OrleansHost", null, new AppDomainSetup
            //{
            //    AppDomainInitializer = InitSilo,
            //    AppDomainInitializerArguments = args,
            //});

            // TODO: once the previous call returns, the silo is up and running.
            //       This is the place your custom logic, for example calling client logic
            //       or initializing an HTTP front end for accepting incoming requests.

            Console.WriteLine("Orleans Silo is running.\nPress Enter to terminate...");
            Console.ReadLine();

            var config = ClientConfiguration.StandardLoad();
            
            GrainClient.Initialize(config);

            var grain = GrainClient.GrainFactory.GetGrain<IGrain1>(Guid.NewGuid());

            var result = grain.SayHello().Result;
            Console.WriteLine($"\n\n{result}\n\n");


            Console.WriteLine("Orleans Silo is running.\nPress Enter to terminate...");
            Console.ReadLine();

           


            //hostDomain.DoCallBack(ShutdownSilo);
        }
    }
}
