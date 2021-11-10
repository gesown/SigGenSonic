namespace SignalGenFSK.Model
{
    public class SignalTime: ISignalTime
    {
        public SignalTime(double sin, double i)
        {
            SignalLevel = sin;
            SignalWhen = i;
        }

        public double SignalLevel { get; set; }
        public double SignalWhen { get; set; }
    }
}
