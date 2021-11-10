using GenerateSamples.Model;

namespace GenerateSamples.Interface
{
    public interface IByteRateSetter
    {
        byte[] SetByteRate(IWaveFileHeader waveFileHeader);
    }
}