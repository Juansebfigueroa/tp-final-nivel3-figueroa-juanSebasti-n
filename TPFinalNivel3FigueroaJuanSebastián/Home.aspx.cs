using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3FigueroaJuanSebastián
{
	public partial class Home : System.Web.UI.Page
	{
		// creamos la property List<Articulos> de forma publica para poder usarla en el front.
		public List<Articulo> listaArticulos = new List<Articulo>();
		protected void Page_Load(object sender, EventArgs e)
		{
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            listaArticulos = articuloNegocio.listar();
        }
	}
}