<%@ Page Title="" Language="C#" MasterPageFile="~/MasterInstrumentos.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- banner -->
		<div class="banner">
			<div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
				<ol class="carousel-indicators">
					<li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
					<li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
					<li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
					<li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
				</ol>
				<div class="carousel-inner" role="listbox">
					<div class="carousel-item active">
						<div class="carousel-caption text-center">
							<h3><asp:Label ID="txt1" runat="server" Text="Zampoñas" CssClass="h2"></asp:Label>
                                <asp:Label ID="span1" runat="server" Text="Zampoñas al 50% de Descuento" CssClass="h3"></asp:Label>
								
							</h3>
		
                            <div class="btn btn-sm animated-button gibson-three mt-4">
                            <asp:Button ID="Button1" runat="server" Text="Comprar" CssClass="btn-outline-warning focus" PostBackUrl="ZampoñasShop.aspx" BorderColor="#CC0066" BorderStyle="Ridge" Font-Size="X-Large"/>
                            </div>
						</div>
					</div>
					<div class="carousel-item item2">
						<div class="carousel-caption text-center">
							<h3>Charango
								<span>Quiere tocar como los profesionales?</span>
							</h3>
							<a href="shop.html" class="btn btn-sm animated-button gibson-three mt-4">Comprar Ahora</a>

						</div>
					</div>
					<div class="carousel-item item3">
						<div class="carousel-caption text-center">
							<h3>Cajon Peruano
								<span>Envio gratis </span>
							</h3>
							<a href="shop.html" class="btn btn-sm animated-button gibson-three mt-4">Comprar Ahora</a>

						</div>
					</div>
					<div class="carousel-item item4">
						<div class="carousel-caption text-center">
							<h3>Quenas de Ebano
								<span>Los mejores descuentos en quenas</span>
							</h3>
							<a href="shop.html" class="btn btn-sm animated-button gibson-three mt-4">Comprar Ahora</a>
						</div>
					</div>
				</div>
				<a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
					<span class="carousel-control-prev-icon" aria-hidden="true"></span>
					<span class="sr-only">Previous</span>
				</a>
				<a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
					<span class="carousel-control-next-icon" aria-hidden="true"></span>
					<span class="sr-only">Next</span>
				</a>
			</div>
            </div>
        	<section class="banner-bottom-wthreelayouts py-lg-5 py-3">
		<div class="container-fluid">
			<div class="inner-sec-shop px-lg-4 px-3">
				<h3 class="tittle-w3layouts my-lg-4 my-4">Lo mas vendido</h3>
				<div class="row">
                    					<div class="col-md-3 product-men women_two">
						<div class="product-googles-info googles">
							<div class="men-pro-item">
								<div class="men-thumb-item">
                                    <asp:DataList ID="dataproductos" runat="server" OnItemCommand="activaMostrar"  RepeatColumns="3" DataKeyField="idProducto" OnSelectedIndexChanged="dataproductos_SelectedIndexChanged" RepeatDirection="Horizontal">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("nombreProducto") %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("precioUnidad") %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("cantidadporu") %>'></asp:Label>
                                            <br />
           <%--                                 <asp:Label ID="Label4" runat="server" Text='<%# Eval("proveedor") %>'></asp:Label>--%>
                                            <br />
<%--                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("categoria") %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("unidadesstock") %>'></asp:Label>--%>
                                            <br />
                                            <asp:Image ID="imgproducto" runat="server" ImageUrl='<%# Eval("imagen") %>' ImageAlign="Top" Width="120px" />
                                            <br />
                                            <asp:Button ID="Button2" runat="server" CommandName="verprod" Text="Button" />
                                            <br />
                                            <asp:Button ID="btnAgregar" runat="server" CssClass="add-review" Text="Agregar" CommandName="agregarcarro"  />
                                            <br />
                                        </ItemTemplate>
                                        <SelectedItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                    </asp:DataList>
                                    </div>
                                </div>
                            </div></div>
                    </div>
                </div>
            </div>
            </section>
			<!--//banner -->
</asp:Content>

