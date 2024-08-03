using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TPFinalNivel3FigueroaJuanSebastián
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
            
            //agrgamos unas excepciones a la carga de paginas porque, sino, se hace un loop
            //y tira error al tratar de validar si hay un usuario en sessiony quiere redirigir a una pagina en donde vuelve a validar. 
            
            if(!(Page is Login || Page is Registro || Page is Home || Page is Error || Page is FormularioArticulo && (Request.QueryString["id"] != null)))
                if (!Seguridad.sesionActiva(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    User usuario = (User)Session["usuario"];
                    lblUser.Text = usuario.Nombre;
                    if(usuario.UrlImagenPerfil != null)
                        imgAvatar.ImageUrl = usuario.UrlImagenPerfil;
                }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Home.aspx");
        }
    }
}