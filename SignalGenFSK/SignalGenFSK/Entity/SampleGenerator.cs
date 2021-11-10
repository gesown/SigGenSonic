using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using SignalGenFSK.Interface;
using SignalGenFSK.Model;

namespace SignalGenFSK.Entity
{
    public class SampleGenerator : ISampleGenerator
    {
        public IList<SignalTime> GenerateSamples(double frequency, int cycleCount)
        {
            var retValue = new List<SignalTime>();
            var pi = Math.PI;
            var fullCycleRad = 2 * pi;
            var cycleFraction = fullCycleRad / 16;  // 16 samples per cycle
            var freqPeriod = 1.0d / frequency;
            var sampleCount = 500*cycleCount; // 500 samples per cycles sampled
            for (int i = 0; i < sampleCount; i++)
            {
                var arg = i * cycleFraction;
                var cycleTime = i * freqPeriod;
                var sample =new SignalTime( Math.Sin( arg),cycleTime);
                retValue.Add(sample);
            }

            var fileName = frequency + cycleCount.ToString() + ".txt";
            if (File.Exists(fileName)) { File.Delete(fileName);}
            foreach (var signalTime in retValue)
            {
                File.AppendAllText(fileName, signalTime.SignalLevel+"\t"+signalTime.SignalWhen+"\n\r");
            }
            return retValue;
        }
    }
}