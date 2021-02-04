using GenerateSamples.Model;

namespace GenerateSamples.Interface
{
    public interface IGSFactory
    {
        IGSModel GSModel { get; set; }

        IGSRunConfig GetRunConfig(string[] args);
    }
}