Module WriteZeroByteFile
    Sub Main()
        WriteZeroByteFile()
    End Sub
    Sub WriteZeroByteFile()
        Dim sampleRate As Integer
        Dim bitSize As Integer
        Dim numChannels As Integer
        Dim numSeconds As Integer
        Dim fileName As String
        Dim fileSize As Integer
        Dim dataPos As Integer
        Dim headerLength As Integer
        Dim totalSamples As Integer

        ' Set up our parameters
        sampleRate = 44100        ' CD-Quality Sound.
        bitSize = 16              ' Bit Size is 16 (CD-Quality).
        numChannels = 2           ' Stereo mode (2-channel).
        numSeconds = 1            ' We're going to make a 1 second sample.
        fileSize = 0              ' Just set it to zero for now.
        fileName = "c:\temp.wav"  ' Pick a temporary file name.


        ' Open the file.  This will fail if the file exists.
        FileOpen(1, fileName, OpenMode.Binary, OpenAccess.Write)
        'Open fileName For Binary Access Write As #1

        ' Write the header
        FilePutObject(1, "RIFF") ' RIFF marker
        'FilePutObject(1, CInt(0)) ' file-size (equals file-size - 8)
        'FilePutObject(1, "WAVE") ' Mark it as type "WAVE"
        'FilePutObject(1, "fmt ") ' Mark the format section.
        'FilePutObject(1, CLng(16)) ' Length of format data.  Always 16
        'FilePutObject(1, CInt(1)) ' Wave type PCM
        'FilePutObject(1, CInt(2)) ' 2 channels
        'FilePutObject(1, CLng(44100)) ' 44.1 kHz Sample Rate (CD-Quality)
        'FilePutObject(1, CLng(88200)) ' (Sample Rate * Bit Size * Channels) / 8
        'FilePutObject(1, CInt(2)) ' (Bit Size * Channels) / 8
        'FilePutObject(1, CInt(16)) ' Bits per sample (=Bit Size * Samples)
        'FilePutObject(1, "data") ' "data" marker
        'FilePutObject(1, CInt(0)) ' data-size (equals file-size - 44).

        'FilePutObject(1, "RIFF", 1) ' RIFF marker
        'FilePutObject(1, CInt(0), 5) ' file-size (equals file-size - 8)
        'FilePutObject(1, "WAVE", 9) ' Mark it as type "WAVE"
        'FilePutObject(1, "fmt ", 13) ' Mark the format section.
        'FilePutObject(1, CLng(16), 17) ' Length of format data.  Always 16
        'FilePutObject(1, CInt(1), 21) ' Wave type PCM
        'FilePutObject(1, CInt(2), 23) ' 2 channels
        'FilePutObject(1, CLng(44100), 25) ' 44.1 kHz Sample Rate (CD-Quality)
        'FilePutObject(1, CLng(88200), 29) ' (Sample Rate * Bit Size * Channels) / 8
        'FilePutObject(1, CInt(2), 33) ' (Bit Size * Channels) / 8
        'FilePutObject(1, CInt(16), 35) ' Bits per sample (=Bit Size * Samples)
        'FilePutObject(1, "data", 37) ' "data" marker
        'FilePutObject(1, CInt(0), 41) ' data-size (equals file-size - 44).

        'FilePutObject(1, 1, "RIFF") ' RIFF marker
        'FilePutObject(1, 5, CInt(0)) ' file-size (equals file-size - 8)
        'FilePutObject(1, 9, "WAVE") ' Mark it as type "WAVE"
        'FilePutObject(1, 13, "fmt ") ' Mark the format section.
        'FilePutObject(1, 17, CLng(16)) ' Length of format data.  Always 16
        'FilePutObject(1, 21, CInt(1)) ' Wave type PCM
        'FilePutObject(1, 23, CInt(2)) ' 2 channels
        'FilePutObject(1, 25, CLng(44100)) ' 44.1 kHz Sample Rate (CD-Quality)
        'FilePutObject(1, 29, CLng(88200)) ' (Sample Rate * Bit Size * Channels) / 8
        'FilePutObject(1, 33, CInt(2)) ' (Bit Size * Channels) / 8
        'FilePutObject(1, 35, CInt(16)) ' Bits per sample (=Bit Size * Samples)
        'FilePutObject(1, 37, "data") ' "data" marker
        'FilePutObject(1, 41, CInt(0)) ' data-size (equals file-size - 44).

        'Put #1, 1, "RIFF"        ' RIFF marker
        'Put #1, 5, CInt(0)       ' file-size (equals file-size - 8)
        'Put #1, 9, "WAVE"        ' Mark it as type "WAVE"
        'Put #1, 13, "fmt "        ' Mark the format section.
        'Put #1, 17, CLng(16)      ' Length of format data.  Always 16
        'Put #1, 21, CInt(1)       ' Wave type PCM
        'Put #1, 23, CInt(2)       ' 2 channels
        'Put #1, 25, CLng(44100)   ' 44.1 kHz Sample Rate (CD-Quality)
        'Put #1, 29, CLng(88200)   ' (Sample Rate * Bit Size * Channels) / 8
        'Put #1, 33, CInt(2)       ' (Bit Size * Channels) / 8
        'Put #1, 35, CInt(16)      ' Bits per sample (=Bit Size * Samples)
        'Put #1, 37, "data"        ' "data" marker
        'Put #1, 41, CInt(0)       ' data-size (equals file-size - 44).

        ' headerLength is the length of the header.  It is used for offsetting
        ' the data position.
        headerLength = 44

        ' Determine the total number of samples 
        totalSamples = sampleRate * numSeconds

        ' Populate with 0 bit data.
        ' This isn't a good reference for creating PCM data.  Since we are
        ' just dumping 0 bit data, we're dumping it in 32 bit chunks.
        For dataPos = 1 To (totalSamples * 4) Step 4
            ' We're doing 16-bit, so we need to write 2 bytes per channel.
            ' Write both channels using a 32 bit integer.
            ' Again, this isn't a good reference.  Ignore this data writing
            ' process.  It's useless for anything but 0 bit data.
            FilePutObject(1, CInt(0))
        Next

        ' Finalize the file.  Write the file size to the header.
        fileSize = LOF(1)               ' Get the actual file size.
        FilePutObject(1, CLng(fileSize - 8), 5) ' Set first file size marker.
        FilePutObject(1, CLng(fileSize - 44), 41) ' Set data size marker.
        FileClose(1) ' Close the file.
    End Sub

    'Conclusion
    'This tutorial should have provided enough information To understand the WAV (RIFF) file format And To create one. Now that you've examined the creation of a WAV file, the next step is to populate it with meaningful data.

    'feedback at topherlee.com

    '  End Sub

End Module
