using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wallet
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void onBtnRegisterClick(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=HOME\SQLEXPRESS;initial Catalog=Payment;Integrated Security=True;");
            
            SqlCommand cmd = new SqlCommand("insert into UserAccount (SSN, FirstName, LastName, PhoneNumber) values (@SSN, @FirstName, @LastName, @PhoneNumber)", sqlCon);
            cmd.Parameters.AddWithValue("SSN", SSNText.Text);
            cmd.Parameters.AddWithValue("FirstName", fNameText.Text);
            cmd.Parameters.AddWithValue("LastName", lNameText.Text);
            cmd.Parameters.Add("@PhoneNumber", SqlDbType.BigInt);
            cmd.Parameters["@PhoneNumber"].Value = phoneText.Text;
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            SqlCommand cmd2 = new SqlCommand("insert into Login values (@SSN, @Username, @Password)", sqlCon);
            cmd2.Parameters.AddWithValue("SSN", SSNText.Text);
            cmd2.Parameters.AddWithValue("Username", usernameText.Text);
            cmd2.Parameters.AddWithValue("Password", passwordText.Text);
            sqlCon.Open();
            cmd2.ExecuteNonQuery();
            sqlCon.Close();


            SqlCommand cmd3 = new SqlCommand("insert into Email values (@SSN, @Email)", sqlCon);
            cmd3.Parameters.AddWithValue("SSN", SSNText.Text);
            cmd3.Parameters.AddWithValue("Email", emailText.Text);
            sqlCon.Open();
            cmd3.ExecuteNonQuery();
            sqlCon.Close();

            Response.Redirect("Login.aspx");
        }
    }
}