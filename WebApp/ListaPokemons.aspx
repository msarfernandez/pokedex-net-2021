<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaPokemons.aspx.cs" Inherits="WebApp.ListaPokemons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Pokemons</h1>


    <asp:GridView ID="dgvPokemons" runat="server"></asp:GridView>

    <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
</asp:Content>
