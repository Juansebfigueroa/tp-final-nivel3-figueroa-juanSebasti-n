﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TPFinalNivel3FigueroaJuanSebastián.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <div class="row">
            <div class="col">
                
            </div>
            <div class="col">
                <h1>Digital Market</h1>
            </div>
            <div class="col">
                
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <p>Tu tienda digital de confianza</p>
            </div>
        </div>
        <hr />

        <!-- Ubicamos la carta dentro de un row, y la iteramos segun la cantidad de articulso que haya. En el cs usamos el metodo listar para traernos la lista de articulos-->
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <%//itera con un foreach. para hacer referencia a la variable usa la referencia al dominio y a la clase. 
                foreach (dominio.Articulo art in listaArticulos)
                {%>
                    <div class="card" style="width: 18rem;">
                        <!-- metemos la img dentro de un div y le mandamos la clase ratio para que sea cuadrada -->
                        <div class="ratio ratio-1x1">
                            <img src="<%: art.ImagenUrl %> " class="card-img-top" alt="..."> 
                        </div>
                        <div class="card-body">
                            <h5 class="card-title"> <%: art.Nombre %> </h5>
                            <p class="card-text"><%: art.Descripcion %></p>
                            <a href="FormularioArticulo.aspx?Id= <%: art.Id %>" class="btn btn-primary">Ver detalles</a>
                        </div>
                    </div>
               <% } %>

        </div>
    </div>


</asp:Content>
