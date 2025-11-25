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

public class Users_B : System.Web.UI.Page
{
    Common CO = new Common(); //M
    SqlDataReader dr;

	public Users_B()
	{
		// TODO: Add constructor logic here
	}

    public string M_Extra { get; set; }
    
    public Int64 M_UserId{ get; set; }
    public string M_Username{ get; set; }
    public string M_Password{ get; set; }
    public string M_UserFullName{ get; set; }
    public string M_EmailId{ get; set; }
    public Int64 M_InstituteId{ get; set; }
    public Int64 M_DepartmentId{ get; set; }
    public Int64 M_DesignationId{ get; set; }
    public Int64 M_RollId{ get; set; }

   

    

    


    

    




    public DataSet UsersAdd()
    {
        SqlParameter[] param = { 
                                 
    new SqlParameter("@Username",M_Username),
    new SqlParameter("@Password",M_Password),
    new SqlParameter("@UserFullName",M_UserFullName),
    new SqlParameter("@EmailId",M_EmailId),
    new SqlParameter("@InstituteId",M_InstituteId),
    new SqlParameter("@DepartmentId",M_DepartmentId),
    new SqlParameter("@DesignationId",M_DesignationId),
    new SqlParameter("@RollId",M_RollId)
                               };

        return CO.RunProcDS("UsersAdd_SP", param);
    }
    
    public DataSet UsersSimpleAdd()
    {
        SqlParameter[] param = {                                   
                                  

                               };

        return CO.RunProcDS("UsersSimpleAdd_SP", param);
    }
    

    public DataSet UsersEdit()
    {
        SqlParameter[] param = { 
                               new SqlParameter("@UserId", SqlDbType.BigInt),
                                };
        param[0].Value = M_UserId;
        return CO.RunProcDS("UsersEdit_SP", param);
    }

   
  
    public void UsersUpdate()
    {
        SqlParameter[] param = { 
	new SqlParameter("@UserId",M_UserId),
                                 
    new SqlParameter("@Username",M_Username),
    new SqlParameter("@Password",M_Password),
    new SqlParameter("@UserFullName",M_UserFullName),
    new SqlParameter("@EmailId",M_EmailId),
    new SqlParameter("@InstituteId",M_InstituteId),
    new SqlParameter("@DepartmentId",M_DepartmentId),
    new SqlParameter("@DesignationId",M_DesignationId),
    new SqlParameter("@RollId",M_RollId)
                               };

        CO.RunProc("UsersUpdate_SP",param,0);
    }


    public void UsersDelete()
    {
	SqlParameter[] param = { new SqlParameter("@UserId", SqlDbType.BigInt)
 };  
         param[0].Value = M_UserId;
        CO.RunProc("UsersDelete_SP",param,0);      
    }

    public DataSet MasterGrid()
    {       
        SqlParameter[] param = { 
                               new SqlParameter("@Extra", M_Extra)
                                };       
        return CO.RunProcDS("UsersGrid_SP", param);        
    }
}

