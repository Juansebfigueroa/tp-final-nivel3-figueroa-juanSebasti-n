using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesoDB;

namespace negocio
{
    public class UserNegocio
    {

        public bool Login(User user)
        {
            AccesoDB acceso = new AccesoDB();
            try
            {
                acceso.setearConsulta("select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from users where email = @Email AND pass = @Pass");
                acceso.setearParametros("@Email", user.Email);
                acceso.setearParametros("@Pass", user.Pass);
                acceso.ejecutarLectura();

                //usamos un if en vez de un while, porque solo nos va a retornar un registro teoricamente. 
                if(acceso.Lector.Read())
                {
                    //public int Id { get; set; }
                    //public string Email { get; set; }
                    //public string Pass { get; set; }
                    //public string Nombre { get; set; }
                    //public string Apellido { get; set; }
                    //public string UrlImagenPerfil { get; set; }
                    //public bool Admin { get; set; }

                    User aux = new User();
                    user.Id = (int)acceso.Lector["Id"];
                    user.Email = (string)acceso.Lector["email"];
                    user.Pass = (string)acceso.Lector["pass"];
                    if (!(acceso.Lector["nombre"] is DBNull))
                        user.Nombre = (string)acceso.Lector["nombre"];
                    if (!(acceso.Lector["apellido"] is DBNull))
                        user.Apellido = (string)acceso.Lector["apellido"];
                    if (!(acceso.Lector["urlImagenPerfil"] is DBNull))
                        user.UrlImagenPerfil = (string)acceso.Lector["urlImagenPerfil"];
                    if (!(acceso.Lector["admin"] is DBNull)) 
                        user.Admin = (bool)acceso.Lector["admin"];

                    return true;
                }
                else
                {
                    return false;
                }
                
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

        public void ModificarDatos(User usuario)
        {
            AccesoDB accesoDB = new AccesoDB();
            try
            {
                accesoDB.setearConsulta("update Users set nombre = @Nombre, apellido = @Apellido, urlImagenPerfil = @UrlImagen where Id = @Id");
                accesoDB.setearParametros("@Nombre", usuario.Nombre);
                accesoDB.setearParametros("@Apellido", usuario.Apellido);
                accesoDB.setearParametros("@UrlImagen", usuario.UrlImagenPerfil);
                accesoDB.setearParametros("@Id", usuario.Id);
                accesoDB.ejecutarAccion();
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
