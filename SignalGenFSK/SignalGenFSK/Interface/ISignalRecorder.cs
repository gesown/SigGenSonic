using System.Collections.Generic;
using SignalGenFSK.Model;

namespace SignalGenFSK.Interface
{
    public interface ISignalRecorder
    {
        IList<SignalTime> RecordSignal(IRunConfiguration runConfiguration);
    }
}