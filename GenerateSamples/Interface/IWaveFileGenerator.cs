using System.Collections.Generic;

namespace GenerateSamples.Interface
{
    public interface IWaveFileGenerator
    {
        void MakeWaveFile(string[] args);
        string FileInName { get; set; }
        string FileOutName { get; set; }
      IList<  byte[] >SampleData { get; set; }
      int SampleDataLength { get; set; } // measured -- written to 40
      int HeaderSampleLengthPosition { get; set; } // 40
    }
}