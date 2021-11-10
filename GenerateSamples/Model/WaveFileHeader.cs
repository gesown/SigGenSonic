using System;
using GenerateSamples.Facade;

namespace GenerateSamples.Model
{
    public class WaveFileHeader : IWaveFileHeader
    {
        public WaveFileHeader(string[] args)
        {
            SampleBitLength = args[3];
            SampleRateIn = args.Length > 4 ? args[4] : "44100";
            FileInName = args[0];
            Header = new Byte[44];
        }

        public string SampleBitLength { get; set; }
        public string SampleRateIn { get; set; }
        public byte[] Header { get; set; } // 44 bytes in array
        public string FileInName { get; set; }
        public byte[] RiffChunkId { get; set; }
        public byte[] FileSize { get; set; }
        public byte[] FileTypeHeader { get; set; }
        public byte[] FMTSubChunkMarker { get; set; }
        public byte[] AudioFmtDataLength { get; set; }
        public byte[] FormatType { get; set; }
        public byte[] ChannelCount { get; set; }
        public byte[] SampleRate { get; set; }
        public byte[] ByteRate { get; set; }
        public byte[] BlockAlign { get; set; }
        public byte[] BitsPerSample { get; set; }
        public byte[] DataChunkHeader { get; set; }
        public byte[] DataSectionSize { get; set; }
        public byte[] SoundSamples { get; set; }
        public byte[] WAVEChunkId { get; set; }
        public IWaveFileHeader FillHeader(IWaveFileHeader header)
        {
            return GSFacade.FillHeader(this);
        }

        public int ChunkIDLocation => 0;
        public int FinalSizeOfWavFileLocation => 4;
        public int WAVEFormatLocation => 8;
        public int FmtSubChunkMarkerLocation => 12;
        public int AudioFormatLengthLocation => 16;
        public int TypeOfFormatLocation => 20;
        public int NumChannelsLocation => 22;
        public int SampleRateLocation => 24;
        public int ByteRateLocation => 28;
        public int BlockAlignLocation => 32;
        public int BitsPerSampleLocation => 34;
        public int DataChunkHeaderLocation => 36;
        public int DataSectionSizeLocation => 40;


