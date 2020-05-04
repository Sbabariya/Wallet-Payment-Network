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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=HOME\SQLEXPRESS;initial Catalog=Payment;Integrated Security=True;");
            con.Open();
            string query = "SELECT COUNT(1) FROM UserLogin WHERE UserName=@username";
            SqlCommand sqlCmd = new SqlCommand(query, con);
            sqlCmd.Parameters.AddWithValue("@username", Recipient.Text.Trim());
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            if (count == 1)
            {
                SqlCommand cmd = new SqlCommand("Update Registrationproj set Balance=Balance-@amount where UserName=@UserName ", con);
                cmd.Parameters.Add("@amount", SqlDbType.Real);
                cmd.Parameters["@amount"].Value = Amount.Text;
                cmd.Parameters.AddWithValue("UserName", Session["UserName"]);
                cmd.ExecuteNonQuery();
                con.Close();
                SqlCommand cmd1 = new SqlCommand("Update Registrationproj set Balance=Balance+@amount where UserName=@UserName ", con);
                cmd1.Parameters.Add("@amount", SqlDbType.Real);
                cmd1.Parameters["@amount"].Value = Amount.Text;
                cmd1.Parameters.AddWithValue("UserName", Recipient.Text);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                SqlCommand cmd2 = new SqlCommand("insert into SendPayment(payorUserID, payeeUserID,paymentDateTime, amount, isCancelled) values (@payorUserID, @payeeUserID,@paymentDateTime, @amount, null) ", con);
                cmd2.Parameters.AddWithValue("payorUserID", Session["UserName"]);
                cmd2.Parameters.AddWithValue("payeeUserID", Recipient.Text);
                cmd2.Parameters.AddWithValue("paymentDateTime", DateTime.Now);
                cmd2.Parameters.Add("@amount", SqlDbType.Real);
                cmd2.Parameters["@amount"].Value = Amount.Text;
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                lblSuccessMessage.Visible = true;
    

            }
            else { lblErrorMessage.Visible = true; send_email.Visible = true ; con.Close(); }

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
    }
}