using System.Text;
using GenerateSamples.Interface;
using GenerateSamples.Model;

namespace GenerateSamples.Entity
{
    public class ChannelCountMonoSetter : IChannelCountMonoSetter
    {
        public byte[] SetChannelCountMono()
        {
            return Encoding.ASCII.GetBytes(MonoStereoFlag.Mono.ToString());
        }
    }
}