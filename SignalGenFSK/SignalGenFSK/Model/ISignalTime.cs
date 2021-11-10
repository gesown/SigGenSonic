namespace SignalGenFSK.Model
{
    internal interface ISignalTime
    {
        double SignalLevel { get; set; }
        double SignalWhen { get; set; }
    }
}