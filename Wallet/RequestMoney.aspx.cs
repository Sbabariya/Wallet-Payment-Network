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
    public partial class RequestMoney : System.Web.UI.Page
    {
        private int numOfRows = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("login.aspx");
            if (!Page.IsPostBack)

            {
                GenerateTable(numOfRows);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void onRequestClick(object sender, EventArgs e)
        {
            numOfRows = Convert.ToInt32(ViewState["RowsCount"].ToString());
            GenerateTable(numOfRows - 1);
            String phone;
            String email;
            String amount;
            String memo;

            Table table = (Table)Page.FindControl("requestTable");
            if (table != null)
            {
                int totalRow = Convert.ToInt32(ViewState["RowsCount"].ToString());
                for (int i = 0; i < totalRow-1; i++)
                {
                    TextBox tb1 = (TextBox)table.Rows[i].Cells[0].FindControl("TextBoxRow_" + i + "Col_0");
                    TextBox tb2 = (TextBox)table.Rows[i].Cells[1].FindControl("TextBoxRow_" + i + "Col_1");
                    TextBox tb3 = (TextBox)table.Rows[i].Cells[2].FindControl("TextBoxRow_" + i + "Col_2");
                    TextBox tb4 = (TextBox)table.Rows[i].Cells[3].FindControl("TextBoxRow_" + i + "Col_3");

                    phone = tb1.Text;
                    email = tb2.Text;
                    amount = tb3.Text;
                    memo = tb4.Text;

                    if(!String.IsNullOrWhiteSpace(amount)  && !String.IsNullOrWhiteSpace(memo) && (!String.IsNullOrWhiteSpace(phone) || !String.IsNullOrWhiteSpace(email)))
                    {
                        SqlConnection con = new SqlConnection(@"Data Source=HOME\SQLEXPRESS;initial Catalog=Payment;Integrated Security=True;");
                        SqlCommand command = new SqlCommand("INSERT INTO RequestTransaction (Amount, Memo, RequestDate, FromSSN, ToPhoneNumber, ToEmail) values(@amount, @memo, @date, @ssn, @phone, @email)", con);
                        command.Parameters.Add("@amount", SqlDbType.Real);
                        command.Parameters["@amount"].Value = amount;
                        command.Parameters.AddWithValue("memo", memo);
                        command.Parameters.AddWithValue("date", DateTime.Now);
                        command.Parameters.AddWithValue("ssn", Session["ssn"]);
                        command.Parameters.Add("@phone", SqlDbType.BigInt);
                        command.Parameters["@phone"].Value = phone;
                        command.Parameters.AddWithValue("email", email);

                        con.Open();
                        command.ExecuteNonQuery();
                        con.Close();
                    }
                }

                Response.Redirect("dashboard.aspx");
            }
        }

        protected void onAddRowClick(Object sender, EventArgs e)
        {
            if (ViewState["RowsCount"] != null)
            {
                numOfRows = Convert.ToInt32(ViewState["RowsCount"].ToString());
                GenerateTable(numOfRows);
            }
        }

        private void SetPreviousData(int rowsCount, int colsCount)
        {
            Table table = (Table)Page.FindControl("requestTable");
            if (table != null)
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    for (int j = 0; j < colsCount; j++)
                    {
                        TextBox tb = (TextBox)table.Rows[i].Cells[j].FindControl("TextBoxRow_" + i + "Col_" + j);
                        tb.Text = Request.Form["TextBoxRow_" + i + "Col_" + j];
                    }
                }
            }
        }
        
        private void GenerateTable(int rowCount)
        {
            Table table = new Table();
            table.ID = "requestTable";
            Page.Form.Controls.Add(table);

            TableHeaderRow headerRow = new TableHeaderRow();
            TableHeaderCell headerTableCell1 = new TableHeaderCell();
            TableHeaderCell headerTableCell2 = new TableHeaderCell();
            TableHeaderCell headerTableCell3 = new TableHeaderCell();
            TableHeaderCell headerTableCell4 = new TableHeaderCell();

            headerTableCell1.Text = "Recipient Phone";
            headerTableCell1.Scope = TableHeaderScope.Column;
            headerTableCell2.Text = "Recipient Email";
            headerTableCell2.Scope = TableHeaderScope.Column;
            headerTableCell3.Text = "Amount";
            headerTableCell3.Scope = TableHeaderScope.Column;
            headerTableCell4.Text = "Memo";
            headerTableCell4.Scope = TableHeaderScope.Column;

            headerRow.Cells.Add(headerTableCell1);
            headerRow.Cells.Add(headerTableCell2);
            headerRow.Cells.Add(headerTableCell3);
            headerRow.Cells.Add(headerTableCell4);

            table.Rows.AddAt(0, headerRow);

            const int colCount = 4;
            
            for (int i = 0; i < rowCount; i++)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < colCount; j++)
                {
                    TableCell cell = new TableCell();
                    TextBox tb = new TextBox();

                    tb.ID = "TextBoxRow_" + i + "Col_" + j;
                    cell.Controls.Add(tb);
                    row.Cells.Add(cell);
                }
                table.Rows.Add(row);
            }

            SetPreviousData(rowCount, colCount);
            rowCount++;

            ViewState["RowsCount"] = rowCount;
        }
    }
}