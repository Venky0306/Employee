using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee
{
    public partial class AlterEmployee : System.Web.UI.Page
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
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select [Employee Id],[Employee Name],Department,Email,[Phone Number] from [Employee Details]", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            con.Close();
          /* string constr = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;
            string query = "select * from [Employee Details]";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }*/
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int EmployeeId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string name = (row.FindControl("EmployeeName") as TextBox).Text;
            string Department = (row.FindControl("Department") as TextBox).Text;
            string email = (row.FindControl("email") as TextBox).Text;
            string phone = (row.FindControl("PhoneNumber") as TextBox).Text;
            string query = "UPDATE [Employee Details] SET [Employee Name]=@Name, Department=@Department, Email=@Email, [Phone Number]=@PhoneNumber WHERE [Employee Id]=@EmployeeId";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Department", Department);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phone);
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
            int EmployeeId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM [Employee Details] WHERE [Employee Id]=@EmployeeId";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
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
                (e.Row.Cells[2].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
    }
}