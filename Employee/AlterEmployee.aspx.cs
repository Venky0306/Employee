using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;

namespace Employee
{
    public partial class AlterEmployee1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select EmployeeId,EmployeeName,DateOfBirth,Age,Salary,Department,Email,PhoneNumber,Password,Gender,UserName,Location,Address from EmployeeInfo"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            //int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string EmployeeId = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values[0]);
            string EmployeeName = (row.Cells[2].Controls[0] as TextBox).Text;
            string DateOfBirth = (row.Cells[3].Controls[0] as TextBox).Text;
            string Age = (row.Cells[4].Controls[0] as TextBox).Text;
            string Salary = (row.Cells[5].Controls[0] as TextBox).Text;
            string Department = (row.Cells[6].Controls[0] as TextBox).Text;
            string Email = (row.Cells[7].Controls[0] as TextBox).Text;
            string PhoneNumber = (row.Cells[8].Controls[0] as TextBox).Text;
            string Password = (row.Cells[9].Controls[0] as TextBox).Text;
            string Gender = (row.Cells[10].Controls[0] as TextBox).Text;
            string UserName = (row.Cells[11].Controls[0] as TextBox).Text;
            string Location = (row.Cells[12].Controls[0] as TextBox).Text;
            string Address = (row.Cells[13].Controls[0] as TextBox).Text;

            string constr = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE EmployeeInfo SET EmployeeName = @EmployeeName, DateOfBirth = @DateOfBirth, Age = @Age, Salary = @Salary, Department = @Department, Email = @Email, PhoneNumber = @PhoneNumber, Password = @Password,  Gender = @Gender, UserName = @UserName, Location = @Location, Address = @Address WHERE EmployeeId = @EmployeeId"))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                    cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    cmd.Parameters.AddWithValue("@Age", Age);
                    cmd.Parameters.AddWithValue("@Salary", Salary);
                    cmd.Parameters.AddWithValue("@Department", Department);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Location", Location);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string EmployeeId = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM EmployeeInfo WHERE EmployeeId = @EmployeeId"))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }
    }
}