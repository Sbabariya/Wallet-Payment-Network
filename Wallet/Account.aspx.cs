using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wallet
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("login.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void onClickAddAccount(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;initial Catalog=Payment;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("INSERT INTO BankAccount values (@SSN, @BankID, @AccountNumber, @isPrimary)", con);
            cmd.Parameters.AddWithValue("SSN", Session["ssn"]);
            cmd.Parameters.AddWithValue("BankID", BankID.Text);
            cmd.Parameters.AddWithValue("accountNumber", accountNumber.Text);
            cmd.Parameters.AddWithValue("isPrimary", isPrimary.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Account.aspx");
        }
    }
}