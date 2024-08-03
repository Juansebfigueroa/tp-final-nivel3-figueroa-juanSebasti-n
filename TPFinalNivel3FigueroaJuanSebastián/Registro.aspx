<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinalNivel3FigueroaJuanSebastián.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-3 row">
        <label for="txtEmail" class="col-sm-2 col-form-label">Email</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="nombre@ejemplo.com" runat="server" />
        </div>
    </div>
    <div class="mb-3 row">
        <label for="txtPass" class="col-sm-2 col-form-label">Password</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtPass" TextMode="Password" CssClass="form-control" runat="server" />
        </div>
    </div>
    <div class="mb-5 row">
        <div class="col mb-3">
            <asp:Button ID="btnRegistrarse" Text="Registrarse" OnClick="btnRegistrarse_Click" runat="server" />
            <a href="Home.aspx">Cancelar</a>
        </div>
    </div>
</asp:Content>
