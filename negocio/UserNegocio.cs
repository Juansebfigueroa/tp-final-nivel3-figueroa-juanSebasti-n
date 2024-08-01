﻿using System;
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
                    aux.Id = (int)acceso.Lector["Id"];
                    aux.Email = (string)acceso.Lector["email"];
                    aux.Pass = (string)acceso.Lector["pass"];
                    if (!(acceso.Lector["nombre"] is DBNull))
                        aux.Nombre = (string)acceso.Lector["nombre"];
                    if (!(acceso.Lector["apellido"] is DBNull))
                        aux.Apellido = (string)acceso.Lector["apellido"];
                    if (!(acceso.Lector["urlImagenPerfil"] is DBNull))
                        aux.UrlImagenPerfil = (string)acceso.Lector["urlImagenPerfil"];
                    if (!(acceso.Lector["admin"] is DBNull)) 
                        aux.Admin = (bool)acceso.Lector["admin"];

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

    }
}
