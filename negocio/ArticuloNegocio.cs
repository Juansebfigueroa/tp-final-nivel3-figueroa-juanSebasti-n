using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesoDB;

namespace negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> listar()
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            AccesoDB accesoDB = new AccesoDB();
            try
            {
                string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdCategoria, C.Descripcion Categoria, A.IdMarca, M.Descripcion Marca, A.ImagenUrl, A.Precio  from articulos A, Categorias C, Marcas M where A.IdMarca = M.Id AND A.IdCategoria = C.Id";
                accesoDB.setearConsulta(consulta);
                accesoDB.ejecutarLectura();
                while(accesoDB.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    
                    aux.Id = (int)accesoDB.Lector["Id"];
                    aux.Codigo = (string)accesoDB.Lector["Codigo"];
                    aux.Nombre = (string)accesoDB.Lector["Nombre"];
                    aux.Descripcion = (string)accesoDB.Lector["Descripcion"];
                    
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)accesoDB.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)accesoDB.Lector["Categoria"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)accesoDB.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)accesoDB.Lector["Marca"];

                    aux.ImagenUrl = (string)accesoDB.Lector["ImagenUrl"];
                    aux.Precio = (decimal)accesoDB.Lector["Precio"];

                    //añadir el aux a la lista de articulos
                    listaArticulos.Add(aux);
                }
                return listaArticulos;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesoDB.cerrarConexion();
            }

        }

        public void agregarArticulo(Articulo articulo)
        {
            AccesoDB acceso = new AccesoDB();
            try
            {
                acceso.setearConsulta("insert into articulos(Codigo, Nombre, Descripcion, IdCategoria, IdMarca, ImagenUrl, Precio) values(@Codigo, @Nombre, @Descripcion, @IdCategoria, @IdMarca, @ImagenUrl, @Precio)");
                acceso.setearParametros("@Codigo", articulo.Codigo);
                acceso.setearParametros("@Nombre", articulo.Nombre);
                acceso.setearParametros("@Descripcion", articulo.Descripcion);
                acceso.setearParametros("@IdCategoria", articulo.Categoria.Id);
                acceso.setearParametros("@IdMarca", articulo.Marca.Id);
                acceso.setearParametros("@ImagenUrl", articulo.ImagenUrl);
                acceso.setearParametros("@Precio", articulo.Precio);
                acceso.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }

    }
}
