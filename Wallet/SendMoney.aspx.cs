using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Wallet
{
    public partial class SendMoney : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSuccessMessage.Visible = false;
            lblErrorMessage.Visible = false;
            send_email.Visible = false;
            lblMsg.Visible = false;
            lblSuccessMessage1.Visible = false;
            lblErrorMessage1.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=HOME\SQLEXPRESS;initial Catalog=Payment;Integrated Security=True;");
            con.Open();
            string query = "SELECT COUNT(1) FROM UserAccount WHERE PhoneNumber=@phone";
            SqlCommand sqlCmd = new SqlCommand(query, con);
            sqlCmd.Parameters.AddWithValue("@phone", Recipient.Text.Trim());
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            if (count == 1)
            {
                SqlCommand cmd = new SqlCommand("Update UserAccount set Balance=Balance-@amount where SSN=@ssn ", con);
                cmd.Parameters.Add("@amount", SqlDbType.Real);
                cmd.Parameters["@amount"].Value = Amount.Text;
                cmd.Parameters.AddWithValue( "@ssn", Session["ssn"]);
                cmd.ExecuteNonQuery();
                con.Close();
                SqlCommand cmd1 = new SqlCommand("Update UserAccount set Balance=Balance+@amount where PhoneNumber=@phone ", con);
                cmd1.Parameters.Add("@amount", SqlDbType.Real);
                cmd1.Parameters["@amount"].Value = Amount.Text;
                cmd1.Parameters.AddWithValue("@phone", Recipient.Text.Trim());
                con.Open();
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("insert into Send_Payments(payorSSN, payeeSSN,paymentDateTime, amount, CancellationReason,Memo) values (@payorSSN, @payeeSSN,@paymentDateTime, @amount, @CancellationReason ,@Memo) ", con);
                string query2 = "SELECT SSN FROM UserAccount WHERE PhoneNumber=@phone";
                SqlCommand sqlCmd2 = new SqlCommand(query2, con);
                sqlCmd2.Parameters.AddWithValue("@phone", Recipient.Text.Trim());
                String count2 = Convert.ToString(sqlCmd2.ExecuteScalar());
                cmd2.Parameters.AddWithValue("payorSSN", count2);
                cmd2.Parameters.AddWithValue("payeeSSN", Session["ssn"]);
                cmd2.Parameters.AddWithValue("paymentDateTime", DateTime.Now);
                cmd2.Parameters.AddWithValue("CancellationReason", CancellationReason.Text);
                cmd2.Parameters.AddWithValue("Memo", Memo.Text);
                cmd2.Parameters.Add("@amount", SqlDbType.Real);
                cmd2.Parameters["@amount"].Value = Amount.Text;
                cmd2.ExecuteNonQuery();
                con.Close();
                lblSuccessMessage.Visible = true;


            }
            else { lblErrorMessage.Visible = true; send_email.Visible = true; con.Close(); }

        }
        protected void btmLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        protected void send_email_click(object sender, EventArgs e)
        {
            lblMsg.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=HOME\SQLEXPRESS;initial Catalog=Payment;Integrated Security=True;");
            con.Open();
            string query2 = "SELECT SSN FROM UserAccount WHERE PhoneNumber=@phone";
            SqlCommand sqlCmd4 = new SqlCommand(query2, con);
            sqlCmd4.Parameters.AddWithValue("@phone", Recipient.Text.Trim());
            String count2 = Convert.ToString(sqlCmd4.ExecuteScalar());
            string query1 = "select DATEDIFF(minute,(SELECT TOP 1 paymentDateTime FROM Send_Payments WHERE payorSSN=@ssn order by paymentDateTime desc ),CURRENT_TIMESTAMP)";
            SqlCommand sqlCmd1 = new SqlCommand(query1, con);
            sqlCmd1.Parameters.AddWithValue("ssn",count2);
            Int64 time = Convert.ToInt64(sqlCmd1.ExecuteScalar());
            if (time < 10 )
            {
                SqlCommand cmd = new SqlCommand("Update UserAccount set Balance=Balance+@amount where SSN=@SSN ", con);
                cmd.Parameters.Add("@amount", SqlDbType.Real);
                cmd.Parameters["@amount"].Value = Amount.Text;
                cmd.Parameters.AddWithValue("SSN", Session["ssn"]);
                cmd.ExecuteNonQuery();
                con.Close();
                SqlCommand cmd1 = new SqlCommand("Update UserAccount set Balance=Balance-@amount where PhoneNumber=@Phone ", con);
                cmd1.Parameters.Add("@amount", SqlDbType.Real);
                cmd1.Parameters["@amount"].Value = Amount.Text;
                cmd1.Parameters.AddWithValue("Phone", Recipient.Text);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                string query3 = "SELECT SSN FROM UserAccount WHERE PhoneNumber=@phone";
                SqlCommand sqlCmd3 = new SqlCommand(query3, con);
                sqlCmd3.Parameters.AddWithValue("@phone", Recipient.Text.Trim());
                con.Open();
                String count3 = Convert.ToString(sqlCmd3.ExecuteScalar());
                con.Close();
                SqlCommand cmd2 = new SqlCommand("UPDATE Send_Payments SET CancellationReason='cancelled'  where payorSSN=@payorSSN ", con);
                cmd2.Parameters.AddWithValue("payorSSN", count3);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                lblSuccessMessage1.Visible = true;


            }
            else { lblErrorMessage1.Visible = true; con.Close(); }

        }

    }
}