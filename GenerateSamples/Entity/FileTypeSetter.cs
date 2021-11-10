using System.Text;
using GenerateSamples.Interface;

namespace GenerateSamples.Entity
{
    public class FileTypeSetter : IFileTypeSetter
    {
        public byte[] SetFileType()
        {
            var fileType = "RIFF";
            return Encoding.ASCII.GetBytes((fileType));
        }
    }
}