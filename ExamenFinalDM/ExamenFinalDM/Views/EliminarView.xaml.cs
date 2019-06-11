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
            if (validarId() == true)
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
                DisplayAlert("Exito", "Campos validados correctamente.", "OK");
            }
            else
            {
                DisplayAlert("Error", "Falta el parametro id.", "OK");
            }
        }

        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActualizaView());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (validarConcepto() == true)
            {
                try
                {
                    GestorApp objGestor = new GestorApp();
                    string concept = conAE.Text;
                    objGestor.eliminarRegCon(concept);
                    mensaje = "Registros en línea borrados satisfactoriamente!";
                    DisplayAlert("Ayuda", mensaje, "OK");
                }
                catch
                {
                    
                }
                DisplayAlert("Exito", "Campos validados correctamente.", "OK");
            }
            else
            {
                DisplayAlert("Error", "Falta el parametro Concepto.", "OK");
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            if (validarId() == true)
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
                DisplayAlert("Exito", "Campos validados correctamente.", "OK");
            }
            else
            {
                DisplayAlert("Error", "Falta el parametro id.", "OK");
            }
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            if (validarConcepto() == true)
            {
                Conexion.Instancia.DeleteByName(conAE.Text);
                mensaje = "Eliminado local exitoso!";
                DisplayAlert("Ayuda", mensaje, "OK");
                DisplayAlert("Exito", "Campos validados correctamente.", "OK");
            }
            else
            {
                DisplayAlert("Error", "Falta el parametro concepto.", "OK");
            }
        }

        private bool validarId()
        {
            if (string.IsNullOrWhiteSpace(idAE.Text))
            {
                return false;
            }
            return true;
        }

        private bool validarConcepto()
        {
            if (string.IsNullOrWhiteSpace(conAE.Text))
            {
                return false;
            }
            return true;
        }
    }
}