        /*
        filename | frequency | duration | int size | sample rate
        sam100_32_def.bin 1000 10000  32  44100

        The canonical WAVE format starts with the RIFF header:
           
           0         4   ChunkID          Contains the letters "RIFF" in ASCII form
           (0x52494646 big-endian form).
           4         4   ChunkSize        36 + SubChunk2Size, or more precisely:
           4 + (8 + SubChunk1Size) + (8 + SubChunk2Size)
           This is the size of the rest of the Chunk 
           following this number.  This is the size of the 
           entire file in bytes minus 8 bytes for the
           two fields not included in this count:
           ChunkID and ChunkSize.
           8         4   Format           Contains the letters "WAVE"
           (0x57415645 big-endian form).
           
           The "WAVE" format consists of two subChunks: "fmt " and "data":
           The "fmt " subChunk describes the sound data's format:
           
           12        4   SubChunk1ID      Contains the letters "fmt "
           (0x666d7420 big-endian form).
           16        4   SubChunk1Size    16 for PCM.  This is the size of the
           rest of the SubChunk which follows this number.
           20        2   AudioFormat      PCM = 1 (i.e. Linear quantization)
           Values other than 1 indicate some 
           form of compression.
           22        2   NumChannels      Mono = 1, Stereo = 2, etc.
           24        4   SampleRate       8000, 44100, etc.
           28        4   ByteRate         == SampleRate * NumChannels * BitsPerSample/8
           32        2   BlockAlign       == NumChannels * BitsPerSample/8
           The number of bytes for one sample including
           all channels. I wonder what happens when
           this number isn't an integer?
           34        2   BitsPerSample    8 bits = 8, 16 bits = 16, etc.
           2   ExtraParamSize   if PCM, then doesn't exist
           X   ExtraParams      space for extra parameters
           
           The "data" subChunk contains the size of the data and the actual sound:
           
           36        4   DataChunkHeader      Contains the letters "data"
           (0x64617461 big-endian form).
           40        4   SubChunk2Size    == NumSamples * NumChannels * BitsPerSample/8
           This is the number of bytes in the data.
           You can also think of this as the size
           of the read of the subChunk following this 
           number.
           44        *   Data             The actual sound data.




           Home   ·   Car Audio   ·   Software   ·   Random Stuff
           
           
           Digital Audio - Creating a WAV (RIFF) file
           
           Abstract:
           This tutorial covers the creation of a WAV (RIFF) audio file. It covers bit size, sample rate, channels, data, headers and finalizing the file. This document is designed to cover uncompressed PCM audio files, the most common type of RIFF files. This document does not cover inserting useful data into the WAV (RIFF) audio file.
           
           What's a WAV (RIFF) File?
           A WAV (RIFF) file is a multi-format file that contains a header and data. For the purposes of this document, only a simple PCM file will be explored. A WAV file contains a header and the raw data, in time format.
           
           What's bit size?
           Bit size determines how much information can be stored in a file. For most of today's purposes, bit size should be 16 bit. 8 bit files are smaller (1/2 the size), but have less resolution.
           
           Bit size deals with amplitude. In 8 bit recordings, a total of 256 (0 to 255) amplitude levels are available. In 16 bit, a total of 65,536 (-32768 to 32767) amplitude levels are available. The greater the resolution of the file is, the greater the realistic dynamic range of the file. CD-Audio uses 16 bit samples.
           
           What is Sample Rate?
           Sample rate is the number of samples per second. CD-Audio has a sample rate of 44,100. This means that 1 second of audio has 44,100 samples. DAT tapes have a sample rate of 48,000.
           
           When looking at frequency response, the highest frequency can be considered to be 1/2 of the sample rate.
           
           What are Channels?
           Channels are the number of separate recording elements in the data. For a real quick example, one channel is mono and two channels are stereo. In this document, both single and dual channel recordings will be discussed.
           
           What is the data?
           The data is the individual samples. An individual sample is the bit size times the number of channels. For example, a monaural (single channel), eight bit recording has an individual sample size of 8 bits. A monaural sixteen-bit recording has an individual sample size of 16 bits. A stereo sixteen-bit recording has an individual sample size of 32 bits.
           
           Samples are placed end-to-end to form the data. So, for example, if you have four samples (s1, s2, s3, s4) then the data would look like: s1s2s3s4.
           
           What is the header?
           The header is the beginning of a WAV (RIFF) file. The header is used to provide specifications on the file type, sample rate, sample size and bit size of the file, as well as its overall length.
           
           The header of a WAV (RIFF) file is 44 bytes long and has the following format:
           Positions 	Sample Value 	Description
           1 - 4 	"RIFF" 	Marks the file as a riff file. Characters are each 1 byte long.
           5 - 8 	File size (integer) 	Size of the overall file - 8 bytes, in bytes (32-bit integer). Typically, you'd fill this in after creation.
           9 -12 	"WAVE" 	File Type Header. For our purposes, it always equals "WAVE".
           13-16 	"fmt " 	Format Chunk marker. Includes trailing null
           17-20 	16 	Length of format data as listed above
           21-22 	1 	Type of format (1 is PCM) - 2 byte integer
           23-24 	2 	Number of Channels - 2 byte integer
           25-28 	44100 	Sample Rate - 32 byte integer. Common values are 44100 (CD), 48000 (DAT). Sample Rate = Number of Samples per second, or Hertz.
           29-32 	176400 	(Sample Rate * BitsPerSample * Channels) / 8.
           33-34 	4 	(BitsPerSample * Channels) / 8.1 - 8 bit mono2 - 8 bit stereo/16 bit mono4 - 16 bit stereo
           35-36 	16 	Bits per sample
           37-40 	"data" 	"data" Chunk header. Marks the beginning of the data section.
           41-44 	File size (data) 	Size of the data section.
           Sample values are given above for a 16-bit stereo source.
           
           So, that's the header. It shouldn't be difficult to write an application that creates the header, but in case you don't want to bother, I've included some Visual Basic code to do just that at the end of this document.
           
           Finalizing the file
           Finalizing the file is actually incredibly easy. You don't need to do anything except making sure that the file size fields are filled in correctly.
           
           Putting it together.
           For the first WAV file example, we're going to create the simplest possible file. This file will be full of zero-bit data. Zero-bit data is basically a sample with 0 amplitude. While very boring, zero-bit files are important in testing stereos. Because there is an amplitude (volume) of zero, noise induced by various components can be found.
           
           Here's visual basic code to create the file. This code is as simple as possible, and is designed to provide a look at the process.
           */
    }
}