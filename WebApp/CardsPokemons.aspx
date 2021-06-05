<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CardsPokemons.aspx.cs" Inherits="WebApp.CardsPokemons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<%--        <table>
        <tr>
            <td>Nombre</td>
        </tr>
        <% foreach (dominio.Pokemon item in lista)
            {%>

        <tr>
            <td>
                <% = item.Nombre %>
            </td>
            <td>
                <a href="DetallePokemon.aspx?id=<% = item.Id %>">eliminar</a>
            </td>
        </tr>

        <% } %>
    </table>--%>

    <div class="container">
        <div class="row">

        <% foreach (dominio.Pokemon item in lista)
            {%>
            <div class="col">
                <div class="card" style="width: 18rem;">
                    <img src="<% = item.UrlImagen %>"" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><% = item.Nombre %></h5>
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                        <a href="DetallePokemon.aspx?id=<% = item.Id %>" class="btn btn-primary">Ver Detalle</a>
                        <a href="Favoritos.aspx?id=<% = item.Id %>&e=t"><i class="fas fa-heart"></i></a>
                    </div>
                </div>
            </div>
        <% } %>
             </div>
        </div>
</asp:Content>
