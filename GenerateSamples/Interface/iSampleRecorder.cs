using GenerateSamples.Model;

namespace GenerateSamples.Interface
{
    public interface iSampleRecorder
    {
        void RecordSamples(IGSRunConfig runConfig);
    }
}