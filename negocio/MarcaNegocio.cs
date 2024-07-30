using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesoDB;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> listaMarcas = new List<Marca>();
            AccesoDB accesoDB = new AccesoDB();
            try
            {
                accesoDB.setearConsulta("select Id, Descripcion from MARCAS");
                accesoDB.ejecutarLectura();
                while(accesoDB.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)accesoDB.Lector["Id"];
                    aux.Descripcion = (string)accesoDB.Lector["Descripcion"];
                    listaMarcas.Add(aux);
                }
                return listaMarcas;

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
