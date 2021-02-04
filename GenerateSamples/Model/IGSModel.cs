using GenerateSamples.Interface;

namespace GenerateSamples.Model
{
    public interface IGSModel
    {
        IGSRunConfig RunConfig { get; set; }
        IGSFactory GSFactory { get; set; }
    }
}