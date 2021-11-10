using SigGenSonic.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SigGenSonic.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}