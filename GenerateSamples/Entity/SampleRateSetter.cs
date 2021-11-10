using System;
using System.Text;
using GenerateSamples.Interface;

namespace GenerateSamples.Entity
{
    public class SampleRateSetter : ISampleRateSetter
    {
        public byte[] SetSampleRate(string sampleRateIn)
        {
            return BitConverter.GetBytes(int.Parse(sampleRateIn));
        }
    }
}