using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtTemp.Text = "";
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text == "")
        {
            lblFound.Visible = true;
            lblFound.ForeColor = System.Drawing.Color.Red;
            lblFound.Text = "Please enter a search parameter";
            gvSearch.Visible = false;
        }
        else
        {
            lblFound.ForeColor = System.Drawing.Color.Black;
            gvSearch.Visible = true;
            lblFound.Text = "";
            string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection myConnection = new SqlConnection(strConnection);
            string strSql = "SELECT [Username], [FirstName], [LastName], [Position], [Location] FROM [User] WHERE Username LIKE @User OR FirstName LIKE @User OR LastName LIKE @User OR Position LIKE @User OR Location LIKE @User";
            SqlCommand myCommand = new SqlCommand(strSql, myConnection);
            myCommand.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 50).Value = "%" + txtSearch.Text + "%";
            myConnection.Open();
            SqlDataReader myReader = myCommand.ExecuteReader();
            gvSearch.DataSource = myReader;
            gvSearch.DataBind();
            myReader.Close();
            myConnection.Close();
            lblFound.Text = gvSearch.Rows.Count + " record(s) were found.";
            lblFound.Visible = true;
            txtSearch.Text = "";
            gvSearch.CellPadding = 15;
            gvSearch.CellSpacing = 5;
        }
    }

    protected void gvSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtTemp.Text = gvSearch.SelectedRow.Cells[1].Text;
        Response.Redirect("Profile.aspx?myname=" + txtTemp.Text);
    }
}