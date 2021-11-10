using System.Text;
using GenerateSamples.Interface;

namespace GenerateSamples.Entity
{
    public class DataChunkHeaderSetter : IDataChunkHeaderSetter
    {
        public byte[] SetDataChunkHeader()
        {
            return Encoding.ASCII.GetBytes("data");
        }
    }
}