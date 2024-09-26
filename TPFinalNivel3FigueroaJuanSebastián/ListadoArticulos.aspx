<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="TPFinalNivel3FigueroaJuanSebastián.ListadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager2" />
    <h1>Listado de articulos</h1>
    <div class="container text-center">

        <h2>Filtrar</h2>
        <div class="col">
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <label>Nombre:</label>
                        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
                    </div>
                </div>

                <div class="col-6">
                    <div class="mb-3">
                        <asp:CheckBox ID="cbFiltroAvanzado" AutoPostBack="true" Text="Filtro avanzado" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Button Text="Reestablecer filtro" CssClass="btn btn-warning" ID="btnReestablecer" OnClick="btnReestablecer_Click" runat="server" />

                    </div>
                </div>
            </div>
        </div>

        <%-- Filtro avanzado --%>
        <%if (cbFiltroAvanzado.Checked)
            { %>
        <div class="row">
            <div class="col-2">
                <div class="mb-3">
                    <asp:Label Text="Nombre" runat="server" />
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                </div>
            </div>
            <div class="col-2">
                <div class="mb-3">
                    <asp:Label Text="Categoria" runat="server" />
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCategoria" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                        <asp:ListItem Text="Todas" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-2">
                <div class="mb-3">
                    <asp:Label Text="Marca" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-control" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged">
                        <asp:ListItem Text="Todas" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-2">
                <div class="mb-3">
                    <asp:Label Text="Precio mínimo" runat="server" />
                    <asp:TextBox runat="server" ID="txtPrecioMinimo" CssClass="form-control" />
                </div>
            </div>
            <div class="col-2">
                <div class="mb-3">
                    <asp:Label Text="Precio máximo" runat="server" />
                    <asp:TextBox runat="server" ID="txtPrecioMaximo" CssClass="form-control" />
                </div>

                <div class="col-5">
                    <div class="mb-2">
                        <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />

                    </div>
                </div>

            </div>
        </div>
        <%} %>

        <div class="col">
            <%-- Agregamos la dgv a un update panel para el filtro rapido --%>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:GridView ID="dgvArticulos" CssClass="table" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                        AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvArticulos_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />
                            <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" SelectText="✍" />
                        </Columns>
                    </asp:GridView>

                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="col-11">
                <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>
            </div>
        </div>
        <div class="col">
        </div>

    </div>

</asp:Content>
