using Datos;
using Entidades;
using System.Data;

namespace Logica
{
    public class Clientes_lg
    {
        private Clientes_bd cbd;
        private bool mysql;

        public Clientes_lg()
        {
            mysql = false;
        }

        public Clientes_lg(bool mysql)
        {
            this.mysql = mysql;
        }

        public DataTable Select(int? id_cliente = null, int? cedula = null)
        {
            cbd = new Clientes_bd(mysql);
            return cbd.Select(id_cliente,cedula);
        }

        public void Insert(Clientes c)
        {
            cbd = new Clientes_bd(mysql);
            cbd.Insert(c);
        }

        public void Update(Clientes c)
        {
            cbd = new Clientes_bd(mysql);
            cbd.Update(c);
        }

        public void Delete(int id)
        {
            cbd = new Clientes_bd(mysql);
            cbd.Delete(id);
        }
    }

}
