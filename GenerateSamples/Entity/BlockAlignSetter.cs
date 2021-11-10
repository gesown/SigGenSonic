using System;
using GenerateSamples.Interface;
using GenerateSamples.Model;

namespace GenerateSamples.Entity
{
    public class BlockAlignSetter : IBlockAlignSetter
    {
        public byte[] SetBlockAlign(IWaveFileHeader waveFileHeader)
        {
            // NumChannels * BitsPerSample/8 ?? (BitsPerSample * Channels) /  8 bit mono, 1 byte / 16 bit stereo, 2 bytes
            var numChannels = 1;
            var bitsPerSample =int.Parse( waveFileHeader.SampleBitLength);
            var bitsPerByte = 8;
            var ratio =  bitsPerSample / bitsPerByte;
           return BitConverter.GetBytes(ratio);
        }
    }
}