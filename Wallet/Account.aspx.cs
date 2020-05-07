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
            SqlConnection con = new SqlConnection(@"Data Source=HOME\SQLEXPRESS;initial Catalog=Payment;Integrated Security=True;");
            if(isPrimary.Text.Equals("1"))
            {
                SqlCommand cmd4 = new SqlCommand("Update BankAccount set isPrimary = 0 where SSN = @ssn", con);
                cmd4.Parameters.AddWithValue("ssn", Session["ssn"]);
                con.Open();
                cmd4.ExecuteNonQuery();
                con.Close();

                SqlCommand cmd5 = new SqlCommand("Update UserAccount SET BankID = @BankID, AccountNumber = @AccountNumber Where SSN = @ssn", con);
                cmd5.Parameters.AddWithValue("BankID", BankID.Text);
                cmd5.Parameters.AddWithValue("accountNumber", accountNumber.Text);
                cmd5.Parameters.AddWithValue("ssn", Session["ssn"]);
                con.Open();
                cmd5.ExecuteNonQuery();
                con.Close();
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO BankAccount values (@SSN, @BankID, @AccountNumber, @isPrimary)", con);
            cmd.Parameters.AddWithValue("SSN", Session["ssn"]);
            cmd.Parameters.AddWithValue("BankID", BankID.Text);
            cmd.Parameters.AddWithValue("accountNumber", accountNumber.Text);
            cmd.Parameters.AddWithValue("isPrimary", isPrimary.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            SqlCommand cmd2 = new SqlCommand("select Balance from UserAccount where SSN = @ssn", con);
            cmd2.Parameters.AddWithValue("ssn", Session["ssn"]);
            con.Open();
            Decimal currentMoney = Convert.ToDecimal(cmd2.ExecuteScalar());
            con.Close();

            Decimal newBalance = currentMoney + Convert.ToDecimal(balance.Text);
            SqlCommand cmd3 = new SqlCommand("Update UserAccount SET Balance = @newValue WHERE SSN = @ssn", con);
            cmd3.Parameters.AddWithValue("ssn", Session["ssn"]);
            cmd3.Parameters.AddWithValue("newValue", newBalance);
            con.Open();
            cmd3.ExecuteNonQuery();
            con.Close();

            Response.Redirect("Account.aspx");
        }

        protected void onClickAddEmail(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=HOME\SQLEXPRESS;initial Catalog=Payment;Integrated Security=True;");
            SqlCommand command = new SqlCommand("INSERT INTO Email values(@ssn, @email)", con);
            command.Parameters.AddWithValue("ssn", Session["ssn"]);
            command.Parameters.AddWithValue("email", email.Text);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();

            Response.Redirect("Account.aspx");
        }
    }
}