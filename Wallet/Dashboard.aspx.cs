using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wallet
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("login.aspx");
            lblUserDetails.Text = "Username : " + Session["username"];
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void onAccontClick(object sender, EventArgs e)
        {
            Response.Redirect("Account.aspx");
        }

        protected void onSendClick(object sender, EventArgs e)
        {
            Response.Redirect("SendMoney.aspx");
        }

        protected void onRequestClick(object sender, EventArgs e)
        {
            Response.Redirect("RequestMoney.aspx");
        }

        protected void onStatementClick(object sender, EventArgs e)
        {
        }

        protected void onAcceptClick(object sender, EventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;

            String reqID = gvRow.Cells[0].Text;
            String amount = gvRow.Cells[4].Text;
            String fromSSN = gvRow.Cells[6].Text;

            
            SqlConnection con = new SqlConnection(@"Data Source=localhost;initial Catalog=Payment;Integrated Security=True;");
            SqlCommand com = new SqlCommand("Update RequestTransaction Set [Status] = 'C' where ReqID = @reqID", con);
            com.Parameters.AddWithValue("reqID", reqID);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            SqlCommand cmd2 = new SqlCommand("select Balance from UserAccount where SSN = @ssn", con);
            cmd2.Parameters.AddWithValue("ssn", Session["ssn"]);
            con.Open();
            Decimal currentMoney = Convert.ToDecimal(cmd2.ExecuteScalar());
            con.Close();

            Decimal newBalance = currentMoney - Convert.ToDecimal(amount);
            SqlCommand cmd3 = new SqlCommand("Update UserAccount SET Balance = @newValue WHERE SSN = @ssn", con);
            cmd3.Parameters.AddWithValue("ssn", Session["ssn"]);
            cmd3.Parameters.AddWithValue("newValue", newBalance);
            con.Open();
            cmd3.ExecuteNonQuery();
            con.Close();

            SqlCommand cmd4 = new SqlCommand("select Balance from UserAccount where SSN = @ssn", con);
            cmd4.Parameters.AddWithValue("ssn", fromSSN);
            con.Open();
            Decimal currentMoney2 = Convert.ToDecimal(cmd4.ExecuteScalar());
            con.Close();

            Decimal newBalance2 = currentMoney2 + Convert.ToDecimal(amount);
            SqlCommand cmd5 = new SqlCommand("Update UserAccount SET Balance = @newValue WHERE SSN = @ssn", con);
            cmd5.Parameters.AddWithValue("ssn", fromSSN);
            cmd5.Parameters.AddWithValue("newValue", newBalance2);
            con.Open();
            cmd5.ExecuteNonQuery();
            con.Close();

            Response.Redirect("Dashboard.aspx");
        }

        protected void onDeclineClick(object sender, EventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;

            String reqID = gvRow.Cells[0].Text;

            SqlConnection con = new SqlConnection(@"Data Source=localhost;initial Catalog=Payment;Integrated Security=True;");
            SqlCommand com = new SqlCommand("Update RequestTransaction Set [Status] = 'D' where ReqID = @reqID", con);
            com.Parameters.AddWithValue("reqID", reqID);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            Response.Redirect("Dashboard.aspx");
        }
    }
}