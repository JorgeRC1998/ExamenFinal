using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenFinalDM.Model;
using ExamenFinalDM.Controller;
using ExamenFinalDM.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenFinalDM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActualizaView : ContentPage
	{
        public string mensaje;
		public ActualizaView ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                GestorApp objGestor = new GestorApp();
                double value = Convert.ToDouble(val.Text);
                string obser = det.Text;
                int id = Convert.ToInt32(idAE.Text);
                objGestor.actualizarReg(id, value, obser);
                mensaje = "Registro actualizado satisfactoriamente!";
                DisplayAlert("Ayuda", mensaje, "OK");
            }
            catch
            {

            }
        }

        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                GestorApp objGestor = new GestorApp();
                double value = Convert.ToDouble(val.Text);
                string obser = det.Text;
                string concepto = conAE.Text;
                objGestor.actualizarRegCon(Convert.ToString(concepto), value, obser);
                mensaje = "Registros actualizados satisfactoriamente!";
                DisplayAlert("Ayuda", mensaje, "OK");
            }
            catch
            {

            }
        }
    }
}