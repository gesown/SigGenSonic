using GenerateSamples.Model;

namespace GenerateSamples.Interface
{
    public interface IHeaderArrayFiller
    {
        IWaveFileHeader FillHeader(IWaveFileHeader waveFileHeader);

    }
}