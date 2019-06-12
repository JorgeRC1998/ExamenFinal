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
            otroIn.Items.Add("SI");
            otroIn.Items.Add("NO");
            lblOTRO.IsVisible = false;
            entCon.IsVisible = false;
            recMes.IsVisible = false;
        }

        private void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            int recurrencia = 0;
            if (rec.Items[rec.SelectedIndex] == "NO")
            {
                if (otroIn.Items[otroIn.SelectedIndex] == "SI")
                {
                    if (validarFormulario() == true)
                    {
                        try
                        {
                            GestorApp objGestor = new GestorApp();
                            objGestor.insertarMovimiento(mov.Items[mov.SelectedIndex], entCon.Text, Convert.ToDouble(val.Text), det.Text, rec.Items[rec.SelectedIndex], evi.Text, recurrencia);
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
                else
                {
                    if (validarFormulario() == true)
                    {
                        try
                        {
                            GestorApp objGestor = new GestorApp();
                            objGestor.insertarMovimiento(mov.Items[mov.SelectedIndex], con.Items[con.SelectedIndex], Convert.ToDouble(val.Text), det.Text, rec.Items[rec.SelectedIndex], evi.Text, recurrencia);
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
            }else if(rec.Items[rec.SelectedIndex] == "SI")
            {
                int numMeses = Convert.ToInt32(recMes.Text);
                if (otroIn.Items[otroIn.SelectedIndex] == "SI")
                {
                    if (validarFormulario() == true)
                    {
                        try
                        {
                            GestorApp objGestor = new GestorApp();
                            objGestor.insertarMovimiento(mov.Items[mov.SelectedIndex], entCon.Text, Convert.ToDouble(val.Text), det.Text, rec.Items[rec.SelectedIndex], evi.Text, numMeses);
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
                else
                {
                    if (validarFormulario() == true)
                    {
                        try
                        {
                            GestorApp objGestor = new GestorApp();
                            objGestor.insertarMovimiento(mov.Items[mov.SelectedIndex], con.Items[con.SelectedIndex], Convert.ToDouble(val.Text), det.Text, rec.Items[rec.SelectedIndex], evi.Text, numMeses);
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
            int recurrencia = 0;
            if (rec.Items[rec.SelectedIndex] == "NO")
            {
                if (otroIn.Items[otroIn.SelectedIndex] == "NO")
                {
                    if (validarFormulario() == true)
                    {
                        try
                        {
                            Conexion.Instancia.addNew(mov.Items[mov.SelectedIndex], con.Items[con.SelectedIndex], Convert.ToDouble(val.Text), det.Text, rec.Items[rec.SelectedIndex], evi.Text, recurrencia);
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
                else if (otroIn.Items[otroIn.SelectedIndex] == "SI")
                {
                    if (validarFormulario() == true)
                    {
                        try
                        {
                            Conexion.Instancia.addNew(mov.Items[mov.SelectedIndex], entCon.Text, Convert.ToDouble(val.Text), det.Text, rec.Items[rec.SelectedIndex], evi.Text, recurrencia);
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
            }else if (rec.Items[rec.SelectedIndex] == "SI")
            {
                if (otroIn.Items[otroIn.SelectedIndex] == "NO")
                {
                    if (validarFormulario() == true)
                    {
                        try
                        {
                            Conexion.Instancia.addNew(mov.Items[mov.SelectedIndex], con.Items[con.SelectedIndex], Convert.ToDouble(val.Text), det.Text, rec.Items[rec.SelectedIndex], evi.Text, Convert.ToInt32(recMes.Text));
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
                else if (otroIn.Items[otroIn.SelectedIndex] == "SI")
                {
                    if (validarFormulario() == true)
                    {
                        try
                        {
                            Conexion.Instancia.addNew(mov.Items[mov.SelectedIndex], con.Items[con.SelectedIndex], Convert.ToDouble(val.Text), det.Text, rec.Items[rec.SelectedIndex], evi.Text, Convert.ToInt32(recMes.Text));
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
            if (otroIn.Items[otroIn.SelectedIndex] == "NO")
            {
                if (string.IsNullOrWhiteSpace(con.Items[con.SelectedIndex]))
                {
                    return false;
                }
            }
            else if(otroIn.Items[otroIn.SelectedIndex] == "SI")
            {
                if (string.IsNullOrWhiteSpace(otroIn.Items[otroIn.SelectedIndex]))
                {
                    return false;
                }
            }
            if (string.IsNullOrWhiteSpace(rec.Items[rec.SelectedIndex]))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(evi.Text))
            {
                return false;
            }
            if ((Convert.ToInt32(recMes.Text)>6))
            {
                return false;
            }
            return true;
        }

        private void OtroIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(otroIn.Items[otroIn.SelectedIndex] == "SI")
            {
                lblOTRO.IsVisible = true;
                entCon.IsVisible = true;
                lblcon.IsVisible = false;
                con.IsVisible = false;
            }
            else if(otroIn.Items[otroIn.SelectedIndex] == "NO")
            {
                lblcon.IsVisible = true;
                con.IsVisible = true;
                lblOTRO.IsVisible = false;
                entCon.IsVisible = false;
            }
        }

        private void Rec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rec.Items[rec.SelectedIndex] == "SI")
            {
                recMes.IsVisible = true;
            }else if(rec.Items[rec.SelectedIndex] == "NO")
            {
                recMes.IsVisible = false;
            }
        }
    }
}