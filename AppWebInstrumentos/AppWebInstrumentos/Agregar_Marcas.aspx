<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Agregar_Marcas.aspx.cs" Inherits="Agregar_Marcas" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Agregando Marcas</h2>
    <p>
        <asp:Button ID="btnnuevo" runat="server" Text="Nuevo" OnClick="btnnuevo_Click1" />
        <asp:Button ID="btnmodificar" runat="server" Text="Modificar" OnClick="btnmodificar_Click1" />
        <asp:Button ID="btnguardar" runat="server" Text="Guardar" OnClick="btnguardar_Click" />
        <asp:Button ID="btncancelar" runat="server" Text="Cancelar" OnClick="btncancelar_Click" />
    </p>
    <asp:Label ID="lbloperacion" runat="server" ForeColor="White"></asp:Label>
    <p>idMarca:<asp:TextBox ID="txtIDMarca" runat="server"></asp:TextBox>
    </p>
    <p>nombremarca:<asp:TextBox ID="txtnombremarca" runat="server"></asp:TextBox>
    </p>
    <p>nombrecontacto:<asp:TextBox ID="txtnombrecont" runat="server"></asp:TextBox>
    </p>
    <p>direccion:<asp:TextBox ID="txtdirec" runat="server"></asp:TextBox>
    </p>
    <p>ciudad:<asp:TextBox ID="txtciudad" runat="server"></asp:TextBox>
    </p>
    <p>region:<asp:TextBox ID="txtregion" runat="server"></asp:TextBox>
    </p>
    <p>codPostal:<asp:TextBox ID="txtcodpost" runat="server"></asp:TextBox>
    </p>
    <p>pais:<asp:TextBox ID="txtpais" runat="server"></asp:TextBox>
    </p>
    <p>telefono:<asp:TextBox ID="txttel" runat="server"></asp:TextBox>
    </p>
    <p>paginaprincipal:<asp:TextBox ID="txtweb" runat="server"></asp:TextBox>
    </p>
    <p>&nbsp;</p>
    <p>Todas las marcas agregadas</p>
    <p>
        <asp:GridView ID="grdmarcas" runat="server">
        </asp:GridView>
    </p>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

