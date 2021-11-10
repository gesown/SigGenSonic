using SignalGenFSK.Interface;
using SignalGenFSK.Model;

namespace SignalGenFSK.Entity
{
    public class RunConFiguration : IRunConfiguration
    {
        public RunConFiguration(MainWindow mainWindow)
        {
            CarrierFrequency = mainWindow.CarrierFrequency;
            FrequencyDeviation = mainWindow.FrequencyDeviation;
            SignalDurationMS = mainWindow.Duration;
        }

        public int CarrierFrequency { get; set; }
        public int FrequencyDeviation { get; set; }
        public int CyclesBitDuration { get; set; }
        public int SignalDurationMS { get; set; }
    }
}