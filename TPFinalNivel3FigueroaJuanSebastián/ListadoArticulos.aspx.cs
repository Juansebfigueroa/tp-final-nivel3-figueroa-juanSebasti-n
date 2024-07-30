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
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            dgvArticulos.DataSource = articuloNegocio.listar();
            dgvArticulos.DataBind();
        }
    }
}