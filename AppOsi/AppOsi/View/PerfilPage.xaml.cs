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
    public partial class PerfilPage : ContentPage
    {
        public PerfilPage(string user_ci)
        {
            InitializeComponent();
            cargarWs(user_ci);
        }

        public async void cargarWs(string ced1)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.1.109");
            string url = string.Format("/CenturiosWS/public/api/perfil/{0}",ced1);
            var response = await client.GetAsync(url);
            var result = response.Content.ReadAsStringAsync().Result;
            if (string.IsNullOrEmpty(result) || result == "null")
            {
                await DisplayAlert("Error", "No hay información a mostrar", "OK");
                return;
            }
            var UserDevice = JsonConvert.DeserializeObject<List<Perfil>>(result);
            for (int i = 0; i < UserDevice.Count; i++)
            {
                txtsangre.Text = string.Format(UserDevice[i].Tipsan_descripcion);
                txtalergias.Text = string.Format(UserDevice[i].Datmed_alergia);
                txtmedicamentos.Text = string.Format(UserDevice[i].Datmed_alergia_medicamento);
                txtdiscapacidad.Text = string.Format(UserDevice[i].Disca_descripcion);
                txtdiscapacidadpor.Text = string.Format(UserDevice[i].Datmed_porcentaje_discapacidad);
                txtenfermedades.Text = string.Format(UserDevice[i].Datmed_enfermedades);
                //txtuser.Text = string.Format("Bienvenid@ " + users[i].Usr_nombres + " " + users[i].Usr_apellidos);
                //brigadaId = users[i].Brig_id;
                //user_ci = users[i].Usr_ci;
            }
        }
    }
}