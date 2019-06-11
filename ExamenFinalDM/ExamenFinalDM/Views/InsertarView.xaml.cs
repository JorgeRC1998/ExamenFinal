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
    public partial class InsertarView : ContentPage
    {
        public string mensaje;
        public InsertarView()
        {
            InitializeComponent();
            mov.Items.Add("INGRESO");
            mov.Items.Add("GASTO");
            rec.Items.Add("SI");
            rec.Items.Add("NO");
        }

        private void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (validarFormulario() == true)
            {
                try
                {
                    GestorApp objGestor = new GestorApp();
                    objGestor.insertarMovimiento(mov.Items[mov.SelectedIndex], con.Items[con.SelectedIndex], Convert.ToDouble(val.Text), det.Text, rec.Items[rec.SelectedIndex], evi.Text);
                    mensaje = "Inserción en línea exitosa";
                    DisplayAlert("Ayuda", mensaje, "OK");
                }
                catch
                {

                }
                DisplayAlert("Exito", "Todos tus campos cumplieron las validaciones.", "OK");
            }
            else
            {
                DisplayAlert("Error", "Uno o varios campos estan vacios.", "OK");
            }
        }

        private void Mov_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Items.Clear();
            if (mov.Items[mov.SelectedIndex] == "INGRESO")
            {
                con.Items.Add("NOMINA EMPLEO 1");
                con.Items.Add("NOMINA EMPLEO 2");
                con.Items.Add("NOMINA EMPLEO 3");
                con.Items.Add("SUBSIDIO FAMILIAR");
                con.Items.Add("INTERESES SOBRE CAPITAL");
            }
            else if (mov.Items[mov.SelectedIndex] == "GASTO")
            {
                con.Items.Add("SERVICIOS PUBLICOS");
                con.Items.Add("SERVICIOS DE TELEFONIA");
                con.Items.Add("SERVICIOS DE INTERNET");
                con.Items.Add("SERVICIOS DE TV");
                con.Items.Add("ALIMENTACION");
            }
            else if (mov.Items[mov.SelectedIndex] == "")
            {

            }
        }

        private void BtnAgregarLocal_Clicked(object sender, EventArgs e)
        {
            if (validarFormulario() == true)
            {
                try
                {
                    Conexion.Instancia.addNew(mov.Items[mov.SelectedIndex], con.Items[con.SelectedIndex], Convert.ToDouble(val.Text), det.Text, rec.Items[rec.SelectedIndex], evi.Text);
                    mensaje = "Inserción local exitosa";
                    DisplayAlert("Ayuda", mensaje, "OK");
                }
                catch
                {

                }
                DisplayAlert("Exito", "Todos tus campos cumplieron las validaciones.", "OK");
            }
            else
            {
                DisplayAlert("Error", "Uno o varios campos estan vacios.", "OK");
            }          
        }

        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConsultarView());
        }

        private bool validarFormulario()
        {
            if (string.IsNullOrWhiteSpace(val.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(det.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(mov.Items[mov.SelectedIndex]))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(con.Items[con.SelectedIndex]))    
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(rec.Items[rec.SelectedIndex]))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(evi.Text))
            {
                return false;
            }
            return true;
        }
    }
}