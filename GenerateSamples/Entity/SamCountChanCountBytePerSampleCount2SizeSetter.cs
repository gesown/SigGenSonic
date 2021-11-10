using System;
using GenerateSamples.Interface;
using GenerateSamples.Model;

namespace GenerateSamples.Entity
{
    public class SamCountChanCountBytePerSampleCount2SizeSetter : ISamCountChanCountBytePerSampleCount2SizeSetter
    {
        public byte[] SetSamCountChanCountBytePerSampleSize(IWaveFileHeader waveFileHeader)
        {
            var numSamples = waveFileHeader.SoundSamples.Length;
            var numChannels = BitConverter.ToInt32(waveFileHeader.ChannelCount,0);
            var bitsPerSample = BitConverter.ToInt32( waveFileHeader.BitsPerSample,0);
            var sc2s = numSamples * numChannels * bitsPerSample / 8;
            return BitConverter.GetBytes(sc2s);
        }
    }
}