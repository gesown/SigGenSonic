using GenerateSamples.Interface;
using System.Text;

namespace GenerateSamples.Entity
{
    public class FMTSubChunkMarker : IFMTSubChunkMarker
    {
        public byte[] SetFMTChunk1Marker()
        {
            return Encoding.ASCII.GetBytes("fmt");
        }
    }
}