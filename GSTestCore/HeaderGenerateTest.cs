using System;
using System.IO;
using GenerateSamples.Facade;
using GenerateSamples.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GSTestCore
{
    [TestClass]
    public class HeaderGenerateTest
    {
        [TestMethod]
        public void TestMakeHeader()
        {
            // sam100_32_def.bin 1000 10000  32  44100
            var fileOut = "HeaderOut.bin";
            var args = new string[] { "C:\\src\\GSTestCore\\bin\\Debug\\netcoreapp3.1\\sam100_32_def.bin", "1000", "10000", "32" };
            
            if (!File.Exists(args[0]))
            {
                throw new FileNotFoundException();
            }
           var header = (WaveFileHeader)GSFacade.MakeWaveFileHeader(args);
           var filledHeader = GSFacade.FillHeader(header);
            if (File.Exists(fileOut))
            {
                File.Delete(fileOut);
            }
            FileStream fs = new FileStream(fileOut, FileMode.Create);
            
            BinaryWriter writer = new BinaryWriter(fs);

            writer.Write(filledHeader.Header, 0, filledHeader.Header.Length);
            writer.Close();
            fs.Close();
            //  Assert.AreEqual(null,filledHeader);

        }
    }
}
