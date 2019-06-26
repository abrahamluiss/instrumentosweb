<%@ Page Title="" Language="C#" MasterPageFile="~/MasterInstrumentos.master" AutoEventWireup="true" CodeFile="DetalleProducto.aspx.cs" Inherits="DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Label ID="lblnombre" runat="server"></asp:Label>
    <br />

    <asp:Image ID="imgproducto" runat="server" Height="191px" Width="192px" />

    <br />
    <asp:Label ID="lblmarca" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblcategoria" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblprecio" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblstock" runat="server"></asp:Label>
    <br />
    <br />
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

