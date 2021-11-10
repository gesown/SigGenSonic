namespace SignalGenFSK.Interface
{
    public interface IRunConfiguration
    {
        int CarrierFrequency { get; set; }
        int FrequencyDeviation { get; set; }
        int CyclesBitDuration { get; set; }
        int SignalDurationMS { get; set; }
    }
}