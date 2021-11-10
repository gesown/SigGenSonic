using System;
using System.Text;
using GenerateSamples.Interface;
using GenerateSamples.Model;

namespace GenerateSamples.Entity
{
    public class MonoStereoSetter : IMonoStereoSetter
    {
        public byte[] SetMonoStereoType(MonoStereoFlag flag)
        {
            int formatInt = (int) flag;
            return Encoding.ASCII.GetBytes(formatInt.ToString());
        }
    }
}