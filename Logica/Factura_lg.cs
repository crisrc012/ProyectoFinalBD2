using Datos;
using System.Data;

namespace Logica
{
    public class Factura_lg
    {
        private Facturas_bd cbd;
        private bool mysql;

        public Factura_lg()
        {
            mysql = false;
        }

        public Factura_lg(bool mysql)
        {
            this.mysql = mysql;
        }

        public DataTable Select(int? id_factura = null, int? id_cliente = null, int? cedula = null)
        {
            cbd = new Facturas_bd(mysql);
            return cbd.Select(id_factura, id_cliente, cedula);
        }
    }
}
