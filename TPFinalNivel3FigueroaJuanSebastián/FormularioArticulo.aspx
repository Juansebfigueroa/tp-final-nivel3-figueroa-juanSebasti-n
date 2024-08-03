<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="TPFinalNivel3FigueroaJuanSebastián.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Agregamos un script manager para usar el update panel --%>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <h1>Detalles del articulo</h1>
    <!-- 
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        
        //Fijarse si trabajar marca y categoria como un objeto o solo ID int
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }
        -->

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo: </label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion: </label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio: </label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria: </label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca:</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <%if (negocio.Seguridad.isAdmin((dominio.User)Session["usuario"]))
                    {%> 
                    <a href="ListadoArticulos.aspx" class="btn btn-primary">Cancelar</a>
                <% }
                    else{ %>
                    <a href="Home.aspx" class="btn btn-primary">Cancelar</a>
                <%} %>

            </div>
        </div>
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>

                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                        <%-- Le generamos el evento OnTextChanged a la txtImagenUrl y la metemos dentro de un update panel para que cargue la misma en el formulario --%>
                    </div>

                    <div class="mb-3">
                        <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" runat="server" ID="imgArticulo" Width="60%" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <%-- metemos los siguiente en un update panel --%>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div class="mb-6">
                        <%-- En el evento simplemente cambiara a true la property definida en el back. ConfirmarEliminacion --%>
                        <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" runat="server" />
                    </div>
                    <%-- Mostramos condicionalmente los siguientes dos controles segun la propiedad definida en el back--%>
                    <%  if (ConfirmarEliminacion)
                        { %>
                    <div class="mb-6">
                        <asp:CheckBox Text="Confirmar eliminación" ID="chbConfirmarEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmarEliminacion" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminacion_Click" runat="server" />
                    </div>
                    <% } %>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
</div>
</asp:Content>
