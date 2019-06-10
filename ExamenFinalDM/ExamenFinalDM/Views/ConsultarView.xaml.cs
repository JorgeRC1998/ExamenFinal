using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ExamenFinalDM.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExamenFinalDM.Controller;

namespace ExamenFinalDM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarView : ContentPage
    {
        public string mensaje;
        public ConsultarView()
        {
            InitializeComponent();
        }

        private void BtnConONLINE_Clicked(object sender, EventArgs e)
        {
            GestorApp objGestor = new GestorApp();
            try
            {
                pinchelista.ItemsSource = objGestor.ConsultarMovimientos();
                mensaje = "Consulta en línea Exitosa!";
                DisplayAlert("Ayuda", mensaje, "OK");
            }
            catch { }
            
        }

        private void BtnConOFFLINE_Clicked(object sender, EventArgs e)
        {
            string num = Conexion.Instancia.cont().ToString();
            mensaje = "Consulta local Exitosa!";
            DisplayAlert("Ayuda", mensaje, "OK");

            var allMovimientos = Conexion.Instancia.GetAllReg();
            pinchelista.ItemsSource = allMovimientos;
        }

        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarView());
        }
    }
}