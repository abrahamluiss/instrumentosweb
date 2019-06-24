using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Agregar_Categorias : System.Web.UI.Page
{
    conexionALSE con = new conexionALSE();
    consultasALSE datos = new consultasALSE();

    protected void Page_Load(object sender, EventArgs e)
    {
        vercategorias();
        deshabilitar(false);
        btnguardar.Enabled = false;
        btnNuevo.Enabled = true;
    }
    public void deshabilitar(Boolean estado)
    {
        txtIDcat.Enabled = estado;
        txtnombrecat.Enabled = estado;
        txtdescr.Enabled = estado;
    }
    public void vercategorias()
    {
        grdcateg.DataSource = datos.extrae("vercatg");
        grdcateg.DataBind();
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        lbloperacion.Text = "n";
        limpiar();
        deshabilitar(true);
        btnguardar.Enabled = true;
        //btnmodificar.Enabled = false;
        btnNuevo.Enabled = false;
        txtIDcat.Enabled = false;
    }

    protected void btnguardar_Click(object sender, EventArgs e)
    {
        if (lbloperacion.Text == "m")
        {
            //modificarcatg();
            Response.Write("<Script>alert('Un no se puede Modificar');</script>");
        }
        else
        {
            insertarcatg();
            Response.Write("<Script>alert('Marca Insertado');</script>");
        }
    }
    public void insertarcatg()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "inscatg";
        cmd.Parameters.Add("@nombrecategoria", SqlDbType.VarChar).Value = txtnombrecat.Text;
        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = txtdescr.Text;
        con.conectar();
        cmd.ExecuteNonQuery();
        con.desconectar();
    }

    protected void btncancelar_Click(object sender, EventArgs e)
    {
        btnguardar.Enabled = false;
        btnNuevo.Enabled = true;
        deshabilitar(true);
        txtIDcat.Enabled = false;
        limpiar();
    }

    public void limpiar()
    {
        txtIDcat.Text = string.Empty;
        txtnombrecat.Text = string.Empty;
        txtdescr.Text = string.Empty;
    }
}