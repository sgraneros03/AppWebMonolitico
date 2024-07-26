using Microsoft.Data.SqlClient.Server;

namespace AppWebMonolitico.Models
{
    public class Clase
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; } 
        public decimal Pago { get; set; }

    }
}
