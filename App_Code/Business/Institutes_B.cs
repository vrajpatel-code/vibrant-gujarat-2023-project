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

public class Institutes_B : System.Web.UI.Page
{
    Common CO = new Common();
    SqlDataReader dr;

	public Institutes_B()
	{
		// TODO: Add constructor logic here
	}

    public string M_Extra { get; set; }
    
    public Int64 M_InstituteId{ get; set; }
    public string M_InstituteName{ get; set; }
    public string M_InstituteAddress{ get; set; }
    public string M_ContactNo{ get; set; }
    public string M_Email{ get; set; }
    public string M_Website{ get; set; }


    
    public Int64 D_InstituteDepartmentId{ get; set; }
    public string D_DepartmentName{ get; set; }

    

 
    

   
    



    
    public DataSet InstitutesAdd()
    {
        SqlParameter[] param = {  	
                                 
    new SqlParameter("@InstituteName",M_InstituteName),
    new SqlParameter("@InstituteAddress",M_InstituteAddress),
    new SqlParameter("@ContactNo",M_ContactNo),
    new SqlParameter("@Email",M_Email),
    new SqlParameter("@Website",M_Website) 
                               };

        return CO.RunProcDS("InstitutesAdd_SP", param);
    }

  public DataSet InstitutesSimpleAdd()
    {
        SqlParameter[] param = {                                   
                                  

                               };

        return CO.RunProcDS("InstitutesSimpleAdd_SP", param);
    }
       
 

    public DataSet InstitutesEdit()
    {
        SqlParameter[] param = { 
                               new SqlParameter("@InstituteId", SqlDbType.BigInt)
                                };
        param[0].Value = M_InstituteId;
        return CO.RunProcDS("InstitutesEdit_SP", param);
    }

    public void InstitutesUpdate()
    {
        SqlParameter[] param = { 
	new SqlParameter("@InstituteId",M_InstituteId),
                                 
    new SqlParameter("@InstituteName",M_InstituteName),
    new SqlParameter("@InstituteAddress",M_InstituteAddress),
    new SqlParameter("@ContactNo",M_ContactNo),
    new SqlParameter("@Email",M_Email),
    new SqlParameter("@Website",M_Website)
                               };

        CO.RunProc("InstitutesUpdate_SP",param,0);
    }


	public DataSet InstitutesDetailSimpleAdd()
    {
        SqlParameter[] param = {   
				  new SqlParameter("@InstituteId",M_InstituteId),                                
                                  

                               };

        return CO.RunProcDS("InstitutesDetailSimpleAdd_SP", param);
    }
    

    public void InstitutesDetailSimpleUpdate()
    {
        SqlParameter[] param = { 
	new SqlParameter("@InstituteDepartmentId",D_InstituteDepartmentId),
	new SqlParameter("@InstituteId",M_InstituteId),
                                 
    new SqlParameter("@DepartmentName",D_DepartmentName),

                               };

        CO.RunProc("InstitutesDetailSimpleUpdate_SP",param,0);
    }


    ///DELETE////
    public void InstitutesDelete()
    {
	SqlParameter[] param = { new SqlParameter("@InstituteId", SqlDbType.BigInt),
        			 };  
         param[0].Value = M_InstituteId;
        CO.RunProc("InstitutesDelete_SP",param,0);      
    }

    public DataSet MasterGrid()
    {       
        SqlParameter[] param = { 
                               new SqlParameter("@Extra", M_Extra),
                                };       
        return CO.RunProcDS("InstitutesGrid_SP", param);        
    }



    //////////////////DETAIL ////////FUNCTIONS///////////////////////
    /// Add
    //
    public DataSet InstitutesDetailAdd()
    {
        SqlParameter[] param = { 
                                  new SqlParameter("@InstituteId",M_InstituteId),
                                 
    new SqlParameter("@DepartmentName",D_DepartmentName)//Add Detail parameters
		//MAP Ends
                               };

        return CO.RunProcDS("InstitutesDetailAdd_SP", param);
    }

    
    ///Fetch EDIT////
    //
    public DataSet InstitutesDetailEdit()
    {
        SqlParameter[] param = { 
                               new SqlParameter("@InstituteDepartmentId", SqlDbType.BigInt),
			       new SqlParameter("@InstituteId",M_InstituteId),
			     
                                };
        param[0].Value = D_InstituteDepartmentId;
        return CO.RunProcDS("InstitutesDetailEdit_SP", param);
    }

   
    /// update  ///////////////
    public void InstitutesDetailUpdate()
    {
        SqlParameter[] param = { 
	new SqlParameter("@InstituteDepartmentId",D_InstituteDepartmentId),
	new SqlParameter("@InstituteId",M_InstituteId),        
                                 
    new SqlParameter("@DepartmentName",D_DepartmentName),

                               };
        CO.RunProc("InstitutesDetailUpdate_SP",param,0);
    }


  
    public void InstitutesDetailDelete()
    {
	SqlParameter[] param = { new SqlParameter("@InstituteDepartmentId", SqlDbType.BigInt),
				 new SqlParameter("@InstituteId",M_InstituteId),
 };  
         param[0].Value = D_InstituteDepartmentId;
        CO.RunProc("InstitutesDetailDelete_SP",param,0);      
    }

    public DataSet DetailGrid()
    {       
        SqlParameter[] param = { 
                               new SqlParameter("@Extra", M_Extra)                            
                                };       
        return CO.RunProcDS("InstitutesDetailGrid_SP", param);        
    }

}

