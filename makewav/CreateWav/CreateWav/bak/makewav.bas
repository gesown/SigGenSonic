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
