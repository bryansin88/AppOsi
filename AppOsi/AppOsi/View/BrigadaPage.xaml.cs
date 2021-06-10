using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Graphics;
using AppOsi.Brigadas;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppOsi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrigadaPage : ContentPage
    {
        public BrigadaPage()
        {
            InitializeComponent();


        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
           

           
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BrigadaSeguridadPage());

        }
        private async void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BrigadaCampamentoPage());
        }

        private async void ImageButton_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BrigadaEvacuacionPage());
        }
        private async void ImageButton_Clicked_4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BrigadaPAuxiliosPage());
        }

        private async void ImageButton_Clicked_5(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BrigadaContraIncendioPage());
        }
        private async void ImageButton_Clicked_6(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BrigadaComunicacionPage());
        }
    }
}