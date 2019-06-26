using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class index : System.Web.UI.Page
{
    consultasALSE datos = new consultasALSE();
    insALSE inserta = new insALSE();
    conexionALSE con = new conexionALSE();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            masvendido();
            Session["idpedido"] = 0;
            Session["iduser"] = "1";

        }
    }
    public void masvendido()
    {
        dataproductos.DataSource = datos.extrae("indeximagens");
        dataproductos.DataBind();
    }


    protected void activaMostrar(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "verprod")
        {
            int idprod = int.Parse(dataproductos.DataKeys[e.Item.ItemIndex].ToString());
            Session["idproduct"] = idprod;
            Response.Redirect("~/DetalleProducto.aspx");
            
        }
        if (e.CommandName == "agregarcarro")
        {
            int idprod = int.Parse(dataproductos.DataKeys[e.Item.ItemIndex].ToString());
            Response.Write(idprod);

            if ((int)Session["idpedido"] == 0)
            {
                Session["idpedido"] = new_pedido();
            }
            insdetalletemp(idprod);
        }

    }

    public int new_pedido()
    {
        int idpedidotemp = inserta.get_int("temppedido_ins", "@idpedido", 0, "@idcliente",
        Session["iduser"].ToString());
        Response.Write(idpedidotemp);
        return idpedidotemp;
    }

    private void insdetalletemp(int idprod)
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        cmd.Connection = con.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "ins_tmpdetalle";
        cmd.Parameters.Add("@idpedido", SqlDbType.Int).Value = (int)Session["idpedido"];
        cmd.Parameters.Add("@idproducto", SqlDbType.Int).Value = idprod;
        con.conectar();
        cmd.ExecuteNonQuery();
        con.desconectar();
    }

    protected void dataproductos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnverprod_Click(object sender, EventArgs e)
    {

    }
}
