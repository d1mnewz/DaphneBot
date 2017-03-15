using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloBot.Controllers
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["daphne"].ConnectionString;
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users", conn);
                resultStr.Text = @"Connected...<br>";
                resultStr.Text += "ID\tTeamID\tUsername\tFullName" +
                                  "<br>";


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        resultStr.Text += $"{reader[0]}\t{reader[1]}\t{reader[2]}\t{reader[3]}<br>";
                    }
                }
                // using the code here...
            }
            
        }
    }
}