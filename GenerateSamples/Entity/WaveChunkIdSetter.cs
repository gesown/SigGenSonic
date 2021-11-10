using System.Text;
using GenerateSamples.Interface;

namespace GenerateSamples.Entity
{
    public class WaveChunkIdSetter : IWaveChunkIdSetter
    {
        public byte[] SetWaveChunkId()
        {
            return Encoding.ASCII.GetBytes("WAVE");
        }
    }
}