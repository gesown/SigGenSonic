using GenerateSamples.Model;

namespace GenerateSamples.Interface
{
    public interface IMonoStereoSetter
    {
        byte[] SetMonoStereoType(MonoStereoFlag flag);
    }
}