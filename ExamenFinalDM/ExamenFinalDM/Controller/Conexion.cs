using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;
using ExamenFinalDM.Model;

namespace ExamenFinalDM.Controller
{
    public class Conexion
    {
        private SQLiteConnection con;

        private static Conexion instancia;

        public static Conexion Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar al inicializador");
                return instancia;
            }
        }

        public static void Inicializador(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException();
            if (instancia != null)
                instancia.con.Close();

            instancia = new Conexion(filename);
        }

        private Conexion(string dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Movimiento>();
        }

        public string EstadoDeMensaje;

        public void addNew(string mov, string cto, double val, string obs, string rec, string evi, int recurrencia)
        {
            int result = 0;
            DateTime fecha = DateTime.Now;
            string año = fecha.Year.ToString();
            string mes = fecha.Month.ToString();
            string dia = fecha.Day.ToString();
            decimal hora = (fecha.Hour - 1);
            string minuto = fecha.Minute.ToString();
            string segundo = fecha.Second.ToString();
            string consFecha = ($"{año}-{mes}-{dia}  {hora}:{minuto}:{segundo}");

            if (recurrencia > 0)
            {
                for (int i = 0; i < recurrencia; i++)
                {
                    int a = Convert.ToInt32(mes) + i;
                    consFecha = ($"{año}-{dia}-{(Convert.ToString(a))}  {hora}:{minuto}:{segundo}");
                    try
                    {
                        result = con.Insert(new Movimiento()
                        {
                            TIPO = mov,
                            CONCEPTO = cto,
                            VALOR = Convert.ToDouble(val),
                            OBSERVACION = obs,
                            RECURRENTE = rec,
                            FECHA_REGISTRO = Convert.ToDateTime(consFecha),
                            EVIDENCIA = evi
                        });

                        EstadoDeMensaje = string.Format("Cantidad de filas afectadas: {0}", result);

                    }
                    catch (Exception e)
                    {
                        EstadoDeMensaje = e.Message;
                    }
                }
            }

            else
            {
                try
                {
                    result = con.Insert(new Movimiento()
                    {
                        TIPO = mov,
                        CONCEPTO = cto,
                        VALOR = Convert.ToDouble(val),
                        OBSERVACION = obs,
                        RECURRENTE = rec,
                        FECHA_REGISTRO = Convert.ToDateTime(consFecha),
                        EVIDENCIA = evi
                    });

                    EstadoDeMensaje = string.Format("Cantidad de filas afectadas: {0}", result);

                }
                catch (Exception e)
                {
                    EstadoDeMensaje = e.Message;
                }
            }
        }

        public IEnumerable<Movimiento> GetAllReg()
        {
            try
            {
                return con.Table<Movimiento>();
            }
            catch (Exception e)
            {
                EstadoDeMensaje = e.Message;
            }
            return Enumerable.Empty<Movimiento>();
        }

        public int cont()
        {
            int numRows = con.Table<Movimiento>().Count();
            return numRows;
        }

        public IEnumerable<Movimiento> DeleteByID(int id)
        {
            con.Table<Movimiento>().Delete(p => p.ID == id);
            //return Conexion.instancia.con.Query<Registro>(query);
            return Enumerable.Empty<Movimiento>();
        }

        public IEnumerable<Movimiento> DeleteByName(string nombre)
        {
            con.Table<Movimiento>().Delete(p => p.CONCEPTO == nombre);
            //return Conexion.instancia.con.Query<Registro>(query);
            return Enumerable.Empty<Movimiento>();
        }

        public IEnumerable<Movimiento> Update(string movimiento, string nombre, double valor, string observacion, DateTime fecha, string recurrencia)
        {
            con.Table<Movimiento>().Select(p => p.CONCEPTO == nombre);
            //var actualizar = con.Query<Registro>("SELECT * FROM Registro WHERE CONCEPTO = ?", nombre);
            var actualizar = con.Query<Movimiento>("UPDATE Registro SET MOVIMIENTO = ?, VALOR = ?, OBSERVACION = ?, FECHA = ?, RECURRENCIA = ? WHERE CONCEPTO = ?",
                movimiento, valor, observacion, fecha, recurrencia, nombre);
            foreach (var s in actualizar)
            {

                Console.WriteLine("a " + s.FECHA_REGISTRO);
            }
            //con.Table<Registro>().Delete(p => p.CONCEPTO == nombre);
            //return Conexion.instancia.con.Query<Registro>(query);
            return Enumerable.Empty<Movimiento>();
        }

        public string[] Cargar(string nombre)
        {
            string[] datos = new string[10];
            var actualizar = con.Query<Movimiento>("SELECT * FROM Registro WHERE CONCEPTO = ?", nombre);
            foreach (var s in actualizar)
            {
                datos[0] = s.TIPO;
                datos[1] = s.CONCEPTO;
                datos[2] = s.VALOR.ToString();
                datos[3] = s.OBSERVACION;
                datos[4] = s.RECURRENTE;
                datos[5] = s.FECHA_REGISTRO.ToString();
                datos[6] = s.EVIDENCIA;
            }
            return datos;
        }
    }
}
