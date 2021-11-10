namespace SigGenSonic.Models
{
    class SignalRequest:ISignalRequest
    {
        public SignalTypeOut SignalType { get; set; }
        public int FrequencyCount { get; set; }
        public int StartFrequency { get; set; }
        public bool FreqSpaceLinear { get; set; }
        public Message Message { get; set; }
    }

    internal interface ISignalRequest
    {
        SignalTypeOut SignalType { get; set; }
        int FrequencyCount { get; set; }
        int StartFrequency { get; set; }
        bool FreqSpaceLinear { get; set; } // or log/lin--ratio between successive frequencies
        Message Message { get; set; }
    }

    internal class Message:IMessage
    {
        public SymbolTypeIn SymbolTypeIn { get; set; }
        public int SymbolCount { get; set; }
        public int CRC { get; set; }
    }

    internal interface IMessage
    {
        SymbolTypeIn SymbolTypeIn { get; set; }
        int SymbolCount { get; set; }
        int CRC { get; set; }
    }

    internal enum SymbolTypeIn
    {
        Nibble,
        Byte,
        ByteList,
        ASCII,
        UTF8,
        JSON,
        XML
    }

    internal enum SignalTypeOut
    {
        BIN ,
        WAV,
        MP4,
        Emoji,
        EmojiZWJSequence,
        Hanzi,
        ShortCode
    }
}
