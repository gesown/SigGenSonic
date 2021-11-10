using System.Collections.Generic;
using SignalGenFSK.Model;

namespace SignalGenFSK.Interface
{
    public interface ISampleGenerator
    {
        IList<SignalTime> GenerateSamples(double frequency, int cycleCount);
    }
}