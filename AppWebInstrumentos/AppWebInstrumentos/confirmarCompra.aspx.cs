using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class confirmarCompra : System.Web.UI.Page
{

    consultasALSE datos = new consultasALSE();
    consultasALSE datos2 = new consultasALSE();
    consultasALSE datos3 = new consultasALSE();
    consultasALSE datos4 = new consultasALSE();
    conexionALSE cn = new conexionALSE();
    DateTime fecha = DateTime.Now;
    protected void Page_Load(object sender, EventArgs e)
    {

        string idUsuario = Session["iduser"].ToString();
        if (idUsuario.Trim().Length > 3)
        {
            mostrarDatos(idUsuario);
            monto(Convert.ToInt32(Session["idpedido"].ToString()));
        }
    }

    public void mostrarDatos(string idusuar)
    {
        DataTable dt = new DataTable();
        lblidpedido.Text = Session["idpedido"].ToString();
        lblidcliente.Text = Session["iduser"].ToString();
        lblfechapedido.Text = fecha.ToString();
        lblfechaentrega.Text = fecha.AddDays(2).ToString();
        lblfechaenvio.Text = fecha.AddDays(1).ToString();
        lstformaenvio.DataSource = datos.extrae("getListaciaenvio");
        lstformaenvio.DataTextField = "NombreCompañia";
        lstformaenvio.DataValueField = "idCompañiaEnvios";
        lstformaenvio.DataBind();

    }
    public void monto(int idtemp)
    {
        DataTable dt2 = new DataTable();
        dt2 = datos2.extrae("montopedido", "@idpedido", idtemp);
        lbltotalpagar.Text = dt2.Rows[0][0].ToString();
    }


    protected void lstdestinatario_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void rellenarxdestinatario()
    {
        DataTable dt3 = new DataTable();
        txtnombre.Text = dt3.Rows[0][3].ToString();
        txtdirecciondestinatario.Text = dt3.Rows[0][4].ToString();
        txtciudaddestino.Text = dt3.Rows[0][5].ToString();
        txtregiondestinatario.Text = dt3.Rows[0][6].ToString();
        txtcodpostal.Text = dt3.Rows[0][7].ToString();
        txtpais.Text = dt3.Rows[0][8].ToString();
    }

    protected void btnComprar_Click(object sender, EventArgs e)
    {
        int newIdPedido = insertapedido();
        //insertar detalles de pedido

        insertadetalle(newIdPedido);

        Session["iduser"] = "Abraham";
        Response.Write("<Script>alert('Se esta efectuando la compra');window.location.href='EfectuarPago.aspx'</script>");
        //Response.Redirect("~/reportepedido");

    }
    public void insertadetalle(int idpedidonuevo)
    {

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        cmd.Connection = cn.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "ins_detalle";
        cmd.Parameters.Add("@idpedidonuevo", SqlDbType.Int).Value = idpedidonuevo;
        cmd.Parameters.Add("@idpedidotemp", SqlDbType.Int).Value = Convert.ToInt32(Session["idpedido"].ToString());
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();

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
        cmd.Parameters.Add("@FechaPedido", SqlDbType.DateTime).Value = fecha;
        cmd.Parameters.Add("@FechaEntrega", SqlDbType.DateTime).Value = fecha.AddDays(2);
        cmd.Parameters.Add("@FechaEnvio", SqlDbType.DateTime).Value = fecha.AddDays(1);
        cmd.Parameters.Add("@FormaEnvio", SqlDbType.Int).Value = int.Parse(lstformaenvio.SelectedItem.Value);
        cmd.Parameters.Add("@Destinatario", SqlDbType.NVarChar).Value = txtnombre.Text.ToString();
        cmd.Parameters.Add("@DireccionDestinatario", SqlDbType.NVarChar).Value = txtdirecciondestinatario.Text.ToString();
        cmd.Parameters.Add("@CiudadDestinatario", SqlDbType.NVarChar).Value = txtciudaddestino.Text.ToString();
        cmd.Parameters.Add("@RegionDestinatario", SqlDbType.NVarChar).Value = txtregiondestinatario.Text.ToString();
        cmd.Parameters.Add("@CodPostalDestinatario", SqlDbType.NVarChar).Value = txtcodpostal.Text.ToString();
        cmd.Parameters.Add("@PaisDestinatario", SqlDbType.NVarChar).Value = txtpais.Text.ToString();
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        int idp = Convert.ToInt32(cmd.Parameters["@idpedido"].Value);
        return idp;

    }


    protected void btnautocompletar_Click(object sender, EventArgs e)
    {
        rellenarxdestinatario();
    }
}