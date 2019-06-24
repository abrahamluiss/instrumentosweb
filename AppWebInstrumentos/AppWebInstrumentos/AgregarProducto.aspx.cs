using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AgregarProducto : System.Web.UI.Page
{
    consultasALSE datos = new consultasALSE();
    consultasALSE datos1 = new consultasALSE();
    conexionALSE con = new conexionALSE();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            listaMarcas();
            listaCategorias();
        }
        deshabilitar(false);
        btnGuardar.Enabled = false;
        btnmodificar.Enabled = true;
        btnnuevo.Enabled = true;
    }
    public void listaMarcas()
    {
        lstMarcas.DataSource = datos.extrae("listaMarcas");
        lstMarcas.DataTextField = "nombremarca";
        lstMarcas.DataValueField = "idMarca";
        lstMarcas.DataBind();
    }
    public void listaCategorias()
    {
        lstCategoria.DataSource = datos1.extrae("listaCategorias");
        lstCategoria.DataTextField = "nombrecategoria";
        lstCategoria.DataValueField = "idCategorias";
        lstCategoria.DataBind();
    }
    public void insertarproducto()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "insproducto";
        cmd.Parameters.Add("@nombreProducto", SqlDbType.VarChar).Value = txtNombre.Text;
        cmd.Parameters.Add("@idMarca", SqlDbType.Int).Value = lstMarcas.SelectedValue;
        cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = lstCategoria.SelectedValue;
        cmd.Parameters.Add("@cantidadPorUnidad", SqlDbType.VarChar).Value = txtCantidad.Text.ToString();
        cmd.Parameters.Add("@precioUnidad", SqlDbType.Money).Value = double.Parse(txtPrecio.Text.ToString());
        cmd.Parameters.Add("@unidadesEnExistencia", SqlDbType.Int).Value = int.Parse(txtUniExis.Text.ToString());
        cmd.Parameters.Add("@unidadesEnPedido", SqlDbType.Int).Value = int.Parse(txtUniPedid.Text.ToString());
        cmd.Parameters.Add("@nivelNuevoPedido", SqlDbType.Int).Value = int.Parse(txtnivel.Text.ToString());
        cmd.Parameters.Add("@suspendido", SqlDbType.Bit).Value = "false";
        cmd.Parameters.Add("@serie", SqlDbType.VarChar).Value = txtserie.Text;
        cmd.Parameters.Add("@imagen", SqlDbType.NVarChar).Value = imgproducto.ImageUrl.ToString();
        con.conectar();
        cmd.ExecuteNonQuery();
        con.desconectar();
    }

    public void modificarproducto()
    {

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "upproducto";
        cmd.Parameters.Add("@idproducto", SqlDbType.Int).Value = int.Parse(txtIDProduct.Text.ToString());
        cmd.Parameters.Add("@nombreProducto", SqlDbType.VarChar).Value = txtNombre.Text;
        cmd.Parameters.Add("@idProveedor", SqlDbType.Int).Value = lstMarcas.SelectedValue;
        cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = lstCategoria.SelectedValue;
        cmd.Parameters.Add("@cantidadPorUnidad", SqlDbType.VarChar).Value = txtCantidad.Text.ToString();
        cmd.Parameters.Add("@precioUnidad", SqlDbType.Money).Value = double.Parse(txtPrecio.Text.ToString());
        cmd.Parameters.Add("@unidadesEnExistencia", SqlDbType.Int).Value = int.Parse(txtUniExis.Text.ToString());
        cmd.Parameters.Add("@unidadesEnPedido", SqlDbType.Int).Value = int.Parse(txtUniPedid.Text.ToString());
        cmd.Parameters.Add("@nivelNuevoPedido", SqlDbType.Int).Value = int.Parse(txtnivel.Text.ToString());
        cmd.Parameters.Add("@suspendido", SqlDbType.Bit).Value = "false";
        cmd.Parameters.Add("@serie", SqlDbType.VarChar).Value = txtserie.Text;
        cmd.Parameters.Add("@imagen", SqlDbType.NVarChar).Value = imgproducto.ImageUrl.ToString();
        con.conectar();
        cmd.ExecuteNonQuery();
        con.desconectar();
    }

    protected void BbtnSubirImg_Click(object sender, EventArgs e)
    {
        if (FileUploadx.HasFile)
        {
            string archi = FileUploadx.FileName;
            FileUploadx.SaveAs(MapPath("~/img/" + archi));
            imgproducto.ImageUrl = "~/img/" + archi;
        }
        deshabilitar(true);
        btnGuardar.Enabled = true;
        btnmodificar.Enabled = false;
        btnnuevo.Enabled = false;
    }

    protected void btnBuscarProduc_Click(object sender, EventArgs e)
    {

        grdListaProductos.DataSource = datos.extrae(txtBuscarProduc.Text.ToString(), "@nombre", "buscaproductosxnombre");
        grdListaProductos.DataBind();

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (lbloperacion.Text == "m")
        {
            modificarproducto();
            Response.Write("<Script>alert('Producto Modificado');</script>");
        }
        else
        {
            insertarproducto();
            Response.Write("<Script>alert('Producto Insertado');</script>");
        }
    }

    protected void grdListaProductos_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow fila = grdListaProductos.SelectedRow;
        int idProd = Convert.ToInt32(grdListaProductos.DataKeys[fila.RowIndex].Value);
        DataTable tabla = new DataTable();
        tabla = datos.extrae(idProd, "@idproducto", "buscaproductoxid");
        txtIDProduct.Text = tabla.Rows[0][0].ToString();
        txtNombre.Text = tabla.Rows[0][1].ToString();
        lstMarcas.SelectedItem.Text = tabla.Rows[0][2].ToString();
        lstCategoria.SelectedItem.Text = tabla.Rows[0][3].ToString();
        txtCantidad.Text = tabla.Rows[0][4].ToString();
        txtPrecio.Text = tabla.Rows[0][5].ToString();
        txtUniExis.Text = tabla.Rows[0][6].ToString();
        txtUniPedid.Text = tabla.Rows[0][7].ToString();
        txtnivel.Text = tabla.Rows[0][8].ToString();
        if (tabla.Rows[0][9].ToString() == "1") chksuspendido.Checked = true;
        else chksuspendido.Checked = false;
        txtserie.Text = tabla.Rows[0][10].ToString();
        imgproducto.ImageUrl = tabla.Rows[0][11].ToString();
    }

    public void deshabilitar(Boolean estado)
    {
        txtIDProduct.Enabled = estado;
        txtNombre.Enabled = estado;
        lstCategoria.Enabled = estado;
        lstMarcas.Enabled = estado;
        txtCantidad.Enabled = estado;
        txtPrecio.Enabled = estado;
        txtUniExis.Enabled = estado;
        txtUniPedid.Enabled = estado;
        txtnivel.Enabled = estado;
        txtserie.Enabled = estado;
        FileUploadx.Enabled = estado;
    }

    protected void btnmodificar_Click(object sender, EventArgs e)
    {
        lbloperacion.Text = "m";
        deshabilitar(true);
        btnGuardar.Enabled = true;
        btnmodificar.Enabled = false;
        btnnuevo.Enabled = false;
        txtIDProduct.Enabled = false;
    }

    protected void btnnuevo_Click(object sender, EventArgs e)
    {
        lbloperacion.Text = "n";
        limpiar();
        deshabilitar(true);
        btnGuardar.Enabled = true;
        btnmodificar.Enabled = false;
        btnnuevo.Enabled = false;
        txtIDProduct.Enabled = false;
    }

    public void limpiar()
    {
        txtIDProduct.Text = string.Empty;
        txtNombre.Text = string.Empty;
        lstCategoria.ClearSelection();
        lstMarcas.ClearSelection();
        txtCantidad.Text = string.Empty;
        txtPrecio.Text = string.Empty;
        txtUniExis.Text = string.Empty;
        txtUniPedid.Text = string.Empty;
        txtnivel.Text = string.Empty;
        chksuspendido.Checked = false;
        txtserie.Text = string.Empty;
        imgproducto.ImageUrl = null;
        FileUploadx.Attributes.Clear();
        txtBuscarProduc.Text = string.Empty;
    }

    protected void btnCancelar_Click1(object sender, EventArgs e)
    {
        btnGuardar.Enabled = false;
        btnmodificar.Enabled = true;
        btnnuevo.Enabled = true;
        deshabilitar(true);
        txtIDProduct.Enabled = false;
        limpiar();
    }

}