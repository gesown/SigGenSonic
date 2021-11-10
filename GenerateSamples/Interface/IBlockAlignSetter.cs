using GenerateSamples.Model;

namespace GenerateSamples.Interface
{
    public interface IBlockAlignSetter
    {
        byte[] SetBlockAlign(IWaveFileHeader waveFileHeader);
    }
}