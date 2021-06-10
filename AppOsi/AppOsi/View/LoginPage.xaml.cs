using AppOsi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppOsi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
           
            btnlogin.Clicked += Btnlogin_Clicked;
            
        }

        private async void Btnlogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtusu.Text))
                {
                    await DisplayAlert("Error", "Debe ingresar su usuario", "OK");
                    txtusu.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtpass.Text))
                {
                    await DisplayAlert("Error", "Debe ingresar su clave", "OK");
                    txtpass.Focus();
                    return;
                }
                activiteIndicator.IsRunning = true;
                HttpClient client = new HttpClient();
                btnlogin.IsEnabled = false;
                client.BaseAddress = new Uri("http://192.168.0.2:8888");
                string url = string.Format("/CenturiosWS/public/api/usuarioL/{0}/{1}", txtusu.Text, txtpass.Text);
                var response = await client.GetAsync(url);
                var result = response.Content.ReadAsStringAsync().Result;
                btnlogin.IsEnabled = true;
                activiteIndicator.IsRunning = false;
                if (string.IsNullOrEmpty(result) || result == "null")
                {
                    await DisplayAlert("Error", "Usuario/Clave incorrecta", "OK");
                    txtpass.Text = string.Empty;
                    txtpass.Focus();
                    return;
                }
                var UserDevice = JsonConvert.DeserializeObject<List<Users>>(result);
                await Navigation.PushAsync(new MenuPage(UserDevice));
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", "No se encuentra acceso al Servidor intentelo más tarde", "OK");
                txtpass.Text = string.Empty;
                txtpass.Focus();
                btnlogin.IsEnabled = true;
                activiteIndicator.IsRunning = false;
                return;
            }

        }
    }
}