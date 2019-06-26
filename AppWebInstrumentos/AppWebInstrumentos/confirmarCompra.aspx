<%@ Page Title="" Language="C#" MasterPageFile="~/MasterInstrumentos.master" AutoEventWireup="true" CodeFile="confirmarCompra.aspx.cs" Inherits="confirmarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-group" id="cccont">
<div class="fila">
    IdPedido
    <asp:Label ID="lblidpedido" runat="server"></asp:Label>
    <br />
    </div>
        <div class="fila">
    IdCliente
    <asp:Label ID="lblidcliente" runat="server"></asp:Label>
            <br />
            </div>
        <div class="fila">
    FechaPedido
    <asp:Label ID="lblfechapedido" runat="server"></asp:Label>
    <br />
            </div>
        <div class="fila">
    FechaEntrega
    <asp:Label ID="lblfechaentrega" runat="server"></asp:Label>
    <br />
            </div>
        <div class="fila">
    FechaEnvio
    <asp:Label ID="lblfechaenvio" runat="server"></asp:Label>
    <br />
            </div>
        <div class="fila">
    FormaEnvio
    <asp:DropDownList ID="lstformaenvio" runat="server">
    </asp:DropDownList>
    <br />
            </div>
        <div class="fila">
    Destinatario
            <asp:TextBox ID="txtnombre" runat="server"></asp:TextBox>
    <br />
            </div>
        <div class="fila">
    DireccionDestinatario
    <asp:TextBox ID="txtdirecciondestinatario" runat="server"></asp:TextBox>
    <br />
            </div>
        <div class="fila">
    CiudadDestinatario
    <asp:TextBox ID="txtciudaddestino" runat="server"></asp:TextBox>
    <br />
            </div>
        <div class="fila">
    RegionDestinatario
    <asp:TextBox ID="txtregiondestinatario" runat="server"></asp:TextBox>
    <br />
            </div>
        <div class="fila">
    CodPostalDestinatario
    <asp:TextBox ID="txtcodpostal" runat="server"></asp:TextBox>
    <br />
            </div>
        <div class="fila">
    PaisDestinatario&nbsp;&nbsp;
    <asp:TextBox ID="txtpais" runat="server"></asp:TextBox>
    <br />
            </div>
    <br />
    Total a pagar
    <asp:Label ID="lbltotalpagar" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnPago" runat="server" OnClick="btnComprar_Click" Text="Efectuar Pago" CssClass="btn btn-primary sweet-8" />
    <br />
    <br />
    <br />
         </div>
</asp:Content>


