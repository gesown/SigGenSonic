using System;
using GenerateSamples.Interface;
using GenerateSamples.Model;

namespace GenerateSamples.Entity
{
    public class ByteRateSetter : IByteRateSetter
    {
        public byte[] SetByteRate(IWaveFileHeader waveFileHeader)
        {
            var sampleRate =int.Parse( waveFileHeader.SampleRateIn);
            var bitsPerSample =int.Parse( waveFileHeader.SampleBitLength);
        //    var channels = waveFileHeader.ChannelCount;
            var sizeOFByteRate = sampleRate * bitsPerSample; // *channels -> single/mono

             // (Sample Rate * BitsPerSample * Channels) / 8.
             return BitConverter.GetBytes(sizeOFByteRate);
        }
    }
}