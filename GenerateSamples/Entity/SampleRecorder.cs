using System;
using System.Collections.Generic;
using System.IO;
using GenerateSamples.Interface;
using GenerateSamples.Model;

namespace GenerateSamples.Entity
{
    public class SampleRecorder : iSampleRecorder
    {
        private IList<short> binList = new List<short>();

        public void RecordSamples(IGSRunConfig runConfig)
        {
            var frequency = runConfig.SampleFrequency;
            var count = runConfig.SampleCount;
            var rate = runConfig.SampleRate;
            var filename = runConfig.FileName;
            var pi = Math.PI;
            var omega = 2 * pi * frequency / rate;
            if (File.Exists(filename)) File.Delete(filename);
            for (int i = 0; i < count; i++)
            {
                var sample = Math.Sin(omega * i) * (65535 - 1) / 2;
                var ss = Convert.ToInt16(sample);
                binList.Add(ss);
            }

            using BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create));
            foreach (var @ushort in binList)
            {
                writer.Write(@ushort);
            }

            writer.Close();
        }
    }

}
    
