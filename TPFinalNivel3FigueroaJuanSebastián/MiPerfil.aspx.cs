using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPFinalNivel3FigueroaJuanSebastián
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                if (!IsPostBack) 
                { 
                    User usuario = (User)Session["usuario"];
                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;
                    txtEmail.Text = usuario.Email;
                    txtUrlImagen.Text = usuario.UrlImagenPerfil;
                    imgPerfil.ImageUrl = usuario.UrlImagenPerfil;
                    lblModificarDatos.Visible = false;
                }
            }
        }

        protected void btnModificarDatos_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                User usuario = (User)Session["usuario"];
                UserNegocio userNegocio = new UserNegocio();
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.UrlImagenPerfil = txtUrlImagen.Text;
                userNegocio.ModificarDatos(usuario);
                lblModificarDatos.Visible = true;
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgPerfil.ImageUrl = txtUrlImagen.Text;
        }
    }
}