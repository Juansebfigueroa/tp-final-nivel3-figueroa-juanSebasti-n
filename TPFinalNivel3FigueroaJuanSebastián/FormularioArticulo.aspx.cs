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
        public bool ConfirmarEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            txtId.Enabled = false;
            //Carga de los DropDownList si no es postBack
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
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            //configuracion para obtener el articulo si se paso un Id por URL mediante el metodo de la DGV 
            //Dado que cuando damos aceptar, sucede el postback, se actualizan los campos con los que tiene guardado en la DB, por lo que tenemos que tener en cuenta tambien el postback
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                //Si la request que nos llega de otra pagina contiene el id
                ArticuloNegocio articulo = new ArticuloNegocio();
                List<Articulo> lista = new List<Articulo>();
                //creamos una lista, a la cual la cargaremos con una lista con un solo articulo mediante el metodo listar(pasandole el id)
                lista = articulo.listar(Request.QueryString["id"].ToString());
                //asignamos el unico articulo de dicha lista a un objeto Articulo
                Articulo seleccionado = lista[0];

                //Precarga de los datos si se esta viendo el detalle de un Articulo
                //Como tenemos Id tambien lo cargamos
                txtId.Text = seleccionado.Id.ToString();
                txtCodigo.Text = seleccionado.Codigo;
                txtNombre.Text = seleccionado.Nombre;
                txtDescripcion.Text = seleccionado.Descripcion;
                txtImagenUrl.Text = seleccionado.ImagenUrl;
                txtPrecio.Text = seleccionado.Precio.ToString();

                //Como arriba ya cargamos los desplegables, aca simplemente los modificamos.
                ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                //forzamos el cambio de la imagen
                txtImagenUrl_TextChanged(sender, e);
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articulo = new ArticuloNegocio();
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
                aux.Precio = decimal.Parse(txtPrecio.Text);

                //La validacion de que si es para agregar o modificar la hacemos aca.
                if (Request.QueryString["id"] != null)
                {
                    //recibimos un seleccionado a la pagina, y enviamos un aux al metodo de accesoDB, por lo que hay que cargarle al aux el Id
                    aux.Id = int.Parse(txtId.Text);
                    articulo.modificarArticulo(aux);
                }
                else
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

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            //a la imagen, le asigno la URL que esta en el txt
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chbConfirmarEliminacion.Checked)
                {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    articuloNegocio.eliminarFisico(int.Parse(txtId.Text));
                    Response.Redirect("ListadoArticulos.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }
    }
}