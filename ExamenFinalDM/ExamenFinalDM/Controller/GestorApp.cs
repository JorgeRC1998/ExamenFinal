using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using ExamenFinalDM.Model;
using RestSharp;

namespace ExamenFinalDM.Controller
{
    public class GestorApp
    {
        private static readonly HttpClient client = new HttpClient();

        public List<Movimiento> ConsultarMovimientos()
        {
            List<Movimiento> lista = new List<Movimiento>();
            int con = 0;
            var client = new RestClient($"http://aa8eca9e.ngrok.io/API_FINAL/index.php/select");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(response.Content);
                JObject jsonmovimientos = JObject.Parse("{datos:" + response.Content.ToString() + "}");
                Console.WriteLine(response.Content.ToString());

                foreach(object item in jsonmovimientos["datos"]["datos"]) {
                    Movimiento objMov = new Movimiento();
                    objMov.ID = Convert.ToInt32(jsonmovimientos["datos"]["datos"][con]["ID"]);
                    objMov.TIPO = Convert.ToString(jsonmovimientos["datos"]["datos"][con]["TIPO"]);
                    objMov.CONCEPTO = Convert.ToString(jsonmovimientos["datos"]["datos"][con]["CONCEPTO"]);
                    objMov.VALOR = Convert.ToDouble(jsonmovimientos["datos"]["datos"][con]["VALOR"]);
                    objMov.OBSERVACION = Convert.ToString(jsonmovimientos["datos"]["datos"][con]["OBSERVACION"]);
                    objMov.RECURRENTE = Convert.ToString(jsonmovimientos["datos"]["datos"][con]["RECURRENTE"]);
                    objMov.FECHA_REGISTRO = Convert.ToDateTime(jsonmovimientos["datos"]["datos"][con]["FECHA_REGISTRO"]);
                    objMov.EVIDENCIA = Convert.ToString(jsonmovimientos["datos"]["datos"][con]["EVIDENCIA"]);
                    con = con + 1;
                    lista.Add(objMov);
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
            return lista;
        }

        public async void insertarMovimiento(string tipo, string concepto, double valor, string observacion, 
            string recurrente, string evidencia)
        {
            DateTime fecha = DateTime.Now;
            string año = fecha.Year.ToString();
            string mes = fecha.Month.ToString();
            string dia = fecha.Day.ToString();
            decimal hora = (fecha.Hour - 1);
            string minuto = fecha.Minute.ToString();
            string segundo = fecha.Second.ToString();
            string consFecha = ($"{año}-{mes}-{dia}  {hora}:{minuto}:{segundo}");

            var values = new Dictionary<string, string>
            {
                {"TIPO", $"{tipo}" },
                {"CONCEPTO", $"{concepto}" },
                {"VALOR", $"{valor}" },
                {"OBSERVACION", $"{observacion}" },
                {"RECURRENTE", $"{recurrente}" },
                {"FECHA_REGISTRO", $"{consFecha}" },
                {"EVIDENCIA", $"{evidencia}" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://aa8eca9e.ngrok.io/API_FINAL/index.php/insertar", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }

        public void eliminarReg (int id)
        {
            var client = new RestClient("http://aa8eca9e.ngrok.io/API_FINAL/index.php/eliminar/" + id);
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);
        }

        public void eliminarRegCon (string concepto)
        {
            var client = new RestClient("http://aa8eca9e.ngrok.io/API_FINAL/index.php/eliminarCon/" + concepto);
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);
        }

        public async void actualizarReg(int id ,double valor, string observacion)
        {

            var values = new Dictionary<string, string>
            {
                {"VALOR", $"{valor}" },
                {"OBSERVACION", $"{observacion}" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PutAsync("http://aa8eca9e.ngrok.io/API_FINAL/index.php/actualizar/" + id, content);

            var responseString = await response.Content.ReadAsStringAsync();

        }

        public async void actualizarRegCon(string concepto, double valor, string observacion)
        {

            var values = new Dictionary<string, string>
            {
                {"VALOR", $"{valor}" },
                {"OBSERVACION", $"{observacion}" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PutAsync("http://aa8eca9e.ngrok.io/API_FINAL/index.php/actualizarCon/" + concepto, content);

            var responseString = await response.Content.ReadAsStringAsync();

        }
    }
}
