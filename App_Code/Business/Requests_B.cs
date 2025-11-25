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

public class Requests_B : System.Web.UI.Page
{
    Common CO = new Common();
    SqlDataReader dr;

	public Requests_B()
	{
		// TODO: Add constructor logic here
	}

    public string M_Extra { get; set; }
    
    public Int64 M_RequestId{ get; set; }
    public Int64 M_StudentId{ get; set; }
    public string M_CurrentYear{ get; set; }
    public string M_Semester{ get; set; }
    public string M_ReasonofTransfer{ get; set; }
    public string M_OtherParticular{ get; set; }
    public Int64 M_Approve1{ get; set; }
    public Int64 M_StatusId{ get; set; }
    public string M_AddmissionLetter{ get; set; }
    public string M_IdentiyCard{ get; set; }
    public string M_FeeReceipt{ get; set; }
    public string M_MedicalCertificate{ get; set; }
    public string M_Marksheet{ get; set; }
    public string M_DeathCertificate{ get; set; }


    
    public Int64 D_RequestDetId{ get; set; }
    public Int64 D_InstituteId{ get; set; }
    public Int64 D_DeptId{ get; set; }

    
    
    public DataSet RequestsAdd()
    {
        SqlParameter[] param = {  	
                                 
    new SqlParameter("@StudentId",M_StudentId),
    new SqlParameter("@CurrentYear",M_CurrentYear),
    new SqlParameter("@Semester",M_Semester),
    new SqlParameter("@ReasonofTransfer",M_ReasonofTransfer),
    new SqlParameter("@OtherParticular",M_OtherParticular),
    new SqlParameter("@Approve1",M_Approve1),
    new SqlParameter("@StatusId",M_StatusId),
                               };

        return CO.RunProcDS("RequestsAdd_SP", param);
    }



  public DataSet RequestsSimpleAdd()
    {
        SqlParameter[] param = {                                   
                                  

                               };

        return CO.RunProcDS("RequestsSimpleAdd_SP", param);
    }
       
 

    public DataSet RequestsEdit()
    {
        SqlParameter[] param = { 
                               new SqlParameter("@RequestId", SqlDbType.BigInt)
                                };
        param[0].Value = M_RequestId;
        return CO.RunProcDS("RequestsEdit_SP", param);
    }

    public void RequestsDOCUpdate()
    {
        SqlParameter[] param = { 
    new SqlParameter("@RequestId",M_RequestId),
    new SqlParameter("@AddmissionLetter",M_AddmissionLetter),
    new SqlParameter("@IdentiyCard",M_IdentiyCard),
    new SqlParameter("@FeeReceipt",M_FeeReceipt),
    new SqlParameter("@MedicalCertificate",M_MedicalCertificate),
    new SqlParameter("@Marksheet",M_Marksheet),
    new SqlParameter("@DeathCertificate",M_DeathCertificate)
                               };
           CO.RunProc("RequestsDOCUpdate_SP",param,0);
    }


    public void RequestsUpdate()
    {
        SqlParameter[] param = { 
	new SqlParameter("@RequestId",M_RequestId),
                                 
    new SqlParameter("@StudentId",M_StudentId),
    new SqlParameter("@CurrentYear",M_CurrentYear),
    new SqlParameter("@Semester",M_Semester),
    new SqlParameter("@ReasonofTransfer",M_ReasonofTransfer),
    new SqlParameter("@OtherParticular",M_OtherParticular),
    new SqlParameter("@Approve1",M_Approve1),
    new SqlParameter("@StatusId",M_StatusId),
    new SqlParameter("@AddmissionLetter",M_AddmissionLetter),
    new SqlParameter("@IdentiyCard",M_IdentiyCard),
    new SqlParameter("@FeeReceipt",M_FeeReceipt),
    new SqlParameter("@MedicalCertificate",M_MedicalCertificate),
    new SqlParameter("@Marksheet",M_Marksheet),
    new SqlParameter("@DeathCertificate",M_DeathCertificate)
                               };

        CO.RunProc("RequestsUpdate_SP",param,0);
    }


	public DataSet RequestsDetailSimpleAdd()
    {
        SqlParameter[] param = {   
				  new SqlParameter("@RequestId",M_RequestId),                                
                                  

                               };

        return CO.RunProcDS("RequestsDetailSimpleAdd_SP", param);
    }
    

    public void RequestsDetailSimpleUpdate()
    {
        SqlParameter[] param = { 
	new SqlParameter("@RequestDetId",D_RequestDetId),
	new SqlParameter("@RequestId",M_RequestId),
                                 
    new SqlParameter("@InstituteId",D_InstituteId),
    new SqlParameter("@DeptId",D_DeptId),

                               };

        CO.RunProc("RequestsDetailSimpleUpdate_SP",param,0);
    }


    ///DELETE////
    public void RequestsDelete()
    {
	SqlParameter[] param = { new SqlParameter("@RequestId", SqlDbType.BigInt),
        			 };  
         param[0].Value = M_RequestId;
        CO.RunProc("RequestsDelete_SP",param,0);      
    }

    public DataSet MasterGrid()
    {       
        SqlParameter[] param = { 
                               new SqlParameter("@Extra", M_Extra),
                                };       
        return CO.RunProcDS("RequestsGrid_SP", param);        
    }



    //////////////////DETAIL ////////FUNCTIONS///////////////////////
    /// Add
    //
    public DataSet RequestsDetailAdd()
    {
        SqlParameter[] param = { 
                                  new SqlParameter("@RequestId",M_RequestId),
                                 
    new SqlParameter("@InstituteId",D_InstituteId),
    new SqlParameter("@DeptId",D_DeptId)//Add Detail parameters
		//MAP Ends
                               };

        return CO.RunProcDS("RequestsDetailAdd_SP", param);
    }

    
    ///Fetch EDIT////
    //
    public DataSet RequestsDetailEdit()
    {
        SqlParameter[] param = { 
                               new SqlParameter("@RequestDetId", SqlDbType.BigInt),
			       new SqlParameter("@RequestId",M_RequestId),
			     
                                };
        param[0].Value = D_RequestDetId;
        return CO.RunProcDS("RequestsDetailEdit_SP", param);
    }

   
    /// update  ///////////////
    public void RequestsDetailUpdate()
    {
        SqlParameter[] param = { 
	new SqlParameter("@RequestDetId",D_RequestDetId),
	new SqlParameter("@RequestId",M_RequestId),        
                                 
    new SqlParameter("@InstituteId",D_InstituteId),
    new SqlParameter("@DeptId",D_DeptId),

                               };
        CO.RunProc("RequestsDetailUpdate_SP",param,0);
    }


  
    public void RequestsDetailDelete()
    {
	SqlParameter[] param = { new SqlParameter("@RequestDetId", SqlDbType.BigInt),
				 new SqlParameter("@RequestId",M_RequestId),
 };  
         param[0].Value = D_RequestDetId;
        CO.RunProc("RequestsDetailDelete_SP",param,0);      
    }

    public DataSet DetailGrid()
    {       
        SqlParameter[] param = { 
                               new SqlParameter("@Extra", M_Extra)                            
                                };       
        return CO.RunProcDS("RequestsDetailGrid_SP", param);        
    }

}

