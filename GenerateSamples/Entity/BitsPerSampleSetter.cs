using System;
using System.Text;
using GenerateSamples.Interface;

namespace GenerateSamples.Entity
{
    public class BitsPerSampleSetter : IBitsPerSampleSetter
    {
        public byte[] SetBitsPerSample(string sampleBitLength)
        {
            var iBits = int.Parse(sampleBitLength);
            return BitConverter.GetBytes(iBits);
        }
    }
}