using Datos;
using Entidades;
using System.Data;

namespace Logica
{
    public class Usuarios_lg
    {
        private Usuarios_bd ubd;
        private bool mysql;

        public Usuarios_lg()
        {
            mysql = false;
        }

        public Usuarios_lg(bool mysql)
        {
            this.mysql = mysql;
        }

        public DataTable Select()
        {
            ubd = new Usuarios_bd(mysql);
            return ubd.Select();
        }

        public void Insert(Usuarios u)
        {
            ubd = new Usuarios_bd(mysql);
            ubd.Insert(u);
        }

        public void Update(Usuarios u)
        {
            ubd = new Usuarios_bd(mysql);
            ubd.Update(u);
        }

        public void Delete(int id)
        {
            ubd = new Usuarios_bd(mysql);
            ubd.Delete(id);
        }
    }
}
