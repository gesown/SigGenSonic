using System;
using GenerateSamples.Interface;

namespace GenerateSamples.Entity
{
    public class FmtDataLengthSetter : IFmtDataLengthSetter
    {
        public byte[] SetFmtDataLength()
        {
            int dLen = 16; // PCM
            return BitConverter.GetBytes(dLen); // PCM
        }
    }
}