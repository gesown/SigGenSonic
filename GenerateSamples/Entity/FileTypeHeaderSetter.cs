using System.Text;
using GenerateSamples.Interface;

namespace GenerateSamples.Entity
{
    public class FileTypeHeaderSetter : IFileTypeHeaderSetter
    {
        public byte[] SetFileTypeHeader()
        {
            return Encoding.ASCII.GetBytes("WAVE");
        }
    }
}