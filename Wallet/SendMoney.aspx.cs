using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace asp.netloginpage
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
            string query = "SELECT COUNT(1) FROM UserAccount WHERE SSN=@SSN";
            SqlCommand sqlCmd = new SqlCommand(query, con);
            sqlCmd.Parameters.AddWithValue("@SSN", Recipient.Text.Trim());
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            if (count == 1)
            {
                SqlCommand cmd = new SqlCommand("Update UserAccount set Balance=Balance-@amount where SSN=@SSN ", con);
                cmd.Parameters.Add("@amount", SqlDbType.Real);
                cmd.Parameters["@amount"].Value = Amount.Text;
                cmd.Parameters.AddWithValue("SSN", Session["ssn"]);
                cmd.ExecuteNonQuery();
                con.Close();
                SqlCommand cmd1 = new SqlCommand("Update UserAccount set Balance=Balance+@amount where SSN=@SSN ", con);
                cmd1.Parameters.Add("@amount", SqlDbType.Real);
                cmd1.Parameters["@amount"].Value = Amount.Text;
                cmd1.Parameters.AddWithValue("SSN", Recipient.Text);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                SqlCommand cmd2 = new SqlCommand("insert into Send_Payments(payorSSN, payeeSSN,paymentDateTime, amount, CancellationReason,Memo) values (@payorSSN, @payeeSSN,@paymentDateTime, @amount, @CancellationReason ,@Memo) ", con);
                cmd2.Parameters.AddWithValue("payorSSN", Session["ssn"]);
                cmd2.Parameters.AddWithValue("payeeSSN", Recipient.Text);
                cmd2.Parameters.AddWithValue("paymentDateTime", DateTime.Now);
                cmd2.Parameters.AddWithValue("CancellationReason", CancellationReason.Text);
                cmd2.Parameters.AddWithValue("Memo", Memo.Text);
                cmd2.Parameters.Add("@amount", SqlDbType.Real);
                cmd2.Parameters["@amount"].Value = Amount.Text; 
                con.Open();
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
            string query1 = "select DATEDIFF(minute,(SELECT TOP 1 paymentDateTime FROM Send_Payments WHERE payeeSSN=@SSN order by paymentDateTime ),CURRENT_TIMESTAMP)";
            SqlCommand sqlCmd1 = new SqlCommand(query1, con);
            sqlCmd1.Parameters.AddWithValue("@SSN", Recipient.Text.Trim());
            Int64 time = Convert.ToInt64(sqlCmd1.ExecuteScalar());
            if (time < 10 )
            {
                SqlCommand cmd = new SqlCommand("Update UserAccount set Balance=Balance+@amount where SSN=@SSN ", con);
                cmd.Parameters.Add("@amount", SqlDbType.Real);
                cmd.Parameters["@amount"].Value = Amount.Text;
                cmd.Parameters.AddWithValue("SSN", Session["ssn"]);
                cmd.ExecuteNonQuery();
                con.Close();
                SqlCommand cmd1 = new SqlCommand("Update UserAccount set Balance=Balance-@amount where SSN=@SSN ", con);
                cmd1.Parameters.Add("@amount", SqlDbType.Real);
                cmd1.Parameters["@amount"].Value = Amount.Text;
                cmd1.Parameters.AddWithValue("SSN", Recipient.Text);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                SqlCommand cmd2 = new SqlCommand("UPDATE Send_Payments SET CancellationReason='cancelled'  where payeeSSN=@payeeSSN ", con);
                cmd2.Parameters.AddWithValue("payeeSSN", Recipient.Text);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                lblSuccessMessage1.Visible = true;


            }
            else { lblErrorMessage1.Visible = true; con.Close(); }

        }

    }
}