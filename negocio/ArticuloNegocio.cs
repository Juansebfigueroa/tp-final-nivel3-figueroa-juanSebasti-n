using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesoDB;
using System.Linq.Expressions;

namespace negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> listar(string id = "")
        {
            //le agregamos que reciba por parametro un id y le asignamos vacio en caso de que no traiga un id
            List<Articulo> listaArticulos = new List<Articulo>();
            AccesoDB accesoDB = new AccesoDB();
            try
            {
                string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdCategoria, C.Descripcion Categoria, A.IdMarca, M.Descripcion Marca, A.ImagenUrl, A.Precio  from articulos A, Categorias C, Marcas M where A.IdMarca = M.Id AND A.IdCategoria = C.Id";
                //Modificamos la consulta en caso de que el metodo traiga un Id. Ahora al ejecutar la consulta la lista nos traerá un solo registro. 
                if (id != "")
                    consulta += " AND A.Id = " + id;
                
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

        public void modificarArticulo(Articulo articulo)
        {
            AccesoDB acceso = new AccesoDB();
            try
            {
                acceso.setearConsulta("update articulos set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio where Id = @Id");
                acceso.setearParametros("@Codigo", articulo.Codigo);
                acceso.setearParametros("@Nombre", articulo.Nombre);
                acceso.setearParametros("@Descripcion", articulo.Descripcion);
                acceso.setearParametros("@IdMarca", articulo.Marca.Id);
                acceso.setearParametros("@IdCategoria", articulo.Categoria.Id);
                acceso.setearParametros("@ImagenUrl", articulo.ImagenUrl);
                acceso.setearParametros("@Precio", articulo.Precio);
                acceso.setearParametros("@Id", articulo.Id);

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

        public void eliminarFisico(int id)
        {
            //trabajamos con eliminacion fisica para la app solamente porque el modelo de relacion entidad no trabaja con restricciones, y la eliminacion de articulos no deja a ningun 
            //registro de ninguna entidad como huerfana. Además, la DB no cuenta con un campo para indicar la inactivacion de un registro.
            AccesoDB acceso = new AccesoDB();
            try
            {
                acceso.setearConsulta("delete from Articulos where Id = @Id");
                acceso.setearParametros("@Id", id);

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

        public List<Articulo> filtrar(string nombre, string categoria, string marca, decimal precioMin = 0, decimal precioMax = 0)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();
            AccesoDB accesoDB = new AccesoDB();
            string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdCategoria, C.Descripcion Categoria, A.IdMarca, M.Descripcion Marca, A.ImagenUrl, A.Precio from articulos A, Categorias C, Marcas M where A.IdMarca = M.Id AND A.IdCategoria = C.Id";

            //los condicionales los establecemos con lo que recibimos por parametros.
            //Validamos que se haya elegido una categoria especifica o introducido un precio distinto a 0 para aplicar el filtro a la consulta
            try
            {
                if (nombre != "")
                {
                    consulta += " AND A.Nombre like '%" + nombre + "%'";
                }
                if (categoria != "Todas")
                {
                    consulta += " AND C.Descripcion = ";
                    switch (categoria)
                    {
                        case "Celulares":
                            consulta += "'Celulares'";
                            break;
                        case "Televisores":
                            consulta += "'Televisores'";
                            break;
                        case "Media":
                            consulta += "'Media'";
                            break;
                        case "Audio":
                            consulta += "'Audio'";
                            break;
                        default:
                            break;
                    }
                }
                if (marca != "Todas")
                {
                    consulta += " AND M.Descripcion = ";
                    switch (marca)
                    {
                        case "Samsung":
                            consulta += "'Samsung'";
                            break;
                        case "Apple":
                            consulta += "'Apple'";
                            break;
                        case "Sony":
                            consulta += "'Sony'";
                            break;
                        case "Huawei":
                            consulta += "'Huawei'";
                            break;
                        case "Motorola":
                            consulta += "'Motorola'";
                            break;
                        default:
                            break;
                    }
                }
                if (precioMin != 0 &&  precioMax == 0)
                {
                    consulta += " AND A.Precio >= " + precioMin;
                }
                if (precioMin != 0 && precioMax != 0)
                {
                    consulta += " AND A.Precio BETWEEN " + precioMin + " AND " + precioMax;
                }
                if(precioMin == 0 && precioMax != 0)
                {
                    consulta += " AND A.Precio <= " + precioMax;
                }
            
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

                    //añadir el aux a la lista filtrada
                    listaFiltrada.Add(aux);
                }
                return listaFiltrada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtroRapido(string nombre)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();
            AccesoDB accesoDB = new AccesoDB();
            string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdCategoria, C.Descripcion Categoria, A.IdMarca, M.Descripcion Marca, A.ImagenUrl, A.Precio from articulos A, Categorias C, Marcas M where A.IdMarca = M.Id AND A.IdCategoria = C.Id";

            if(nombre != "")
            {
                consulta += " AND A.Nombre like '%" + nombre + "%'";
            }

            try
            {
                accesoDB.setearConsulta(consulta);
                accesoDB.ejecutarLectura();
                while (accesoDB.Lector.Read())
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

                    //añadir el aux a la lista filtrada
                    listaFiltrada.Add(aux);
                }
                return listaFiltrada;
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
    }
}
