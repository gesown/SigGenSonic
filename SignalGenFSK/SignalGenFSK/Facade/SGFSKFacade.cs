using System.Collections.Generic;
using System.Linq;
using SignalGenFSK.Entity;
using SignalGenFSK.Interface;
using SignalGenFSK.Model;

namespace SignalGenFSK.Facade
{
    public static class SGFSKFacade
    {
        public static IRunConfiguration SetRunConfiguration(MainWindow mainWindow)
        {
            return new RunConFiguration(mainWindow);
        }

        public static IList<SignalTime> RecordSignal(IRunConfiguration runConfiguration)
        {
            ISignalRecorder sr = new SignalRecorder();
            return sr.RecordSignal(runConfiguration);
        }

        public static IList<SignalTime> GenerateSamples(double frequency, int cycleCount)
        {
            ISampleGenerator sg = new SampleGenerator();
            return sg.GenerateSamples(frequency, cycleCount);
        }

        public static IList<SignalTime> ConcatLists(IList<SignalTime> listOne, IList<SignalTime> listTwo)
        {
            return listOne.Concat(listTwo).ToList();
        }
    }
}
