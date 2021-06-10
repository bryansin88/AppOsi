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

namespace AppOsi.vista_comunicacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Alerta : ContentPage
    {
        public Alerta()
        {
            InitializeComponent();
            DateTime hoy = DateTime.Now;

            string fecha = hoy.ToString("dd/MM/yyyy");

            string hora = DateTime.Now.ToString("hh:MM:ss");
           
            lblTiempo.Text = hora;
            lblFecha.Text = fecha;

            spnDesastre.Items.Add("opcion1");
            spnDesastre.Items.Add("opcion2");
            spnDesastre.Items.Add("opcion3");
            spnDesastre.Items.Add("opcion4");

            spnTipoDesastres.Items.Add("Fuego");
            spnTipoDesastres.Items.Add("Temblor");
            spnTipoDesastres.Items.Add("Derrumbe");

        }
    }
}