﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterInstrumentos.master" AutoEventWireup="true" CodeFile="carrito.aspx.cs" Inherits="carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="containercart">
<asp:GridView ID="grdproductos" CssClass="table table-bordered bs-table" runat="server" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" DataKeyNames="idproducto" OnRowDeleting="grdproductos_RowDeleting" OnRowEditing="grdproductos_RowEditing" OnSelectedIndexChanged="grdproductos_SelectedIndexChanged" OnDataBound="grdproductos_DataBound" OnRowCancelingEdit="grdproductos_RowCancelingEdit" OnRowDataBound="grdproductos_RowDataBound" OnRowUpdating="grdproductos_RowUpdating">
</asp:GridView>
        <br />
        <br />
        <br />
<br />
<asp:Button ID="btnConfirmar" class="btn btn-success" runat="server" Text="Confirmar compra" OnClick="btnConfirmar_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>
