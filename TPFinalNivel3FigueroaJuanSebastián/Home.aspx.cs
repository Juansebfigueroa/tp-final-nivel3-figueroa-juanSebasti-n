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
            //para que funcione el filtro hacemos la carga solo al comienzo y no en los postback
            if (!IsPostBack)
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                listaArticulos = articuloNegocio.listar();

                ////Guardamos esa listaArticulos en session para manejarla mejor
                //Session.Add("listaArticulos", listaArticulos);

                //Carga de los ddl para el filtro
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                ddlCategoria.DataSource = categoriaNegocio.listar();
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();
                //Agregamos la opcion "todas"
                ddlCategoria.Items.Insert(0, new ListItem("Todas", "0"));

                ddlMarca.DataSource = marcaNegocio.listar();
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataBind();
                //Agregamos la opcion "todas"
                ddlMarca.Items.Insert(0, new ListItem("Todas", "0"));
            }
        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnReestablecer_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            ddlCategoria.SelectedIndex = 0;
            ddlMarca.SelectedIndex = 0;
            txtPrecioMaximo.Text = string.Empty;
            txtPrecioMinimo.Text = string.Empty;
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            listaArticulos = articuloNegocio.listar();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                //agrego el nombre al filtro que me olvidé
                string nombre = txtNombre.Text;
                string categoria = ddlCategoria.SelectedItem.Text;
                string marca = ddlMarca.SelectedItem.Text;
                decimal precioMin = 0;
                decimal precioMax = 0;
                if (txtPrecioMinimo.Text != "")
                {
                    precioMin = decimal.Parse((txtPrecioMinimo.Text.ToString()));
                }
                if (txtPrecioMaximo.Text != "")
                {
                    precioMax = decimal.Parse((txtPrecioMaximo.Text.ToString()));
                }
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                List<Articulo> listaFiltrada = articuloNegocio.filtrar(nombre, categoria, marca, precioMin, precioMax);
               
                //le cargamos a la property listaFiltrada que usan las cards de home desde el front. 
                listaArticulos = listaFiltrada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void AgregarAFavoritos_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("Error", "Debes ingresar con tu usuario para agregar el artículo a tus favoritos");
                Response.Redirect("Error.aspx");
            }
            
            //Dado que este evento puede ser disparado por varios btn, debemos capturar el ID del articulo de la tarjeta que lo disparó
            Button btnFavorito = (Button)sender;
            //El btnFavorito tiene asociado un CommandArgument que le indicamos en el Front.
            //Este CommandArgument contiene el Id del articulo que esta listado en la tarjeta.
            int IdArticulo = int.Parse(btnFavorito.CommandArgument);
            User usuario = (User)Session["usuario"];
        }
    }
}