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

public class Students_B : System.Web.UI.Page
{
    Common CO = new Common(); //M
    SqlDataReader dr;

	public Students_B()
	{
		// TODO: Add constructor logic here
	}

    public string M_Extra { get; set; }
    public string M_EnrollNo{ get; set; }
    public Int64 M_StudentId{ get; set; }
    public string M_StudentName{ get; set; }
    public Int64 M_InstitiuteId{ get; set; }
    public Int64 M_DepartmentId{ get; set; }
    public Int64 M_Semester{ get; set; }
    public string M_Year{ get; set; }
    public Int64 M_Gender{ get; set; }
    public string M_EmailId{ get; set; }
    public string M_ContactNo{ get; set; }
    public string M_MeritNo{ get; set; }
    public string M_Password{ get; set; }


    public DataSet StudentsAdd()
    {
        SqlParameter[] param = { 
                                 
    new SqlParameter("@StudentName",M_StudentName),
    new SqlParameter("@EnrollNo",M_EnrollNo),
    new SqlParameter("@InstitiuteId",M_InstitiuteId),
    new SqlParameter("@DepartmentId",M_DepartmentId),
    new SqlParameter("@Semester",M_Semester),
    new SqlParameter("@Year",M_Year),
    new SqlParameter("@Gender",M_Gender),
    new SqlParameter("@EmailId",M_EmailId),
    new SqlParameter("@ContactNo",M_ContactNo),
    new SqlParameter("@MeritNo",M_MeritNo),
    new SqlParameter("@Password",M_Password)
                               };

       return CO.RunProcDS("StudentsAdd_SP", param);
    }
    
    public DataSet StudentsSimpleAdd()
    {
        SqlParameter[] param = {                                   
                                  

                               };

        return CO.RunProcDS("StudentsSimpleAdd_SP", param);
    }
    

    public DataSet StudentsEdit()
    {
        SqlParameter[] param = { 
                               new SqlParameter("@StudentId", SqlDbType.BigInt),
                                };
        param[0].Value = M_StudentId;
        return CO.RunProcDS("StudentsEdit_SP", param);
    }

   
  
    public void StudentsUpdate()
    {
        SqlParameter[] param = { 
	new SqlParameter("@StudentId",M_StudentId),
    new SqlParameter("@EnrollNo",M_EnrollNo),                                 
    new SqlParameter("@StudentName",M_StudentName),
    new SqlParameter("@InstitiuteId",M_InstitiuteId),
    new SqlParameter("@DepartmentId",M_DepartmentId),
    new SqlParameter("@Semester",M_Semester),
    new SqlParameter("@Year",M_Year),
    new SqlParameter("@Gender",M_Gender),
    new SqlParameter("@EmailId",M_EmailId),
    new SqlParameter("@ContactNo",M_ContactNo),
    new SqlParameter("@MeritNo",M_MeritNo),
    new SqlParameter("@Password",M_Password)
                               };

        CO.RunProc("StudentsUpdate_SP",param,0);
    }


    public void StudentsDelete()
    {
	SqlParameter[] param = { new SqlParameter("@StudentId", SqlDbType.BigInt)
 };  
         param[0].Value = M_StudentId;
        CO.RunProc("StudentsDelete_SP",param,0);      
    }

    public DataSet MasterGrid()
    {       
        SqlParameter[] param = { 
                               new SqlParameter("@Extra", M_Extra)
                                };       
        return CO.RunProcDS("StudentsGrid_SP", param);        
    }
}

