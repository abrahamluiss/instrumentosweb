<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Agregar_Categorias.aspx.cs" Inherits="Agregar_Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            height: 26px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2">Agregar Categorias</td>
            <asp:Label ID="lbloperacion" runat="server" ForeColor="White"></asp:Label>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                <asp:Button ID="btnguardar" runat="server" Text="Guardar" OnClick="btnguardar_Click" />
                <asp:Button ID="btncancelar" runat="server" Text="Cancelar" OnClick="btncancelar_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">idCategorias</td>
            <td class="auto-style1">
                <asp:TextBox ID="txtIDcat" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>nombrecategoria</td>
            <td>
                <asp:TextBox ID="txtnombrecat" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>descripcion</td>
            <td>
                <asp:TextBox ID="txtdescr" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <p>Todas las categorias</p>
    <p>
        <asp:GridView ID="grdcateg" runat="server">
        </asp:GridView>
    </p>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
    
</asp:Content>

