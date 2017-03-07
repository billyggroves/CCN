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

public partial class MyProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUser.Text = HttpContext.Current.User.Identity.Name.ToString();
        if (txtUser.Text == "")
        {
            fvAboutMe.Visible = false;
            fvName.Visible = false;
        }
        else
        {
            fvAboutMe.Visible = true;
            fvName.Visible = true;

            string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection myConnection = new SqlConnection(strConnection);
            string strSelect = "SELECT [ValueScore] FROM [User] WHERE (Username = @User)";
            SqlCommand mySelect = new SqlCommand(strSelect, myConnection);
            mySelect.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
            myConnection.Open();
            SqlDataReader myReader = mySelect.ExecuteReader();
            myReader.Read();
            Int32 intTemp = Convert.ToInt32(myReader[0]);

            if (intTemp >= 10)
            {
                Image2.Visible = true;
            }
            if (intTemp >= 100)
            {
                Image3.Visible = true;
            }
        }
    }

    protected void fvPost_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {

    }



    protected void UpdateButton_Click(object sender, EventArgs e)
    {

    }

    protected void lbUpdate_Click(object sender, EventArgs e)
    {
        TextBox vtxtFirst = fvName.FindControl("FirstNameTextBox") as TextBox;
        TextBox vtxtLast = fvName.FindControl("LastNameTextBox") as TextBox;
        TextBox vtxtPosition = fvName.FindControl("PositionTextBox") as TextBox;
        TextBox vtxtLocation = fvName.FindControl("LocationTextBox") as TextBox;

        if (vtxtFirst.Text != "")
        {
            string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection myConnection = new SqlConnection(strConnection);
            string strIn = "UPDATE [User] SET [FirstName] = @First WHERE [Username] = @User";
            SqlCommand mySelect = new SqlCommand(strIn, myConnection);
            SqlCommand myIn = new SqlCommand(strIn, myConnection);
            myIn.Parameters.Add("@First", System.Data.SqlDbType.NVarChar, 25).Value = vtxtFirst.Text;
            myIn.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
            myConnection.Open();
            myIn.ExecuteNonQuery();
            myConnection.Close();
        }

        if (vtxtLast.Text != "")
        {
            string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection myConnection = new SqlConnection(strConnection);
            string strIn = "UPDATE [User] SET [LastName] = @Last WHERE [Username] = @User";
            SqlCommand mySelect = new SqlCommand(strIn, myConnection);
            SqlCommand myIn = new SqlCommand(strIn, myConnection);
            myIn.Parameters.Add("@Last", System.Data.SqlDbType.NVarChar, 25).Value = vtxtLast.Text;
            myIn.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
            myConnection.Open();
            myIn.ExecuteNonQuery();
            myConnection.Close();
        }

        if (vtxtPosition.Text != "")
        {
            string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection myConnection = new SqlConnection(strConnection);
            string strIn = "UPDATE [User] SET [Position] = @Position WHERE [Username] = @User";
            SqlCommand mySelect = new SqlCommand(strIn, myConnection);
            SqlCommand myIn = new SqlCommand(strIn, myConnection);
            myIn.Parameters.Add("@Position", System.Data.SqlDbType.NVarChar, 25).Value = vtxtPosition.Text;
            myIn.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
            myConnection.Open();
            myIn.ExecuteNonQuery();
            myConnection.Close();
        }

        if (vtxtLocation.Text != "")
        {
            string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection myConnection = new SqlConnection(strConnection);
            string strIn = "UPDATE [User] SET [Location] = @Location WHERE [Username] = @User";
            SqlCommand mySelect = new SqlCommand(strIn, myConnection);
            SqlCommand myIn = new SqlCommand(strIn, myConnection);
            myIn.Parameters.Add("@Location", System.Data.SqlDbType.NVarChar, 25).Value = vtxtLocation.Text;
            myIn.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
            myConnection.Open();
            myIn.ExecuteNonQuery();
            myConnection.Close();
        }

        fvName.ChangeMode(FormViewMode.ReadOnly);

    }

    protected void lbUpdate_Click1(object sender, EventArgs e)
    {

    }

    protected void lbUpdate2_Click(object sender, EventArgs e)
    {
        TextBox vtxtAbout = fvAboutMe.FindControl("UserContentTextBox") as TextBox;
        string strTemp = "AboutUser";
        string strTemp2 = "UserProfile";

        string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        SqlConnection myConnection = new SqlConnection(strConnection);
        string strIn = "UPDATE [UserProfile] SET [UserContent] = @Content WHERE [Username] = @User AND [UserPage] = @Page AND [UserSection] = @Section";
        SqlCommand mySelect = new SqlCommand(strIn, myConnection);
        SqlCommand myIn = new SqlCommand(strIn, myConnection);
        myIn.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myIn.Parameters.Add("@Page", System.Data.SqlDbType.NVarChar, 25).Value = strTemp2;
        myIn.Parameters.Add("@Section", System.Data.SqlDbType.NVarChar, 25).Value = strTemp;
        myIn.Parameters.Add("@Content", System.Data.SqlDbType.NVarChar).Value = vtxtAbout.Text;
        myConnection.Open();
        myIn.ExecuteNonQuery();
        myConnection.Close();

        fvAboutMe.ChangeMode(FormViewMode.ReadOnly);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string strTemp = "UserProfile";
        string strTemp2 = "AboutUser";
        TextBox vtxtTemp = fvAboutMe.FindControl("UserContentTextBox") as TextBox;

        string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        SqlConnection myConnection = new SqlConnection(strConnection);
        string strSql = "INSERT INTO [UserProfile] ([Username], [UserPage], [UserSection], [UserContent]) VALUES (@User, @Page, @Section, @Content)";
        SqlCommand myInsert = new SqlCommand(strSql, myConnection);
        myInsert.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = HttpContext.Current.User.Identity.Name.ToString();
        myInsert.Parameters.Add("@Page", System.Data.SqlDbType.NVarChar, 25).Value = strTemp;
        myInsert.Parameters.Add("@Section", System.Data.SqlDbType.NVarChar, 25).Value = strTemp2;
        myInsert.Parameters.Add("@Content", System.Data.SqlDbType.NVarChar).Value = vtxtTemp.Text;
        myConnection.Open();
        myInsert.ExecuteNonQuery();
        myConnection.Close();

        fvAboutMe.ChangeMode(FormViewMode.ReadOnly);
    }
}