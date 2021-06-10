using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using AppOsi.Model;

namespace AppOsi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformacionPage : ContentPage
    {
        public InformacionPage(string user_ci)
        {
            InitializeComponent();
            cargarWs(user_ci);
        }
        public async void cargarWs(string ced1)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.1.109");
            string url = string.Format("/CenturiosWS/public/api/empresa/{0}", ced1);
            var response = await client.GetAsync(url);
            var result = response.Content.ReadAsStringAsync().Result;
            if (string.IsNullOrEmpty(result) || result == "null")
            {
                await DisplayAlert("Error", "No hay información a mostrar", "OK");
                return;
            }
            var UserDevice = JsonConvert.DeserializeObject<List<Empresa>>(result);
            for (int i = 0; i < UserDevice.Count; i++)
            {

                txtInstitucion.Text = string.Format(UserDevice[i].Emp_nombre);
                txtrazon.Text = string.Format(UserDevice[i].Emp_nombre);
                txtdireccion.Text= string.Format(UserDevice[i].Emp_direccion);
                
            }
        }
    }
}