using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class carrito : System.Web.UI.Page
{

    consultasALSE dato = new consultasALSE();
    conexionALSE con = new conexionALSE();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //grdproductos.DataSource = datJPR.extrae("get_tmpdetalle", "@idpedido", (int)Session["idpedido"]);
            //grdproductos.DataBind();
            carromostrar();
        }

    }
    public void carromostrar()
    {
        conexionALSE con = new conexionALSE();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "get_tmpdetalle";
        cmd.Parameters.Add("@idpedido", SqlDbType.Int).Value = (int)Session["idpedido"];
        con.conectar();
        da.SelectCommand = cmd;
        da.Fill(dt);
        con.desconectar();

        dt.Columns[1].ReadOnly = true;
        dt.Columns[2].ReadOnly = true;
        dt.Columns[3].ReadOnly = true;
        grdproductos.DataSource = dt;
        grdproductos.DataBind();


    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        Session["iduser"] = "Abraham";
        Response.Redirect("~/confirmarCompra");
    }

    protected void grdproductos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void mostrarcarrito()
    {
        grdproductos.DataSource = dato.extrae("get_tmpdetalle", "@idpedido", (int)Session["idpedido"]);
        grdproductos.DataBind();
    }

    protected void grdproductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //GridViewRow fila = grdproductos.SelectedRow;
        GridViewRow row = (GridViewRow)grdproductos.Rows[e.RowIndex];
        int idProd = Convert.ToInt32(grdproductos.DataKeys[e.RowIndex].Value.ToString());
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        cmd.Connection = con.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "deletedetalle";
        cmd.Parameters.Add("@idpedido", SqlDbType.Int).Value = (int)Session["idpedido"];
        cmd.Parameters.Add("@idproducto", SqlDbType.Int).Value = idProd;
        con.conectar();
        cmd.ExecuteNonQuery(); //Lo que se ejecuta no es una consulta
        con.desconectar();
        mostrarcarrito();
    }

    protected void grdproductos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdproductos.EditIndex = e.NewEditIndex;

        carromostrar();

    }


    protected void grdproductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdproductos.EditIndex = -1;

        mostrarcarrito();
    }

    protected void grdproductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int prodid = Convert.ToInt32(grdproductos.DataKeys[e.RowIndex].Value.ToString());
        GridViewRow row = (GridViewRow)grdproductos.Rows[e.RowIndex];
        TextBox canti = (TextBox)row.Cells[4].Controls[0];
        //string cant = (row.Cells[].Controls[0] as TextBox).Text;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        cmd.Connection = con.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "updcarrito";
        cmd.Parameters.Add("@idpedido", SqlDbType.Int).Value = (int)Session["idpedido"];
        cmd.Parameters.Add("@idproducto", SqlDbType.Int).Value = prodid;
        cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = Convert.ToInt32(canti.Text);
        con.conectar();
        cmd.ExecuteNonQuery(); //Lo que se ejecuta no es una consulta
        grdproductos.EditIndex = -1;
        con.desconectar();
        mostrarcarrito();
    }

    protected void grdproductos_DataBound(object sender, EventArgs e)
    {

    }

    protected void grdproductos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
}