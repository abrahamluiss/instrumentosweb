using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DetalleProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(Session["idproduct"]);
        mostrarproducto();
    }

    public void mostrarproducto()
    {
       
        consultasALSE datos = new consultasALSE();
      
        DataTable tabla = new DataTable();
        tabla = datos.extrae((int)Session["idproduct"], "@idproducto", "buscaproductoxid");
        lblnombre.Text = tabla.Rows[0][1].ToString();
        lblcategoria.Text = tabla.Rows[0][3].ToString();
        lblmarca.Text = tabla.Rows[0][2].ToString();
        lblprecio.Text = tabla.Rows[0][5].ToString();
        lblstock.Text = tabla.Rows[0][6].ToString();
        imgproducto.ImageUrl= tabla.Rows[0][11].ToString();

    }
}