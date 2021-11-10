using System;
using System.Collections.Generic;
using System.IO;
using GenerateSamples.Interface;
using GenerateSamples.Model;

namespace GenerateSamples.Entity
{
    public class SampleRecorder : iSampleRecorder
    {
        private IList<Int32> binList32 = new List<int>();

        public void RecordSamples(IGSRunConfig runConfig)
        {
            var ScaleFactor = runConfig.ScaleFactor;
            var scaler = ScaleFactor == 16 ? Int16.MaxValue : Int32.MaxValue;
            var frequency = runConfig.SampleFrequency;
            var count = runConfig.SampleCount;
            var rate = runConfig.SampleRate;
            var filenamebin = runConfig.FileName+"_"+frequency+".bin";
            var filenametxt = runConfig.FileName + "_" + frequency + ".txt";
            var pi = Math.PI;
            var omega = 2 * pi * frequency / rate;
            if (File.Exists(filenamebin)) File.Delete(filenamebin);
            if (File.Exists(filenametxt)) File.Delete(filenametxt);
            for (int i = 0; i < count; i++)
            {
                var sample = Math.Sin(omega * i) * (scaler - 1) ;

                var ss =ScaleFactor==16? Convert.ToInt16(sample):Convert.ToInt32(sample);
                binList32.Add(ss);
            }

            using BinaryWriter writer = new BinaryWriter(File.Open(filenamebin, FileMode.Create));
            foreach (var @ushort in binList32)
            {
                writer.Write(@ushort);
            }
            writer.Close();

            TextWriter tw = new StreamWriter(filenametxt, false);
            foreach (var i in binList32)
            {
                tw.WriteLine(i);
            }
            tw.Close();
        }
    }

}
    
