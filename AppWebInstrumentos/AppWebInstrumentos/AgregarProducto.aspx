<%@ Page Title="" Language="C#" MasterPageFile="~/MasterInstrumentos.master" AutoEventWireup="true" CodeFile="AgregarProducto.aspx.cs" Inherits="AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
  
        
       <br />
        <div>
        <asp:Button ID="btnnuevo" runat="server" Text="Nuevo" OnClick="btnnuevo_Click"  tyle="width:120px"/>
        <asp:Button ID="btnmodificar" runat="server" Text="Modificar" OnClick="btnmodificar_Click"  />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click1" />
        <br /></div>
        <asp:Label ID="lbloperacion" runat="server" ForeColor="White"></asp:Label>  
        <p>
        Codigo:
        <asp:TextBox ID="txtIDProduct" runat="server"></asp:TextBox>
        <br /></p>
        Nombre:
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        Marcas:<asp:DropDownList ID="lstMarcas" runat="server">
        </asp:DropDownList>
        <br />
        Categorias:<asp:DropDownList ID="lstCategoria" runat="server">
        </asp:DropDownList>
        <br />
    Tipo:
    <asp:DropDownList ID="lsttipo" runat="server">
    </asp:DropDownList>
        <br />
        Cantidad Por Unidad:
        <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
        <br />
        Precio Unidad:<asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
        <br />
        Unidades En Existencia:
        <asp:TextBox ID="txtUniExis" runat="server"></asp:TextBox>
        <br />
        Unidades En Pedido:<asp:TextBox ID="txtUniPedid" runat="server"></asp:TextBox>
        <br />
        Nivel De Pedido:<asp:TextBox ID="txtnivel" runat="server"></asp:TextBox>
        <br />
        Suspendido:
        <asp:CheckBox ID="chksuspendido" runat="server"  Text="Suspendido" />
        <br />
        Serie: <asp:TextBox ID="txtserie" runat="server"></asp:TextBox>
        <br />
        Imagen<br />
        <asp:FileUpload ID="FileUploadx" runat="server" />
        <br />
        <asp:Button ID="BbtnSubirImg" runat="server"  Text="Subir Imagen" OnClick="BbtnSubirImg_Click" />
        <br />
        <asp:Image ID="imgproducto" runat="server" Height="152px" />
        <br />
        <br />
        Buscar Producto:
        <asp:TextBox ID="txtBuscarProduc" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscarProduc" runat="server" Text="Buscar" OnClick="btnBuscarProduc_Click" />
        <br />
        <br />
        <asp:GridView ID="grdListaProductos" runat="server" DataKeyNames="idproducto" OnSelectedIndexChanged="grdListaProductos_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

