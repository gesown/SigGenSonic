using GenerateSamples.Interface;

namespace GenerateSamples.Entity
{
    public class FileSizeSetter : IFileSizeSetter
    {
        public byte[] SetFileSize(int soundSamplesLength)
        {
            return new byte[soundSamplesLength+44]; // add header size
        }
    }
}