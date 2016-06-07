using Datos;
using Entidades;
using System.Data;

namespace Logica
{
    public class Usuarios_lg
    {
        private Usuarios_bd ubd;

        public DataTable Select()
        {
            ubd = new Usuarios_bd();
            return ubd.Select();
        }

        public void Insert(Usuarios u)
        {
            ubd = new Usuarios_bd();
            ubd.Insert(u);
        }

        public void Update(Usuarios u)
        {
            ubd = new Usuarios_bd();
            ubd.Update(u);
        }

        public void Delete(int id)
        {
            ubd = new Usuarios_bd();
            ubd.Delete(id);
        }
    }
}
