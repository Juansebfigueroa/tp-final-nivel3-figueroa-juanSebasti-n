<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPFinalNivel3FigueroaJuanSebastián.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>Ha ocurrido el siguiente error:</p>
    <asp:Label Text="Error" ID="lblError" runat="server" />

    <%if (Session["error"].ToString() == "Debes cerrar sesion si quieres ingresar con otra cuenta")
            {
            %>
    <asp:Button Text="Cerrar sesión" CssClass="btn btn-danger" ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" runat="server" />
    <%        } %>
</asp:Content>
