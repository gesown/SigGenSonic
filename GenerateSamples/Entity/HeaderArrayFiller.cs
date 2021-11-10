using System;
using GenerateSamples.Facade;
using GenerateSamples.Interface;
using GenerateSamples.Model;

namespace GenerateSamples.Entity
{
    public class HeaderArrayFiller : IHeaderArrayFiller
    {
        public IWaveFileHeader FillHeader(IWaveFileHeader waveFileHeader)
        {
            waveFileHeader.SoundSamples = GSFacade.GetSoundSamples(waveFileHeader.FileInName);
            waveFileHeader.RiffChunkId = GSFacade.SetFileType();
            waveFileHeader.FileSize = GSFacade.SetFileSize(waveFileHeader.SoundSamples.Length);
            waveFileHeader.FileTypeHeader = GSFacade.SetFileTypeHeader();
            waveFileHeader.FMTSubChunkMarker = GSFacade.SetFMTChunk1Marker();
            waveFileHeader.FormatType = GSFacade.SetFormatType(MonoStereoFlag.Mono); // mono = 1, stereo = 2
            waveFileHeader.ChannelCount = GSFacade.SetChannelCountMono();
            waveFileHeader.SampleRate = GSFacade.SetSampleRate(waveFileHeader.SampleRateIn);
            waveFileHeader.BitsPerSample = GSFacade.SetBitsPerSample(waveFileHeader.SampleBitLength);
            waveFileHeader.DataChunkHeader = GSFacade.SetDataChunkHeader();
            waveFileHeader.DataSectionSize = GSFacade.SetSamCountChanCountBytePerSampleSize(waveFileHeader);
            waveFileHeader.AudioFmtDataLength = GSFacade.SetFmtDataLength();
            waveFileHeader.ByteRate = GSFacade.SetByteRate(waveFileHeader);
            waveFileHeader.BlockAlign = GSFacade.SetBlockAlign(waveFileHeader);
            waveFileHeader.WAVEChunkId = GSFacade.SetWaveChunkId();

           FillByteUnsafe.Copy(waveFileHeader.FileTypeHeader, 0, waveFileHeader.Header, waveFileHeader.TypeOfFormatLocation, waveFileHeader.FileTypeHeader.Length);
            var fileSizeBytes=BitConverter.GetBytes(waveFileHeader.FileSize.Length);
            FillByteUnsafe.Copy(fileSizeBytes, 0, waveFileHeader.Header, waveFileHeader.FinalSizeOfWavFileLocation, fileSizeBytes.Length);
            FillByteUnsafe.Copy(waveFileHeader.WAVEChunkId, 0, waveFileHeader.Header, waveFileHeader.WAVEFormatLocation, waveFileHeader.WAVEChunkId.Length);
            FillByteUnsafe.Copy(waveFileHeader.RiffChunkId, 0, waveFileHeader.Header, waveFileHeader.ChunkIDLocation, waveFileHeader.RiffChunkId.Length);
            FillByteUnsafe.Copy(waveFileHeader.FMTSubChunkMarker, 0, waveFileHeader.Header, waveFileHeader.FmtSubChunkMarkerLocation, waveFileHeader.FMTSubChunkMarker.Length);
            FillByteUnsafe.Copy(waveFileHeader.FormatType, 0, waveFileHeader.Header, waveFileHeader.TypeOfFormatLocation, waveFileHeader.FormatType.Length);
            FillByteUnsafe.Copy(waveFileHeader.ChannelCount, 0, waveFileHeader.Header, waveFileHeader.NumChannelsLocation, waveFileHeader.ChannelCount.Length);
            FillByteUnsafe.Copy(waveFileHeader.SampleRate, 0, waveFileHeader.Header, waveFileHeader.SampleRateLocation, waveFileHeader.SampleRate.Length);
            FillByteUnsafe.Copy(waveFileHeader.ByteRate, 0, waveFileHeader.Header, waveFileHeader.BlockAlignLocation, waveFileHeader.ByteRate.Length);
            FillByteUnsafe.Copy(waveFileHeader.BlockAlign, 0, waveFileHeader.Header, waveFileHeader.BitsPerSampleLocation, waveFileHeader.BlockAlign.Length);
            FillByteUnsafe.Copy(waveFileHeader.BitsPerSample, 0, waveFileHeader.Header, waveFileHeader.BitsPerSampleLocation, waveFileHeader.BitsPerSample.Length);
            FillByteUnsafe.Copy(waveFileHeader.DataChunkHeader, 0, waveFileHeader.Header, waveFileHeader.DataChunkHeaderLocation, waveFileHeader.DataChunkHeader.Length);
        //    waveFileHeader.FillByteUnsafe.Copy(waveFileHeader.SubChunk2Size, 0, waveFileHeader.Header, waveFileHeader.DataLocation, waveFileHeader.SubChunk2Size.Length);

            return waveFileHeader;
        }
    }
}