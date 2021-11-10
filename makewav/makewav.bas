
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
13-16 	"fmt " 	Format chunk marker. Includes trailing null
17-20 	16 	Length of format data as listed above
21-22 	1 	Type of format (1 is PCM) - 2 byte integer
23-24 	2 	Number of Channels - 2 byte integer
25-28 	44100 	Sample Rate - 32 byte integer. Common values are 44100 (CD), 48000 (DAT). Sample Rate = Number of Samples per second, or Hertz.
29-32 	176400 	(Sample Rate * BitsPerSample * Channels) / 8.
33-34 	4 	(BitsPerSample * Channels) / 8.1 - 8 bit mono2 - 8 bit stereo/16 bit mono4 - 16 bit stereo
35-36 	16 	Bits per sample
37-40 	"data" 	"data" chunk header. Marks the beginning of the data section.
41-44 	File size (data) 	Size of the data section.
Sample values are given above for a 16-bit stereo source.

So, that's the header. It shouldn't be difficult to write an application that creates the header, but in case you don't want to bother, I've included some Visual Basic code to do just that at the end of this document.

Finalizing the file
Finalizing the file is actually incredibly easy. You don't need to do anything except making sure that the file size fields are filled in correctly.

Putting it together.
For the first WAV file example, we're going to create the simplest possible file. This file will be full of zero-bit data. Zero-bit data is basically a sample with 0 amplitude. While very boring, zero-bit files are important in testing stereos. Because there is an amplitude (volume) of zero, noise induced by various components can be found.

Here's visual basic code to create the file. This code is as simple as possible, and is designed to provide a look at the process.

public Sub WriteZeroByteFile()
Dim sampleRate as Integer
Dim bitSize as Integer
Dim numChannels as Integer
Dim numSeconds as Integer
Dim fileName as String
Dim fileSize as Integer
Dim dataPos as Integer
Dim headerLength as Integer
Dim totalSamples as Integer

' Set up our parameters
sampleRate = 44100        ' CD-Quality Sound.
bitSize = 16              ' Bit Size is 16 (CD-Quality).
numChannels = 2           ' Stereo mode (2-channel).
numSeconds = 1            ' We're going to make a 1 second sample.
fileSize = 0              ' Just set it to zero for now.
fileName = "c:\temp.wav"  ' Pick a temporary file name.

     
' Open the file.  This will fail if the file exists.
Open fileName For Binary Access Write As #1

' Write the header
Put #1, 1,  "RIFF"        ' RIFF marker
Put #1, 5,  CInt(0)       ' file-size (equals file-size - 8)
Put #1, 9,  "WAVE"        ' Mark it as type "WAVE"
Put #1, 13, "fmt "        ' Mark the format section.
Put #1, 17, CLng(16)      ' Length of format data.  Always 16
Put #1, 21, CInt(1)       ' Wave type PCM
Put #1, 23, CInt(2)       ' 2 channels
Put #1, 25, CLng(44100)   ' 44.1 kHz Sample Rate (CD-Quality)
Put #1, 29, CLng(88200)   ' (Sample Rate * Bit Size * Channels) / 8
Put #1, 33, CInt(2)       ' (Bit Size * Channels) / 8
Put #1, 35, CInt(16)      ' Bits per sample (=Bit Size * Samples)
Put #1, 37, "data"        ' "data" marker
Put #1, 41, CInt(0)       ' data-size (equals file-size - 44).

' headerLength is the length of the header.  It is used for offsetting
' the data position.
headerLength = 44

' Determine the total number of samples 
totalSamples = sampleRate * numSeconds

' Populate with 0 bit data.
' This isn't a good reference for creating PCM data.  Since we are
' just dumping 0 bit data, we're dumping it in 32 bit chunks.
For dataPos = 1 to (totalSamples * 4) step 4
  ' We're doing 16-bit, so we need to write 2 bytes per channel.
  ' Write both channels using a 32 bit integer.
  ' Again, this isn't a good reference.  Ignore this data writing
  ' process.  It's useless for anything but 0 bit data.
  Put #1, dataPos + headerLength, CInt(0)  
Next

' Finalize the file.  Write the file size to the header.
fileSize = LOF(1)               ' Get the actual file size.
Put #1, 5, CLng(fileSize - 8)   ' Set first file size marker.
Put #1, 41, CLng(fileSize - 44) ' Set data size marker.
Close #1 ' Close the file.
End Sub

Conclusion
This tutorial should have provided enough information to understand the WAV (RIFF) file format and to create one. Now that you've examined the creation of a WAV file, the next step is to populate it with meaningful data.

feedback at topherlee.com
