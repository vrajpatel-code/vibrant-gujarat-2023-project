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

public class Statuses_B : System.Web.UI.Page
{
    Common CO = new Common(); //M
    SqlDataReader dr;

	public Statuses_B()
	{
		// TODO: Add constructor logic here
	}

    public string M_Extra { get; set; }
    
    public Int64 M_StatusId{ get; set; }
    public string M_StatusName{ get; set; }

   

    

    


    

    




    public DataSet StatusesAdd()
    {
        SqlParameter[] param = { 
                                 
    new SqlParameter("@StatusName",M_StatusName)
                               };

        return CO.RunProcDS("StatusesAdd_SP", param);
    }
    
    public DataSet StatusesSimpleAdd()
    {
        SqlParameter[] param = {                                   
                                  

                               };

        return CO.RunProcDS("StatusesSimpleAdd_SP", param);
    }
    

    public DataSet StatusesEdit()
    {
        SqlParameter[] param = { 
                               new SqlParameter("@StatusId", SqlDbType.BigInt),
                                };
        param[0].Value = M_StatusId;
        return CO.RunProcDS("StatusesEdit_SP", param);
    }

   
  
    public void StatusesUpdate()
    {
        SqlParameter[] param = { 
	new SqlParameter("@StatusId",M_StatusId),
                                 
    new SqlParameter("@StatusName",M_StatusName)
                               };

        CO.RunProc("StatusesUpdate_SP",param,0);
    }


    public void StatusesDelete()
    {
	SqlParameter[] param = { new SqlParameter("@StatusId", SqlDbType.BigInt)
 };  
         param[0].Value = M_StatusId;
        CO.RunProc("StatusesDelete_SP",param,0);      
    }

    public DataSet MasterGrid()
    {       
        SqlParameter[] param = { 
                               new SqlParameter("@Extra", M_Extra)
                                };       
        return CO.RunProcDS("StatusesGrid_SP", param);        
    }
}

