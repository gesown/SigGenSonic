using System;
using GenerateSamples.Facade;
using GenerateSamples.Model;

namespace GenerateSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Usage: GenerateSamples {fileOut}{SampleFrequency (Hz)}{SampleDuration (ms)}{Sample Size - 16/32}{SampleRate optional -- defaults to 44100 }");
                return;
            }
            IGSRunConfig runConfig = GSFacade.SetRunConfig(args);
            GSFacade.RecordSamples(runConfig);
            for (int i = 0; i < 20; i++)
            {
                runConfig.SampleFrequency = runConfig.SampleFrequency + 100;
                GSFacade.RecordSamples(runConfig);
            }
        }
    }
}
