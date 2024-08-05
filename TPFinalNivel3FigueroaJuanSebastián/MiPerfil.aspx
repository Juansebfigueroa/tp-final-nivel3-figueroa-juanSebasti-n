<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TPFinalNivel3FigueroaJuanSebastián.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Agregamos un script manager para usar el update panel --%>
    <asp:ScriptManager ID="ScriptManager2" runat="server" />

    <h1>Mi Perfil</h1>

    <%--{
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UrlImagenPerfil { get; set; }
        public bool Admin { get; set; }
    }
    --%>
    <div class="container">
        <div class="row align-items-center">
            <!-- Columna del formulario -->
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre:</label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtApellido" class="form-label">Apellido:</label>
                    <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email:</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <a href="Home.aspx" class="btn btn-primary">Ir al Home</a>
                    <asp:Button Text="Modificar datos" ID="btnModificarDatos" CssClass="btn btn-warning" OnClick="btnModificarDatos_Click" runat="server" />
                </div>
            </div>

            <!-- Columna de la imagen -->
            <div class="col-md-6 d-flex justify-content-center">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="txtUrlImagen" class="form-label">Url de la imagen de perfil:</label>
                            <asp:TextBox ID="txtUrlImagen" CssClass="form-control" OnTextChanged="txtUrlImagen_TextChanged" AutoPostBack="true" runat="server" />
                        </div>

                        <asp:Image ID="imgPerfil" runat="server" ImageUrl="https://www.shutterstock.com/image-illustration/no-picture-available-placeholder-thumbnail-260nw-2179364083.jpg" CssClass="img-fluid rounded" />
                        <div>
                            <asp:Label ID="lblModificarDatos" Enabled="false" Text="Se modificaron los datos exitosamente" runat="server" />
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
    </div>

</asp:Content>
