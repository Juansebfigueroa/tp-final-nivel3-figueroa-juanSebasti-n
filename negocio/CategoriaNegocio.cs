using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoDB;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> listaCategorias = new List<Categoria> ();
            AccesoDB accesoDB = new AccesoDB();

            try
            {
                accesoDB.setearConsulta("select Id, Descripcion from CATEGORIAS");
                accesoDB.ejecutarLectura();
                while (accesoDB.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)accesoDB.Lector["Id"];
                    aux.Descripcion = (string)accesoDB.Lector["Descripcion"];
                    listaCategorias.Add(aux);
                }
                return listaCategorias;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDB.cerrarConexion();
            }
        }
    }
}
