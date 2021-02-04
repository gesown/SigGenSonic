using GenerateSamples.Interface;
using GenerateSamples.Model;

namespace GenerateSamples.Factory
{
    public class GSFacatory : IGSFactory
    {
        public IGSModel GSModel { get; set; }
        public IGSRunConfig GetRunConfig(string[] args)
        {
            return new GSRunConfig(args);
        }
    }
}
