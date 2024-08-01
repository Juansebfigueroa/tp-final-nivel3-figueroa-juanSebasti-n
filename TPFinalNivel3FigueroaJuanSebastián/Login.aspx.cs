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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            UserNegocio userNegocio = new UserNegocio();
            User user = new User();
            try
            {
                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;
                if(userNegocio.Login(user))
                {
                    Session.Add("usuario", user);
                    Response.Redirect("Home.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o contraseña incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }

        }
        
    }
}