using Android;
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

namespace AppOsi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubirMapaPage : ContentPage
    {
        double latitud; 
            double longi;
        private MediaFile _mediaFile;

        
        public SubirMapaPage()
        {
            InitializeComponent();
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

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

      
    }
}