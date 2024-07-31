<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="TPFinalNivel3FigueroaJuanSebastián.ListadoArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Listado de articulos</h1>
    <div class="container text-center">

        <div class="col">

        </div>
        <div class="col">

            <asp:GridView ID="dgvArticulos" CssClass="table" runat="server" AutoGenerateColumns="false"
                DatakeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                >

                <Columns>
                    <asp:BoundField Headertext="Codigo" DataField="Codigo"/>
                    <asp:BoundField Headertext="Nombre" DataField="Nombre"/>
                    <asp:BoundField Headertext="Descripcion" DataField="Descripcion"/>
                    <asp:BoundField Headertext="Categoria" DataField="Categoria.Descripcion"/>
                    <asp:BoundField Headertext="Marca" DataField="Marca.Descripcion"/>
                    <asp:BoundField Headertext="Precio" DataField="Precio"/>
                    <asp:CommandField Headertext="Seleccionar" Showselectbutton="true" selecttext="✍" />
                </Columns>

            </asp:GridView>
            <div class="col-11">   
                <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>
            </div>
        </div>
        <div class="col">

        </div>

    </div>

</asp:Content>
