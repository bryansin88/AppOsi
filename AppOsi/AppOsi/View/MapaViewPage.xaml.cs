using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppOsi.Model;

namespace AppOsi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapaViewPage : ContentPage
    {
        public MapaViewPage()
        {
            InitializeComponent();
            cargarWs();
        }

        public async void cargarWs()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.1.109");
            string url = string.Format("/CenturiosWS/public/api/mapas");
            var response = await client.GetAsync(url);
            var result = response.Content.ReadAsStringAsync().Result;
            if (string.IsNullOrEmpty(result) || result == "null")
            {
                await DisplayAlert("Error", "No hay información a mostrar", "OK");
                return;
            }
            var UserDevice = JsonConvert.DeserializeObject<List<ImagenS>>(result);
            for (int i = 0; i < UserDevice.Count; i++)
            {
                //string urlim = "http://192.168.1.109/CenturiosWS/img/1.png";
                //img1.Text= string.Format(UserDevice[i].Imagen1);
                //imagen1.Source = urlim;
            }
            string urlim = "http://192.168.1.109/CenturiosWS/img/";
            //img1.Text = string.Format(UserDevice[0].Imagen);
            imagen1.Source = urlim+string.Format(UserDevice[0].Imagen);
            imagen2.Source = urlim + string.Format(UserDevice[1].Imagen);
            imagen3.Source = urlim + string.Format(UserDevice[2].Imagen);
            imagen4.Source = urlim + string.Format(UserDevice[3].Imagen);

            imagen5.Source = urlim + string.Format(UserDevice[4].Imagen);
            imagen6.Source = urlim + string.Format(UserDevice[5].Imagen);
            imagen7.Source = urlim + string.Format(UserDevice[6].Imagen);
            imagen8.Source = urlim + string.Format(UserDevice[7].Imagen);

            imagen9.Source = urlim + string.Format(UserDevice[8].Imagen);
            imagen10.Source = urlim + string.Format(UserDevice[9].Imagen);
            imagen11.Source = urlim + string.Format(UserDevice[10].Imagen);
            imagen12.Source = urlim + string.Format(UserDevice[11].Imagen);

            imagen13.Source = urlim + string.Format(UserDevice[12].Imagen);
            imagen14.Source = urlim + string.Format(UserDevice[13].Imagen);
            imagen15.Source = urlim + string.Format(UserDevice[14].Imagen);
            imagen16.Source = urlim + string.Format(UserDevice[15].Imagen);

            //imagen17.Source = urlim + string.Format(UserDevice[16].Imagen);
            //imagen18.Source = urlim + string.Format(UserDevice[17].Imagen);
            //imagen19.Source = urlim + string.Format(UserDevice[18].Imagen);
            //imagen20.Source = urlim + string.Format(UserDevice[19].Imagen);

        }

        private void imagen1_Clicked(object sender, EventArgs e)
        {
            imagen1.Source = "http://192.168.1.109/CenturiosWS/img/rojo.png";
        }
    }
}