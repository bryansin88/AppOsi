using AppOsi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppOsi.Brigadas;

namespace AppOsi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        int brigadaId=0;
        string user_ci = "";
        public MenuPage(List<Users> users)
        {
            InitializeComponent();
            for (int i = 0; i < users.Count; i++)
            {
                txtuser.Text = string.Format("Bienvenid@ " + users[i].Usr_nombres + " "+ users[i].Usr_apellidos);
                brigadaId = users[i].Brig_id;
                user_ci = users[i].Usr_ci;
            }
           
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PerfilPage(user_ci));
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            switch (brigadaId) {
                case 1: await Navigation.PushAsync(new BrigadaPage());
                        break;
                case 2: await Navigation.PushAsync(new BrigadaComunicacionPage());
                        break;
                case 3:
                    await Navigation.PushAsync(new BrigadaCampamentoPage());
                    break;
                case 4:
                    await Navigation.PushAsync(new BrigadaPAuxiliosPage());
                    break;
                case 5:
                    await Navigation.PushAsync(new BrigadaContraIncendioPage());
                    break;
                case 6:
                    await Navigation.PushAsync(new BrigadaSeguridadPage());
                    break;
                case 7:
                    await Navigation.PushAsync(new BrigadaEvacuacionPage());
                    break;
            }
            
        }

        private async void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InformacionPage(user_ci));
        }
    }
}