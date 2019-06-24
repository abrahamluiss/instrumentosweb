using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de conexionALSE
/// </summary>
public class conexionALSE
{

    public SqlConnection cad = new SqlConnection("Data Source=.;Initial Catalog=instrumentosweb;Integrated Security=True");
    public void conectar()
    {
        cad.Open();
    }
    public void desconectar()
    {
        cad.Close();
    }
}