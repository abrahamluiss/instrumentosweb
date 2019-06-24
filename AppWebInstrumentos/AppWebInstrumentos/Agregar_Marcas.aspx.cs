using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Agregar_Marcas : System.Web.UI.Page
{
    conexionALSE con = new conexionALSE();
    consultasALSE datos = new consultasALSE();
    protected void Page_Load(object sender, EventArgs e)
    {
        vermarcas();
        deshabilitar(false);
        btnguardar.Enabled = false;
        btnmodificar.Enabled = true;
        btnnuevo.Enabled = true;
    }

    public void deshabilitar(Boolean estado)
    {
        txtIDMarca.Enabled = estado;
        txtnombremarca.Enabled = estado;
        txtnombrecont.Enabled = estado;
        txtdirec.Enabled = estado;
        txtciudad.Enabled = estado;
        txtregion.Enabled = estado;
        txtcodpost.Enabled = estado;
        txtpais.Enabled = estado;
        txttel.Enabled = estado;
        txtweb.Enabled = estado;
    }
    public void insertarmarca()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "insmarca";
        cmd.Parameters.Add("@nombremarca", SqlDbType.VarChar).Value = txtnombremarca.Text;
        cmd.Parameters.Add("@nombrecontacto", SqlDbType.VarChar).Value = txtnombremarca.Text;
        cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = txtdirec.Text;
        cmd.Parameters.Add("@ciudad", SqlDbType.VarChar).Value = txtciudad.Text;
        cmd.Parameters.Add("@region", SqlDbType.VarChar).Value = txtregion.Text;
        cmd.Parameters.Add("@codpostal", SqlDbType.VarChar).Value = txtcodpost.Text;
        cmd.Parameters.Add("@pais", SqlDbType.VarChar).Value = txtpais.Text;
        cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = txttel.Text;
        cmd.Parameters.Add("@paginaprincipal", SqlDbType.Text).Value = txtweb.Text;
        con.conectar();
        cmd.ExecuteNonQuery();
        con.desconectar();
    }
    public void modificarmarca()
    {

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "upmarcas";
        cmd.Parameters.Add("@nombremarca", SqlDbType.VarChar).Value = txtnombremarca.Text;
        cmd.Parameters.Add("@nombrecontacto", SqlDbType.VarChar).Value = txtnombremarca.Text;
        cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = txtdirec.Text;
        cmd.Parameters.Add("@ciudad", SqlDbType.VarChar).Value = txtciudad.Text;
        cmd.Parameters.Add("@region", SqlDbType.VarChar).Value = txtregion.Text;
        cmd.Parameters.Add("@codpostal", SqlDbType.VarChar).Value = txtcodpost.Text;
        cmd.Parameters.Add("@pais", SqlDbType.VarChar).Value = txtpais.Text;
        cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = txttel.Text;
        cmd.Parameters.Add("@paginaprincipal", SqlDbType.Text).Value = txtweb.Text;
        con.conectar();
        cmd.ExecuteNonQuery();
        con.desconectar();
    }






    public void limpiar()
    {
        txtIDMarca.Text = string.Empty;
        txtnombremarca.Text = string.Empty;
        txtnombrecont.Text = string.Empty;
        txtdirec.Text = string.Empty;
        txtciudad.Text = string.Empty;
        txtregion.Text = string.Empty;
        txtcodpost.Text = string.Empty;
        txtpais.Text = string.Empty;
        txttel.Text = string.Empty;
        txtweb.Text = string.Empty;
    }



    protected void btnnuevo_Click1(object sender, EventArgs e)
    {
        lbloperacion.Text = "n";
        limpiar();
        deshabilitar(true);
        btnguardar.Enabled = true;
        btnmodificar.Enabled = false;
        btnnuevo.Enabled = false;
        txtIDMarca.Enabled = false;
    }

    protected void btnmodificar_Click1(object sender, EventArgs e)
    {
        lbloperacion.Text = "m";
        deshabilitar(true);
        btnguardar.Enabled = true;
        btnmodificar.Enabled = false;
        btnnuevo.Enabled = false;
        txtIDMarca.Enabled = false;
    }

    protected void btncancelar_Click(object sender, EventArgs e)
    {
        btnguardar.Enabled = false;
        btnmodificar.Enabled = true;
        btnnuevo.Enabled = true;
        deshabilitar(true);
        txtIDMarca.Enabled = false;
        limpiar();
    }

    protected void btnguardar_Click(object sender, EventArgs e)
    {
        if (lbloperacion.Text == "m")
        {
            modificarmarca();
            Response.Write("<Script>alert('Marca Modificado');</script>");
        }
        else
        {
            insertarmarca();
            Response.Write("<Script>alert('Marca Insertado');</script>");
        }
    }

    public void vermarcas()
    {
        grdmarcas.DataSource = datos.extrae("vermarcas");
        grdmarcas.DataBind();
    }
}