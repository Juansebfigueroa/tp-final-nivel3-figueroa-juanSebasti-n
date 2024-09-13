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
    public partial class ListadoArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(cbFiltroAvanzado.Checked)
                txtFiltro.Enabled = false;
            else
                txtFiltro.Enabled = true;
            if (!(Seguridad.isAdmin((dominio.User)Session["usuario"])))
            {
                Session.Add("error", "Debes ser admin para ver la lista de productos");
                Response.Redirect("error.aspx", false);
            }
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            dgvArticulos.DataSource = articuloNegocio.listar();
            dgvArticulos.DataBind();
            //carga de los ddl para el filtrado
            CategoriaNegocio categoriaNeg = new CategoriaNegocio();
            MarcaNegocio marcaNeg = new MarcaNegocio();

            if (!(IsPostBack))
            {
                ddlCategoria.DataSource = categoriaNeg.listar();
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();

                //Agregamos la opcion "Todas" a los dll para que el filtro no se aplique. El metodo Insert() espera un indice y un objeto de tipo ListItem, entonces instanciamos
                //dicho objeto, y le pasamos por constructor un text y un valor. 
                ddlCategoria.Items.Insert(0, new ListItem("Todas", "0"));

                ddlMarca.DataSource = marcaNeg.listar();
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataBind();

                //Hacemos lo mismo para el ddlMarca
                ddlMarca.Items.Insert(0, new ListItem("Todas", "0"));
            }
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

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            if(txtFiltro.Text.Length > 2)
            {
                try
                {
                    List<Articulo> listaFiltrada = articuloNegocio.filtroRapido(txtFiltro.Text);
                    dgvArticulos.DataSource = listaFiltrada;
                    dgvArticulos.DataBind();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }else if (txtFiltro.Text.Length == 0)
            {
                List<Articulo> listaFiltrada = articuloNegocio.listar();
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.DataBind();
            }
            if (cbFiltroAvanzado.Checked)
            {
                txtFiltro.Text = "";
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
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
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnReestablecer_Click(object sender, EventArgs e)
        {
            ddlCategoria.SelectedIndex = 0;
            ddlMarca.SelectedIndex = 0;
            txtPrecioMaximo.Text = string.Empty;
            txtPrecioMinimo.Text = string.Empty;
        }
    }
}