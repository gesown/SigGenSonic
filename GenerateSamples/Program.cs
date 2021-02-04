using System;
using GenerateSamples.Facade;
using GenerateSamples.Model;

namespace GenerateSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: GenerateSamples {fileOut}{SampleFrequency (Hz)}{SampleDuration (ms)}{SampleRate optional -- defaults to 44100 }");
                return;
            }
            IGSRunConfig runConfig = GSFacade.SetRunConfig(args);
            GSFacade.RecordSamples(runConfig);
        }
    }
}
