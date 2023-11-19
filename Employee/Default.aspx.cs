using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;

namespace Employee
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select Department,AVG(CAST(Salary as Integer)) as Salary from EmployeeInfo group by Department", conn))
                    {
                        Series series = PieChartMonthToDate.Series["Series1"];
                        conn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            series.Points.AddXY(rdr["Department"].ToString(), rdr["Salary".ToString()]);
                            PieChartMonthToDate.Series["Series1"].Label = "#PERCENT{P2}";
                            PieChartMonthToDate.Series["Series1"].LegendText = "#VALX";
                            PieChartMonthToDate.Legends[0].LegendStyle = LegendStyle.Column;
                            PieChartMonthToDate.Legends[0].Docking = Docking.Right;
                            PieChartMonthToDate.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
                        }
                        rdr.Close();
                    }
                }
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString))
                {
                    DataSet da = new DataSet();
                    SqlDataAdapter ada = new SqlDataAdapter("select AVG(CAST(Salary as Integer)) as Salary from EmployeeInfo", conn);
                    ada.Fill(da);
                    Chart2.DataSource = da;
                }
            }
        }
    }
}