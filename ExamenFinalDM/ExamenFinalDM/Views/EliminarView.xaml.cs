using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenFinalDM.Model;
using ExamenFinalDM.Controller;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenFinalDM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EliminarView : ContentPage
	{
        public string mensaje;
		public EliminarView ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                GestorApp objGestor = new GestorApp();
                int id = Convert.ToInt32(idAE.Text);
                objGestor.eliminarReg(id);
                mensaje = "Registro en línea borrado satisfactoriamente!";
                DisplayAlert("Ayuda", mensaje, "OK");
            }
            catch
            {

            }
        }

        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActualizaView());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                GestorApp objGestor = new GestorApp();
                string concept =conAE.Text;
                objGestor.eliminarRegCon(concept);
                mensaje = "Registros en línea borrados satisfactoriamente!";
                DisplayAlert("Ayuda", mensaje, "OK");
            }
            catch
            {

            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            try
            {
                Conexion.Instancia.DeleteByID(Convert.ToInt32(idAE.Text));
                mensaje = "Eliminado local exitoso!";
                DisplayAlert("Ayuda", mensaje, "OK");
            }
            catch
            {

            }
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            Conexion.Instancia.DeleteByName(conAE.Text);
            mensaje = "Eliminado local exitoso!";
            DisplayAlert("Ayuda", mensaje, "OK");
        }
    }
}