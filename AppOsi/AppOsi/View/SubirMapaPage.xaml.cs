using Plugin.Geolocator;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppOsi.Model;

using System.Net.Http;
using Xamarin.Android;
using Newtonsoft.Json;
using System.IO;
using Android.Graphics;
using Java.IO;
using System.Drawing;
using Image = Xamarin.Forms.Image;

using System.Net;
using Android.Widget;
using Bitmap = Android.Graphics.Bitmap;

namespace AppOsi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubirMapaPage : ContentPage
    {
        double latitud; 
         ImageView imagen2;
            double longi;
        private MediaFile _mediaFile;

        Bitmap bitmap;
        public SubirMapaPage()
        {
            InitializeComponent();
            cargarMapas();
            btnSelec.Clicked += delegate
             {
                 Localizar();
             };
           
        }


      
        public async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            return status;
        }
        public async void Localizar()
        {
           
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            if (locator.IsGeolocationAvailable)
            {
               
                if (locator.IsGeolocationEnabled)
                {
                    
                    if (!locator.IsListening)
                    {
                        await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5);

                    }
                    locator.PositionChanged += (cambio, args) =>
                    {
                        var loc = args.Position;
                        lblLong.Text = loc.Longitude.ToString();
                        longi = double.Parse(lblLong.Text);
                        lblLat.Text = loc.Latitude.ToString();
                        latitud = double.Parse(lblLat.Text);

                    };

                }
               
            
            
            }
            else
            {
               
            }
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "No soportado en el dispositivo", "OK");
                return;
            }

            _mediaFile = await CrossMedia.Current.PickPhotoAsync();

            if (_mediaFile == null)
                return;

            filename.Source = ImageSource.FromStream(() =>
            {
                return _mediaFile.GetStream();
            });

            
        }
        public void cargarMapas()
        {
            spnDesastre.Items.Add("Mapa 1");
            spnDesastre.Items.Add("Mapa 2");
            spnDesastre.Items.Add("Mapa 3");
            spnDesastre.Items.Add("Mapa 4");
            spnDesastre.Items.Add("Mapa 5");
            spnDesastre.Items.Add("Mapa 6");
            spnDesastre.Items.Add("Mapa 7");
            spnDesastre.Items.Add("Mapa 8");
            spnDesastre.Items.Add("Mapa 9");
            spnDesastre.Items.Add("Mapa 10");
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            
         

            byte[] imageBytes;
            var FileImage = new Image();
            imageBytes = Convert.FromBase64String(logo.ToString());
           
            imagen2.SetImageBitmap(bitmap);
            byte[] bitmapData;

            using (var stream = new MemoryStream())
           {

               bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
              bitmapData = stream.ToArray();


           }
           
            var imagen = new ImagenS
            {
              
                Imagen = filename.ToString(),
              
             
            };
            WebClient client = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("Nombre", "prueba");
            parametros.Add("ImagenS", bitmapData.ToString());
            parametros.Add("Rucempresa", "124");
            parametros.Add("Mapa", spnDesastre.SelectedItem.ToString());



            client.UploadValues("http://192.168.1.109/CenturiosWS/public/api/mapas/nuevo1", "POST", parametros);
            await DisplayAlert("Confirmacion", "Mapa subido", "Aceptar");
            return;
            // byte[] bitmapData;

            //using (var stream = new MemoryStream())
            //{

            //    bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
            //    bitmapData = stream.ToArray();


            //}


            // await DisplayAlert("Confirmacion", "Mapa subido "+nombre.Text+"-"+_mediaFile +"-"+spnDesastre.SelectedItem, "Aceptar");

            //var jsonRequest = JsonConvert.SerializeObject(FileImage);
            //var content = new StringContent(jsonRequest, Encoding.UTF8, "TEXT/JSON");

            //string result;
            //try
            //{
            //    HttpClient client = new HttpClient();
            //    client.BaseAddress = new Uri("http://192.168.1.109");
            //    string url = string.Format("/CenturiosWS/public/api/mapa/nuevo1");
            //    var response = await client.PostAsync(url, content);
            //    result = response.Content.ReadAsStringAsync().Result;
            //}
            //catch (Exception)
            //{
            //    await DisplayAlert("Error", "No hay conexion, intente mas tarde", "Aceptar");
            //    return;

            //}
            //await DisplayAlert("Confirmacion", "Mapa subido", "Aceptar");

        }


    }
}