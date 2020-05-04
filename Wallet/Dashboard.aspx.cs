using System;
using System.Collections.Generic;
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
        }

        protected void onStatementClick(object sender, EventArgs e)
        {
        }
    }
}