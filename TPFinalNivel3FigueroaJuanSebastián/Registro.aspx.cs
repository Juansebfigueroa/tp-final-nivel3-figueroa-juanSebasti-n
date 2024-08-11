using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TPFinalNivel3FigueroaJuanSebastián
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                User usuario = new User();
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;
                UserNegocio userNegocio = new UserNegocio();
                //EL metodo login lo usamos para validar que no haya otro user con los mismos datos registrados 
                if (userNegocio.Login(usuario))
                {
                    Session.Add("error", "El usuario ya está registrado. Ingrese mediante la página de Login");
                    Response.Redirect("Error.aspx", false);
                }
                userNegocio.AgregarUsuario(usuario);
                Session.Add("usuario", usuario);
                Response.Redirect("MiPerfil.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}