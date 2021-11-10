using System.Collections.Generic;
using System.IO;
using GenerateSamples.Interface;

namespace GenerateSamples.Entity
{
    public class SoundSampleGetter : ISoundSampleGetter
    {
        public byte[] GetSoundSamples(string fileInName)
        {
            if (!File.Exists(fileInName))
            {
                throw new FileNotFoundException();
            }
            var rb = new List<byte>();
            var fsIn = new FileStream(fileInName, FileMode.Open,FileAccess.Read);
            BinaryReader reader = new BinaryReader(fsIn);
            using (reader)
            {
                while (fsIn.CanRead && fsIn.Position < fsIn.Length)
                {
                    rb.Add(reader.ReadByte());
                }
            }
            reader.Close();
            fsIn.Close();
            return rb.ToArray();
        }
    }
}