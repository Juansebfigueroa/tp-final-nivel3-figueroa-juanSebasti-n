using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    
    //la clase public y static, lo que hace que no se necesiten isntanciar (no se pueda) pero si permite usar sus metodos recurriendo a la CLASE.metodo()
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            User usuario = user != null ? (User)user : null;
            if (usuario != null)
                return true; 
            else  
                return false;
        }

        public static bool isAdmin(User user)
        {
            if (Seguridad.sesionActiva(user))
            {
                if(user.Admin)
                    return true;
                else 
                    return false;
            } 
            else
                return false; 
        }
    }
}
