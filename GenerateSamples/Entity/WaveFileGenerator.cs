using System.Collections.Generic;
using System.IO;
using System.Linq;
using GenerateSamples.Facade;
using GenerateSamples.Interface;

namespace GenerateSamples.Entity
{
    public class WaveFileGenerator : IWaveFileGenerator
    {

        public void MakeWaveFile(string[] args)
        {
            var wfh=  GSFacade.MakeWaveFileHeader(args);
            var wfhFilled = GSFacade.FillHeader(wfh);
            FileInName = args[0];
            FileOutName = FileInName + ".wav";
            if (File.Exists(FileOutName))
            {
                File.Delete(FileOutName);
            }
            IList<byte> sampledata = new List<byte>();
            FileStream fsIn = new FileStream(FileInName, FileMode.Open);
            FileStream fsOut = new FileStream(FileOutName, FileMode.Create);
            BinaryReader reader = new BinaryReader(fsIn);
            using (reader)
            {
                while (fsIn.CanRead&&fsIn.Position<fsIn.Length)
                {
                    sampledata.Add(reader.ReadByte());
                }
            }

            BinaryWriter writer = new BinaryWriter(fsOut);
            using (writer)
            {
                writer.Write(wfhFilled.Header);
                writer.Write(sampledata.ToArray());
            }
        }

        public string FileInName { get; set; }

        public string FileOutName { get; set; }

        IList<byte[]> IWaveFileGenerator.SampleData { get; set; }
        public int SampleDataLength { get; set; }
        public int HeaderSampleLengthPosition { get; set; }
    }
}