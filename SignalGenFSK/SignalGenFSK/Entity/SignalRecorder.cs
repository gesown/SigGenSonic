using System;
using System.Collections.Generic;
using System.Globalization;
using SignalGenFSK.Facade;
using SignalGenFSK.Interface;
using SignalGenFSK.Model;

namespace SignalGenFSK.Entity
{
    public class SignalRecorder : ISignalRecorder
    {
        public IList<SignalTime> RecordSignal(IRunConfiguration runConfiguration)
        {
            var carrierFreq =double.Parse( runConfiguration.CarrierFrequency.ToString());
            var deviation = runConfiguration.FrequencyDeviation;
            var bitDuration = runConfiguration.CyclesBitDuration;
            var signalDuration = runConfiguration.SignalDurationMS;
            var signalCycles = 8;//int.Parse( Math.Floor( carrierFreq * signalDuration).ToString(CultureInfo.InvariantCulture));
       //     var numberOfBits =int.Parse( Math.Floor((double) signalDuration / bitDuration).ToString(CultureInfo.InvariantCulture));
       //     var cyclesPerBit =int.Parse( Math.Floor((double) signalCycles / numberOfBits).ToString(CultureInfo.InvariantCulture));
       var highFreq = carrierFreq + deviation;
       var lowFreq = carrierFreq - deviation;
      //      var leadInOutTime = 0.05 * signalDuration;
          //  var sampleRate = runConfiguration
            IList<SignalTime> carrierSamples = SGFSKFacade.GenerateSamples(carrierFreq, signalCycles);
            IList<SignalTime> carrierPlusSamples = SGFSKFacade.GenerateSamples(highFreq, signalCycles);
            IList<SignalTime> carrierMinusSamples = SGFSKFacade.GenerateSamples(lowFreq, signalCycles);
            double lowBuffer=0.0;
            IList<SignalTime> bufferSamplesMinus = SGFSKFacade.GenerateSamples(lowBuffer, signalCycles);
            double highBuffer = 0.0;
            IList<SignalTime> bufferSamplesPlus = SGFSKFacade.GenerateSamples(highBuffer, signalCycles);

            // Make Signal concating base x 2, alternating +/- signal Cycles times followed by base x 2
            IList<SignalTime> BaseSignal = SGFSKFacade.ConcatLists(carrierSamples, carrierSamples);
            IList<SignalTime> SignalOut = SGFSKFacade.ConcatLists(BaseSignal, carrierPlusSamples);
            SignalOut = SGFSKFacade.ConcatLists(SignalOut, BaseSignal);
            for (int i = 0; i < 8; i++)
            {
//                SignalOut = SGFSKFacade.ConcatLists(SignalOut, BaseSignal);
                SignalOut = SGFSKFacade.ConcatLists(SignalOut, carrierMinusSamples);
                SignalOut = SGFSKFacade.ConcatLists(SignalOut, bufferSamplesMinus);

                //        SignalOut = SGFSKFacade.ConcatLists(SignalOut, BaseSignal);
                SignalOut = SGFSKFacade.ConcatLists(SignalOut, carrierPlusSamples);
                SignalOut = SGFSKFacade.ConcatLists(SignalOut, bufferSamplesPlus);
            }
            SignalOut = SGFSKFacade.ConcatLists(SignalOut, BaseSignal);


            return SignalOut;
        }
    }
}