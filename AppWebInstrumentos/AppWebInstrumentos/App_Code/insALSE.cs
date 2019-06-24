using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de insALSE
/// </summary>
public class insALSE
{

    conexionALSE cn = new conexionALSE();
    public void inserta(string nombre_sp, string nom_param1, string valor_param1, string nom_param2
           , string valor_param2)
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        cmd.Connection = cn.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = nombre_sp;
        cmd.Parameters.Add(nom_param1, SqlDbType.NVarChar).Value = valor_param1;
        cmd.Parameters.Add(nom_param2, SqlDbType.NVarChar).Value = valor_param2;
        cmd.Connection.Open();
        cmd.ExecuteNonQuery(); //NO es consulta, sino inserción
        cmd.Connection.Close();
    }

    public int get_int(string nombre_sp, string nombre_param1_out, int valor_param1,
        string nombre_param2, int valor_param2)
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        cmd.Connection = cn.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = nombre_sp;
        SqlParameter codigo = new SqlParameter(nombre_param1_out, SqlDbType.Int);
        codigo.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(codigo);
        cmd.Parameters.Add(nombre_param2, SqlDbType.Int).Value = valor_param2;
        cn.conectar();
        cmd.ExecuteNonQuery();
        cn.desconectar();
        int idp = Convert.ToInt32(cmd.Parameters[nombre_param1_out].Value);
        return idp;

    }

    public int get_int(string nombre_sp, string nombre_param1_out, int valor_param1,
    string nombre_param2, string valor_param2)
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        cmd.Connection = cn.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = nombre_sp;
        SqlParameter codigo = new SqlParameter(nombre_param1_out, SqlDbType.Int);
        codigo.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(codigo);
        cmd.Parameters.Add(nombre_param2, SqlDbType.VarChar).Value = valor_param2;
        cn.conectar();
        cmd.ExecuteNonQuery();
        cn.desconectar();
        int idp = Convert.ToInt32(cmd.Parameters[nombre_param1_out].Value);
        return idp;

    }

    public int get_int(string nombre_sp, string nombre_param)
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        cmd.Connection = cn.cad;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = nombre_sp;
        SqlParameter codigo = new SqlParameter(nombre_param, SqlDbType.Int);
        codigo.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(codigo);
        cn.conectar();
        cmd.ExecuteNonQuery();
        cn.desconectar();
        int idp = Convert.ToInt32(cmd.Parameters[nombre_param].Value);
        return idp;

    }

}