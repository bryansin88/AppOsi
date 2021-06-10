using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppOsi.View;
using AppOsi.vista_comunicacion;

namespace AppOsi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Audios());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
