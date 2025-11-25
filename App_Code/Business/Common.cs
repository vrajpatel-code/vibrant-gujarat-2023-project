using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;
using System.Security;
using System.Net;
using System.Text;
using System.Collections.Generic;

public class Common : System.Web.UI.Page
{
    SqlConnection Conn;

    public Common()
    {
        Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["KJ_StudentTransferConnectionString"].ConnectionString);

    }

    public Common(String ConnName)
    {
        Conn = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnName].ConnectionString);
    }

    public string ToString(string o)
    {
        return o.ToString();
    }
    public string ToString(object o)
    {
        return o.ToString();
    }
    public Int64 ToInt64(string o)
    {
        if (o.ToString() == "" || o.ToString() == "All")
            return 0;
        else
            return Convert.ToInt64(o);
    }
    public Int64 ToInt64(Object o)
    {
        if (o.ToString() == "")
            return 0;
        else
            return Convert.ToInt64(o);
    }
    public Int32 ToInt32(string o)
    {
        if (o.ToString() == "")
            return 0;
        else
            return Convert.ToInt32(o);
    }
    public Int32 ToInt32(Object o)
    {
        if (o.ToString() == "")
            return 0;
        else
            return Convert.ToInt32(o);
    }
    public Double ToDouble(string o)
    {
        if (o.ToString() == "")
            return 0.0;
        else
            return Convert.ToDouble(o);
    }
    public Double ToDouble(Object o)
    {
        if (o.ToString() == "")
            return 0.0;
        else
            return Convert.ToDouble(o);
    }
    public DateTime ToDateTime(string o)
    {
        try
        {
            if (o == "")
                return Convert.ToDateTime("01-01-1800");
            else
                return Convert.ToDateTime(o);
        }
        catch (Exception ex)
        { return Convert.ToDateTime("01-01-1800"); }
    }

    public string FromDateTime(object o)
    {
        try
        {
            if (o.ToString() == "" || o.ToString() == null)
                return "";
            else
                return Convert.ToDateTime(o).ToString("dd-MMM-yyyy");
        }
        catch (Exception ex)
        { return ""; }
    }
    public float ToFloat(string o)
    {
        if (o.ToString() == "")
            return 0;
        else
            return float.Parse(o);
    }
    public float ToFloat(Object o)
    {
        if (o.ToString() == "")
            return 0;
        else
            return float.Parse(o.ToString());
    }
    public Boolean ToBoolean(string o)
    {
        if (o.ToString() == "")
            return false;
        else
            return Convert.ToBoolean(o);
    }

    public Boolean ToBoolean(Object o)
    {
        if (o.ToString() == "")
            return false;
        else
            return Convert.ToBoolean(o);
    }

    public System.Data.DataTable ReadTable(String SELSTR)
    {
        System.Data.DataTable DT = new System.Data.DataTable();
        try
        {
            SELSTR = SELSTR.Replace("&amp;", "&");

            SqlDataAdapter DA = new SqlDataAdapter(SELSTR, Conn);
            DA.Fill(DT);
            Conn.Open();
        }
        finally
        {
            Conn.Close();
        }
        return DT;
    }

    public SqlCommand QueryBuilder(String ProcName, SqlParameter[] param)
    {
        //SqlParameter prm;
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 60000;
        cmd.Connection = Conn;
        cmd.CommandText = ProcName;

        foreach (SqlParameter p in param)
        {
            cmd.Parameters.Add(p);
        }
        return cmd;
    }

    public SqlCommand InCmdBuilder(String ProcName, SqlParameter[] param)
    {
        SqlCommand command = QueryBuilder(ProcName, param);
        SqlParameter prm = new SqlParameter();
        prm.ParameterName = "ReturnValue";
        prm.SqlDbType = SqlDbType.Int;
        prm.Size = 4;
        prm.Scale = 0;
        prm.Precision = 0;
        prm.IsNullable = false;
        prm.Direction = ParameterDirection.ReturnValue;
        prm.SourceColumn = string.Empty;
        prm.Value = null;
        prm.SourceVersion = DataRowVersion.Default;
        command.Parameters.Add(prm);
        return command;
    }
    public void RunProc(String ProcName, SqlParameter[] param, int rows)
    {
        int rowaf;

           Conn.Open();

        SqlCommand cmd = InCmdBuilder(ProcName, param);
        cmd.CommandTimeout = 60000;
        rowaf = cmd.ExecuteNonQuery();

        Conn.Close();

    }

    public void RunProc(String ProcName, SqlParameter[] param)
    {
        int rowaf;

        Conn.Open();

        SqlCommand cmd = InCmdBuilder(ProcName, param);
        cmd.CommandTimeout = 60000;
        rowaf = cmd.ExecuteNonQuery();

        Conn.Close();

    }

    public DataSet RunProcDS(String ProcName, SqlParameter[] param)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();



        cmd = new SqlCommand();
        Conn.Close();
        da = new SqlDataAdapter("", Conn);
        cmd = QueryBuilder(ProcName, param);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = ProcName;
        cmd.Connection = Conn;
        cmd.CommandTimeout = 60000;

        da.SelectCommand = cmd;
        da.Fill(ds);
        Conn.Close();


        return ds;
    }

    public DataSet RunProcDS(String ProcName)
    {
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds = new DataSet();

      
        cmd = new SqlCommand();
        da = new SqlDataAdapter("", Conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = ProcName;
        cmd.Connection = Conn;
        cmd.CommandTimeout = 60000;
        da.SelectCommand = cmd;
        da.Fill(ds);
        Conn.Close();

        
        return ds;
    }

}