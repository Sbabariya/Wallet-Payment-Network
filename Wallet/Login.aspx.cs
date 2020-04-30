using System;
using System.Collections.Generic;
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

        }

        protected void onBtnRgisterClick(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}