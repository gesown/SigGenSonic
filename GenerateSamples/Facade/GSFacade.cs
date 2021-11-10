using GenerateSamples.Entity;
using GenerateSamples.Factory;
using GenerateSamples.Interface;
using GenerateSamples.Model;

namespace GenerateSamples.Facade
{
    public static class GSFacade
    {
        public static IGSRunConfig SetRunConfig(string[] args)
        {
            IGSFactory factory = new GSFacatory();
            return factory.GetRunConfig(args);
        }

        public static void RecordSamples(IGSRunConfig runConfig)
        {
            iSampleRecorder sr = new SampleRecorder();
            sr.RecordSamples(runConfig);
        }

        public static void MakeWavFile(string[] args)
        {
            IWaveFileGenerator wfg = new WaveFileGenerator();
            wfg.MakeWaveFile(args);
        }

        public static IWaveFileHeader MakeWaveFileHeader(string[] args)
        {
            IWaveFileHeader wfh = new WaveFileHeader(args);
            return wfh;//.FillHeader(wfh);
        }

        public static IWaveFileHeader FillHeader(IWaveFileHeader waveFileHeader)
        {
            IHeaderArrayFiller haf = new HeaderArrayFiller();
            return haf.FillHeader(waveFileHeader);
        }

        public static byte[] SetSamCountChanCountBytePerSampleSize(IWaveFileHeader waveFileHeader)
        {
            ISamCountChanCountBytePerSampleCount2SizeSetter ssg = new SamCountChanCountBytePerSampleCount2SizeSetter();
            return ssg.SetSamCountChanCountBytePerSampleSize(waveFileHeader);
        }

        public static byte[] GetSoundSamples(string fileInName)
        {
            ISoundSampleGetter ssg = new SoundSampleGetter();
            return ssg.GetSoundSamples(fileInName);
        }

        public static byte[] SetFileType()
        {
            IFileTypeSetter fts = new FileTypeSetter();
            return fts.SetFileType();
        }

        public static byte[] SetFileSize(int soundSamplesLength)
        {
            IFileSizeSetter fss = new FileSizeSetter();
            return fss.SetFileSize(soundSamplesLength);
        }

        public static byte[] SetFileTypeHeader()
        {
            IFileTypeHeaderSetter sfth = new FileTypeHeaderSetter();
            return sfth.SetFileTypeHeader();
        }

        public static byte[] SetFormatType(MonoStereoFlag monoStereoFlag)
        {
            IMonoStereoSetter fts = new MonoStereoSetter();
            return fts.SetMonoStereoType(monoStereoFlag);
        }

        public static byte[] SetChannelCountMono()
        {
            IChannelCountMonoSetter ccms = new ChannelCountMonoSetter();
            return ccms.SetChannelCountMono();
        }

        public static byte[] SetSampleRate(string sampleRateIn)
        {
            ISampleRateSetter srr = new SampleRateSetter();
            return srr.SetSampleRate(sampleRateIn);
        }

        public static byte[] SetBitsPerSample(string sampleBitLength)
        {
            IBitsPerSampleSetter bpss = new BitsPerSampleSetter();
            return bpss.SetBitsPerSample(sampleBitLength);
        }

        public static byte[] SetDataChunkHeader()
        {
            IDataChunkHeaderSetter sccs = new DataChunkHeaderSetter();
            return sccs.SetDataChunkHeader();
        }

        public static byte[] SetFMTChunk1Marker()
        {
            IFMTSubChunkMarker cm = new FMTSubChunkMarker();
            return cm.SetFMTChunk1Marker();
        }

        public static byte[] SetFmtDataLength()
        {
            IFmtDataLengthSetter fdls = new FmtDataLengthSetter();
            return fdls.SetFmtDataLength();
        }

        public static byte[] SetByteRate(IWaveFileHeader waveFileHeader)
        {
            IByteRateSetter brs = new ByteRateSetter();
            return brs.SetByteRate(waveFileHeader);
        }

        public static byte[] SetBlockAlign(IWaveFileHeader waveFileHeader)
        {
            IBlockAlignSetter bas = new BlockAlignSetter();
            return bas.SetBlockAlign(waveFileHeader);
            
        }

        public static byte[] SetWaveChunkId()
        {
            IWaveChunkIdSetter wcs = new WaveChunkIdSetter();
           return wcs.SetWaveChunkId();
        }
    }
}
