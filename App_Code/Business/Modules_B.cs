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

public class Modules_B : System.Web.UI.Page
{
    Common CO = new Common(); //M
    SqlDataReader dr;

	public Modules_B()
	{
		// TODO: Add constructor logic here
	}

    public string M_Extra { get; set; }
    
    public Int64 M_ModuleId{ get; set; }
    public string M_ModuleName{ get; set; }

   

    

    


    

    




    public DataSet ModulesAdd()
    {
        SqlParameter[] param = { 
                                 
    new SqlParameter("@ModuleName",M_ModuleName)
                               };

        return CO.RunProcDS("ModulesAdd_SP", param);
    }
    
    public DataSet ModulesSimpleAdd()
    {
        SqlParameter[] param = {                                   
                                  

                               };

        return CO.RunProcDS("ModulesSimpleAdd_SP", param);
    }
    

    public DataSet ModulesEdit()
    {
        SqlParameter[] param = { 
                               new SqlParameter("@ModuleId", SqlDbType.BigInt),
                                };
        param[0].Value = M_ModuleId;
        return CO.RunProcDS("ModulesEdit_SP", param);
    }

   
  
    public void ModulesUpdate()
    {
        SqlParameter[] param = { 
	new SqlParameter("@ModuleId",M_ModuleId),
                                 
    new SqlParameter("@ModuleName",M_ModuleName)
                               };

        CO.RunProc("ModulesUpdate_SP",param,0);
    }


    public void ModulesDelete()
    {
	SqlParameter[] param = { new SqlParameter("@ModuleId", SqlDbType.BigInt)
 };  
         param[0].Value = M_ModuleId;
        CO.RunProc("ModulesDelete_SP",param,0);      
    }

    public DataSet MasterGrid()
    {       
        SqlParameter[] param = { 
                               new SqlParameter("@Extra", M_Extra)
                                };       
        return CO.RunProcDS("ModulesGrid_SP", param);        
    }
}

