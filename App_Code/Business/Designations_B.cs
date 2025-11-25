using System;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public class Designations_B : System.Web.UI.Page
{
    Common CO = new Common(); //M
    SqlDataReader dr;

	public Designations_B()
	{
		// TODO: Add constructor logic here
	}

    public string M_Extra { get; set; }
    
    public Int64 M_DesignationId{ get; set; }
    public string M_DesignationName{ get; set; }

   

    

    


    

    




    public DataSet DesignationsAdd()
    {
        SqlParameter[] param = { 
                                 
    new SqlParameter("@DesignationName",M_DesignationName)
                               };

        return CO.RunProcDS("DesignationsAdd_SP", param);
    }
    
    public DataSet DesignationsSimpleAdd()
    {
        SqlParameter[] param = {                                   
                                  

                               };

        return CO.RunProcDS("DesignationsSimpleAdd_SP", param);
    }
    

    public DataSet DesignationsEdit()
    {
        SqlParameter[] param = { 
                               new SqlParameter("@DesignationId", SqlDbType.BigInt),
                                };
        param[0].Value = M_DesignationId;
        return CO.RunProcDS("DesignationsEdit_SP", param);
    }

   
  
    public void DesignationsUpdate()
    {
        SqlParameter[] param = { 
	new SqlParameter("@DesignationId",M_DesignationId),
                                 
    new SqlParameter("@DesignationName",M_DesignationName)
                               };

        CO.RunProc("DesignationsUpdate_SP",param,0);
    }


    public void DesignationsDelete()
    {
	SqlParameter[] param = { new SqlParameter("@DesignationId", SqlDbType.BigInt)
 };  
         param[0].Value = M_DesignationId;
        CO.RunProc("DesignationsDelete_SP",param,0);      
    }

    public DataSet MasterGrid()
    {       
        SqlParameter[] param = { 
                               new SqlParameter("@Extra", M_Extra)
                                };       
        return CO.RunProcDS("DesignationsGrid_SP", param);        
    }
}

