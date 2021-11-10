using SignalGenFSK.Interface;

namespace SignalGenFSK.Model
{
    internal interface ISGFSKModel
    {
        IRunConfiguration RunConfiguration { get;  }
}
}