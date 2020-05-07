
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
    public partial class Statements : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
                Response.Redirect("Login.aspx");
            lblUserDetails.Text = "Username: " + Session["UserName"];

            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = true;
            Panel5.Visible = false;
            Panel6.Visible = false;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-28C21QU;initial Catalog=Payment;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select top 1 payorSSN from Send_Payments group by payorSSN order by sum(amount) desc  ", con);
            SqlCommand cmd1 = new SqlCommand("select top 1 payeeSSN from Send_Payments group by payeeSSN order by sum(amount) desc  ", con);
            bestUser.Text = cmd.ExecuteScalar().ToString();
            TextBox2.Text = cmd1.ExecuteScalar().ToString();
            con.Close();

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-28C21QU;initial Catalog=Payment;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select SendID, payorSSN, payeeSSN, paymentDateTime, amount from Send_Payments where CAST(DATENAME(month, paymentDateTime) AS CHAR(3))=@month and CAST(DATENAME(year,paymentDateTime) AS CHAR(4))=@year and payorSSN=@payorSSN ", con);
            cmd.Parameters.AddWithValue("month", DropDownList2.Text);
            cmd.Parameters.AddWithValue("year", Year.Text);
            cmd.Parameters.AddWithValue("payorSSN", Session["ssn"]);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView3.DataSource = ds;
            GridView3.DataBind();
            con.Close();
            Panel3.Visible = true;
            Panel1.Visible = false;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-28C21QU;initial Catalog=Payment;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select SendID, payorSSN, payeeSSN, paymentDateTime, amount from Send_Payments where CAST(DATENAME(month, paymentDateTime) AS CHAR(3))=@month and CAST(DATENAME(year,paymentDateTime) AS CHAR(4))=@year and payeeSSN=@payeeSSN ", con);
            cmd.Parameters.AddWithValue("month", DropDownList4.Text);
            cmd.Parameters.AddWithValue("Year", TextBox1.Text);
            cmd.Parameters.AddWithValue("payeeSSN", Session["ssn"]);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView6.DataSource = ds;
            GridView6.DataBind();
            con.Close();
            Panel6.Visible = true;
            Panel4.Visible = false;
        }


        protected void btmLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}