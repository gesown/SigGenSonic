using System;
using System.Globalization;

namespace GenerateSamples.Model
{
    class GSRunConfig: IGSRunConfig
    {
        public GSRunConfig(string[] args)
        {
            FileName = args[0];
            SampleFrequency = int.Parse(args[1]); // Hz
            SampleDuration = int.Parse(args[2]); // ms
            SampleRate =args.Length<4? 44100:int.Parse(args[3]);
            SampleCount =int.Parse(( Convert.ToDouble( SampleDuration) /1000.0 * SampleRate).ToString(CultureInfo.InvariantCulture));

        }

        public int SampleFrequency { get; set; }
        public int SampleCount { get; set; }
        public int SampleDuration { get; set; }
        public int SampleRate { get; set; }
        public string FileName { get; set; }
    }
}
