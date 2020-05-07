using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wallet
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorMessageLabel.Visible = false;
        }

        protected void onBtnLoginClick(object sender, EventArgs e)
        {
            using(SqlConnection sqlCon = new SqlConnection(@"Data Source=HOME\SQLEXPRESS;initial Catalog=Payment;Integrated Security=True;"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM Login WHERE UserName=@username AND Password=@password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@username", userText.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password", passText.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    string query2 = "SELECT SSN FROM Login WHERE UserName=@username AND Password=@password";
                    SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                    sqlCmd2.Parameters.AddWithValue("@username", userText.Text.Trim());
                    sqlCmd2.Parameters.AddWithValue("@password", passText.Text.Trim());

                    Session["username"] = userText.Text.Trim();
                    Session["ssn"] = sqlCmd2.ExecuteScalar();
                    Response.Redirect("Dashboard.aspx");
                }
                else { errorMessageLabel.Visible = true; }

            }
        }

        protected void onBtnRgisterClick(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}