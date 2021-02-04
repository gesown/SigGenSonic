using GenerateSamples.Interface;

namespace GenerateSamples.Model
{
    public class GSModel : IGSModel
    {
        public IGSRunConfig RunConfig { get; set; }
        public IGSFactory GSFactory { get; set; }
    }
}
