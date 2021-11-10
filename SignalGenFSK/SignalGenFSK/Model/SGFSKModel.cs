using SignalGenFSK.Interface;

namespace SignalGenFSK.Model
{
    class SGFSKModel: ISGFSKModel
    {
        public string FileOutName { get; set; }
        public IRunConfiguration RunConfiguration { get; set; }
    }
}
