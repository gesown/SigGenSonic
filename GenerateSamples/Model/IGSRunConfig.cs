namespace GenerateSamples.Model
{
    public interface IGSRunConfig
    {
        int SampleFrequency { get; set; }
        int SampleCount { get; set; }
        int SampleDuration { get; set; }
        int SampleRate { get; set; }
        string FileName { get; set; }
    }
}