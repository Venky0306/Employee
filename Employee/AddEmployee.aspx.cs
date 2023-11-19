using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Ajax.Utilities;
using System.Security.Policy;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Employee
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Upload(object sender, EventArgs e)
        {
            //Upload and save the file
            string excelPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(excelPath);

            string conString = string.Empty;
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            switch (extension)
            {
                case ".xls": //Excel 97-03
                    conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07 or higher
                    conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                    break;

            }
            conString = string.Format(conString, excelPath);
            using (OleDbConnection excel_con = new OleDbConnection(conString))
            {
                excel_con.Open();
                string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                DataTable dtExcelData = new DataTable();

                //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.
                dtExcelData.Columns.AddRange(new DataColumn[13] {
                    new DataColumn("EmployeeId", typeof(string)),
                    new DataColumn("EmployeeName",typeof(string)),
                    new DataColumn("DateOfBirth", typeof(string)),
                    new DataColumn("Age", typeof(string)),
                    new DataColumn("Salary", typeof(string)),
                    new DataColumn("Department", typeof(string)),
                    new DataColumn("Email", typeof(string)),
                    new DataColumn("PhoneNumber", typeof(string)),
                    new DataColumn("Password", typeof(string)),
                    new DataColumn("Gender", typeof(string)),
                    new DataColumn("UserName", typeof(string)),
                    new DataColumn("Location", typeof(string)),
                    new DataColumn("Address", typeof(string))
                }); 

                using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                {
                    oda.Fill(dtExcelData);
                }
                excel_con.Close();

                string consString = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.EmployeeInfo";

                        //[OPTIONAL]: Map the Excel columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("EmployeeId", "EmployeeId");
                        sqlBulkCopy.ColumnMappings.Add("EmployeeName", "EmployeeName");
                        sqlBulkCopy.ColumnMappings.Add("DateOfBirth", "DateOfBirth");
                        sqlBulkCopy.ColumnMappings.Add("Age", "Age");
                        sqlBulkCopy.ColumnMappings.Add("Salary", "Salary");
                        sqlBulkCopy.ColumnMappings.Add("Department", "Department");
                        sqlBulkCopy.ColumnMappings.Add("Email", "Email");
                        sqlBulkCopy.ColumnMappings.Add("PhoneNumber", "PhoneNumber");
                        sqlBulkCopy.ColumnMappings.Add("Password", "Password");
                        sqlBulkCopy.ColumnMappings.Add("Gender", "Gender");
                        sqlBulkCopy.ColumnMappings.Add("UserName", "UserName");
                        sqlBulkCopy.ColumnMappings.Add("Location", "Location");
                        sqlBulkCopy.ColumnMappings.Add("Address", "Address");
                        con.Open();
                        sqlBulkCopy.WriteToServer(dtExcelData);
                        con.Close();
                    }
                }
                MessageBox.Show("File uploaded");
            }
        }
    }
}