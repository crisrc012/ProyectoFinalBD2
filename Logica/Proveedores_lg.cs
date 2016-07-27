using Datos;
using System.Data;

namespace Logica
{
    public class Proveedores_lg
    {
        private Proveedores_bd cbd;
        private bool mysql;

        public Proveedores_lg()
        {
            mysql = false;
        }

        public Proveedores_lg(bool mysql)
        {
            this.mysql = mysql;
        }

        public DataTable Select(int? id_proveedor = null, int? cedula = null, int? id_compania = null, string cargo = null)
        {
            cbd = new Proveedores_bd(mysql);
            return cbd.Select(id_proveedor, cedula, id_compania, cargo);
        }
    }
}
