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
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            txtId.Enabled = false;
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {
                if (!IsPostBack)
                {
                    ddlCategoria.DataSource = categoriaNegocio.listar();
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = marcaNegocio.listar();
                    ddlMarca.DataValueField= "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articulo = new ArticuloNegocio();
            if (Session["articulo"] is null)
            {
                Articulo aux = new Articulo();

                try
                {
                    //hay que hacer las validaciones acá
                    aux.Codigo = txtCodigo.Text;
                    aux.Nombre = txtNombre.Text;
                    aux.Descripcion = txtDescripcion.Text;
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                    aux.Marca = new Marca();
                    aux.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                    aux.ImagenUrl = txtImagenUrl.Text;
                    aux.Precio = int.Parse(txtPrecio.Text);

                    articulo.agregarArticulo(aux);

                    //ver alguna forma de dar confirmacion de agregado exitoso
                    //Esta funciona, pero si pongo el redirect deja de mostrarse
                    //ClientScript.RegisterStartupScript(this.GetType(), "Exito", "alert('Se agregó exitosamente el producto.');", true);
                    Response.Redirect("ListadoArticulos.aspx", false);
                }
                catch (Exception ex)
                {

                    throw ex;
                }

                
            } 
        }
    }
}