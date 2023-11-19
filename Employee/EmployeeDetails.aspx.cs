using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Filter_Click(object sender, EventArgs e)
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select * from [EmployeeInfo] where [EmployeeId] = '" + tSearch.Text + "' order by [EmployeeId]", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            dFilter.DataSource = reader;
            dFilter.DataBind();
            con.Close();
        }

    }
}