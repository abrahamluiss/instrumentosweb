<%@ Page Title="" Language="C#" MasterPageFile="~/MasterInstrumentos.master" AutoEventWireup="true" CodeFile="EfectuarPago.aspx.cs" Inherits="EfectuarPago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 288px;
    }
    .auto-style2 {
        width: 174px;
    }
    .auto-style3 {
        width: 174px;
        text-align: center;
    }
    .auto-style4 {
        width: 288px;
        height: 30px;
    }
    .auto-style5 {
        width: 174px;
        height: 30px;
    }
    .auto-style6 {
        height: 30px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style3">Pago Online</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Cliente ID:</td>
                <td class="auto-style2">
                    <asp:Label ID="lblidCliente" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Moneda:</td>
                <td class="auto-style2">
                    <asp:Label ID="lblMoneda" runat="server" Text="Soles"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Comisión:</td>
                 <td class="auto-style2">
                     <asp:Label ID="lblComision" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Tipo De Tarjeta: </td>
                 <td class="auto-style2">
                     <asp:DropDownList ID="lblTipoTarj" runat="server">
                     </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
                        <tr>
                <td class="auto-style1">Número de tarjeta: </td>
                 <td class="auto-style2">
                     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                <td>&nbsp;</td>
            </tr>
                        <tr>
                <td class="auto-style1">Nombre del titular:</td>
                 <td class="auto-style2">
                     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                <td>&nbsp;</td>
            </tr>
                        <tr>
                <td class="auto-style4">Fecha de Caducidad: </td>
                 <td class="auto-style5">Año:
                     <asp:TextBox ID="TextBox4" runat="server" Width="75px"></asp:TextBox>
                            </td>
                <td class="auto-style6">Mes:<asp:TextBox ID="TextBox5" runat="server" Width="60px"></asp:TextBox>
                            </td>
            </tr>
                        <tr>
                <td class="auto-style1">CVC/CVV</td>
                 <td class="auto-style2">
                     <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Button ID="btnpagar" runat="server" CssClass="active" Text="Pagar" />
</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

