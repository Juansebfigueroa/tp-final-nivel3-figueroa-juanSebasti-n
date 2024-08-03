using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TPFinalNivel3FigueroaJuanSebastián
{
    public partial class ListadoArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Seguridad.isAdmin((dominio.User)Session["usuario"])))
            {
                Session.Add("error", "Debes ser admin para ver la lista de productos");
                Response.Redirect("error.aspx", false);
            }
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            dgvArticulos.DataSource = articuloNegocio.listar();
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Se genera este evento a partir de la dgvArticulos, donde capturamos el DataKeyNames tambien
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            //Redirigimos al formulario, pero pasando por URL el id
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanged(object sender, EventArgs e)
        {
            //Aca me confundi y genere este evento. En la DGV tambien
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();

        }
    }
}