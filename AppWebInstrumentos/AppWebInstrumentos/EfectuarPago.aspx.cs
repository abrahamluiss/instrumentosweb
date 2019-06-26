using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class EfectuarPago : System.Web.UI.Page
{
    consultasALSE datos = new consultasALSE();
    consultasALSE datos2 = new consultasALSE();
    consultasALSE datos3 = new consultasALSE();
    consultasALSE datos4 = new consultasALSE();
    conexionALSE cn = new conexionALSE();
        
    protected void Page_Load(object sender, EventArgs e)
    {
        string idUsuario = Session["iduser"].ToString();
        mostrarDatos(idUsuario);
    }
    public void mostrarDatos(string idusuar)
    {
        DataTable dt = new DataTable();
        lblidpedido.Text = Session["idpedido"].ToString();
        lblidCliente.Text = Session["iduser"].ToString();
        mostrarmonedas();
        mostrarTarjetas();
    }

    public void mostrarmonedas()
    {
        lstmonedas.DataSource = datos.extrae("listaMonedas");
        lstmonedas.DataTextField = "moneda";
        lstmonedas.DataValueField = "idmonedas";
        lstmonedas.DataBind();
    }
    public void mostrarTarjetas()
    {
        lstTipoTarj.DataSource = datos2.extrae("listaTarjetas");
        lstTipoTarj.DataTextField = "cia";
        lstTipoTarj.DataValueField = "idtipotarj";
        lstTipoTarj.DataBind();
    }

    protected void btnpagar_Click(object sender, EventArgs e)
    {
        Session["iduser"] = "1";
        Response.Write("<Script>alert('Se esta efectuando el pago');window.location.href='ReportePedido.aspx'</script>");

    }

    public int insertapedido()
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        cmd.Connection = cn.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "pedido_ins";
        SqlParameter codigo = new SqlParameter("@idpedido", SqlDbType.Int);
        codigo.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(codigo);
        cmd.Parameters.Add("@IdCliente", SqlDbType.NChar).Value = Session["iduser"];
        cmd.Parameters.Add("@IdPedido", SqlDbType.NChar).Value = Session["iduser"];
        cmd.Parameters.Add("@moneda", SqlDbType.Int).Value = int.Parse(lstmonedas.SelectedItem.Value);
        cmd.Parameters.Add("@TipoTarjetas", SqlDbType.Int).Value = int.Parse(lstTipoTarj.SelectedItem.Value);
        cmd.Parameters.Add("@NumeroTarjeta", SqlDbType.NVarChar).Value = txtNumTarj.Text.ToString();
        cmd.Parameters.Add("@DireccionDestinatario", SqlDbType.NVarChar).Value = txtTitular.Text.ToString();
        cmd.Parameters.Add("@CiudadDestinatario", SqlDbType.NVarChar).Value = txtanio.Text.ToString();
        cmd.Parameters.Add("@RegionDestinatario", SqlDbType.NVarChar).Value = txtmes.Text.ToString();
        cmd.Parameters.Add("@CodPostalDestinatario", SqlDbType.NVarChar).Value = txtcvv.Text.ToString();
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        int idp = Convert.ToInt32(cmd.Parameters["@idpedido"].Value);
        return idp;
    }
}