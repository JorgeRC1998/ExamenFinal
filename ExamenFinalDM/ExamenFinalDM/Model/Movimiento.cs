using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ExamenFinalDM.Model
{
    [Table("registro")]
    public class Movimiento
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TIPO { get; set; }
        public string CONCEPTO { get; set; }
        public double VALOR { get; set; }
        public string OBSERVACION { get; set; }
        public string RECURRENTE { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public string EVIDENCIA { get; set; }
    }
}
