using System.Threading.Tasks;
using Orleans;
using GrainInterfaces1;
using System;

namespace Grains1
{
    public interface ISvc
    {
        void DoWork();
    }

    public class Svc : ISvc
    {
        public void DoWork()
        {
        }
    }
    /// <summary>
    /// Grain implementation class Grain1.
    /// </summary>
    public class Grain1 : Grain, IGrain1
    {
        private readonly ISvc _svc;

        public Grain1(ISvc svc)
        {
            _svc = svc;
        }
        public Task<string> SayHello()
        {
            var logger = GetLogger();
            logger.TrackEvent("test");
            return Task.FromResult("Hell yeahhh!!!!!");
        }
    }
}
