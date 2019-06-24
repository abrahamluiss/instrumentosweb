using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de consultasALSE
/// </summary>
public class consultasALSE
{
    conexionALSE con = new conexionALSE();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter();
    SqlCommand cmd = new SqlCommand();

    public DataTable extrae(string nombreSP)
    {

        cmd.Connection = con.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = nombreSP;
        con.conectar();
        da.SelectCommand = cmd;
        da.Fill(dt);
        con.desconectar();
        return dt;
    }

    public DataTable extrae(string cadBuscada, string nombreparam, string nombreSP)
    {

        cmd.Connection = con.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = nombreSP;
        cmd.Parameters.Add(nombreparam, SqlDbType.VarChar).Value = cadBuscada;
        con.conectar();
        da.SelectCommand = cmd;
        da.Fill(dt);
        con.desconectar();
        return dt;
    }

    public DataTable extrae(string nombreSP, string nombreparam, int valorparam)
    {

        cmd.Connection = con.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = nombreSP;
        cmd.Parameters.Add(nombreparam, SqlDbType.Int).Value = valorparam;
        con.conectar();
        da.SelectCommand = cmd;
        da.Fill(dt);
        con.desconectar();
        return dt;
    }

    public DataTable extrae(int valorbuscado, string nombreparam, string nombreSP)
    {

        cmd.Connection = con.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = nombreSP;
        cmd.Parameters.Add(nombreparam, SqlDbType.Int).Value = valorbuscado;
        con.conectar();
        da.SelectCommand = cmd;
        da.Fill(dt);
        con.desconectar();
        return dt;
    }
}