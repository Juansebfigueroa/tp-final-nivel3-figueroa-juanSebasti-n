<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="TPFinalNivel3FigueroaJuanSebastián.ListadoArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Listado de articulos</h1>
    <div class="container text-center">

        <div class="col">

        </div>
        <div class="col">

            <asp:GridView ID="dgvArticulos" CssClass="table" runat="server"></asp:GridView>

        </div>
        <div class="col">

        </div>

    </div>

</asp:Content>
