using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using SignalGenFSK.Model;
using System.Windows;
using SignalGenFSK.Facade;
using SignalGenFSK.Interface;

namespace SignalGenFSK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ISGFSKModel
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonMakeSignal(object sender, RoutedEventArgs e)
        {
            CarrierFrequency = int.Parse(TxtCarrierFrequency.Text);
            FrequencyDeviation = int.Parse(Deviation.Text);
            Duration = int.Parse(SignalDurationMS.Text);
            FileOutName = FileOut.Text;
            
         var SignalOut=   SGFSKFacade.RecordSignal(RunConfiguration);

         IList<string> SignalOutStrings = SignalOut.Select(s => s.ToString()).ToList();
         File.AppendAllLines(FileOutName,SignalOutStrings);
        }

        public int CarrierFrequency { get; set; }
        public int FrequencyDeviation { get; set; }
        public string FileOutName { get; set; }
        public int Duration { get; set; }

        public IRunConfiguration RunConfiguration => SGFSKFacade.SetRunConfiguration(this);
    }
}
