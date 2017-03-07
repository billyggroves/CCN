using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using CCN;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

public partial class Account_Register : Page
{
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        var manager = new UserManager();
        var user = new ApplicationUser() { UserName = UserName.Text };
        IdentityResult result = manager.Create(user, Password.Text);
        if (result.Succeeded)
        {
            IdentityHelper.SignIn(manager, user, isPersistent: false);


            string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection myConnection = new SqlConnection(strConnection);
            myConnection.Open();
            string strInsert = "INSERT INTO [User] ([Username], [FirstName], [LastName], [Position], [Location], [ValueScore]) VALUES (@User, @First, @Last, @Post, @Location, @Score)";
            SqlCommand myInsert = new SqlCommand(strInsert, myConnection);
            myInsert.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = UserName.Text;
            myInsert.Parameters.Add("@First", System.Data.SqlDbType.NVarChar, 25).Value = FirstName.Text;
            myInsert.Parameters.Add("@Last", System.Data.SqlDbType.NVarChar, 25).Value = LastName.Text;
            myInsert.Parameters.Add("@Post", System.Data.SqlDbType.NVarChar, 50).Value = OfficePosition.Text;
            myInsert.Parameters.Add("@Location", System.Data.SqlDbType.NVarChar, 50).Value = OfficeLocation.Text;
            myInsert.Parameters.Add("@Score", System.Data.SqlDbType.Int).Value = 0;
            myInsert.ExecuteNonQuery();
            myConnection.Close();

            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
        else
        {
            ErrorMessage.Text = result.Errors.FirstOrDefault();
        }
    }
}