using GenerateSamples.Entity;
using GenerateSamples.Factory;
using GenerateSamples.Interface;
using GenerateSamples.Model;

namespace GenerateSamples.Facade
{
    public static class GSFacade
    {
        public static IGSRunConfig SetRunConfig(string[] args)
        {
            IGSFactory factory = new GSFacatory();
            return factory.GetRunConfig(args);
        }

        public static void RecordSamples(IGSRunConfig runConfig)
        {
            iSampleRecorder sr = new SampleRecorder();
             sr.RecordSamples(runConfig);
        }
    }
}
