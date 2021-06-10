using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppOsi.View;

namespace AppOsi.Brigadas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrigadaEvacuacionPage : ContentPage
    {
        public BrigadaEvacuacionPage()
        {
            InitializeComponent();
            btnzona.Clicked += async delegate
            {
                await Navigation.PushAsync(new SubirMapaPage());

            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapaViewPage());
        }
    }
}