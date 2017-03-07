using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using CCN;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = new UserManager();
                ApplicationUser user = manager.Find(UserName.Text, Password.Text);
                if (user != null)
                {
                    IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                    string strConnection = ConfigurationManager.ConnectionStrings["csNetwork"].ToString();
                    SqlConnection myConnection = new SqlConnection(strConnection);
                    myConnection.Open();
                    string strInsert = "INSERT INTO [User] ([Username], [Password]) VALUES (@User, @Pass)";
                    SqlCommand myInsert = new SqlCommand(strInsert, myConnection);
                    myInsert.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = UserName.Text;
                    myInsert.Parameters.Add("@Pass", System.Data.SqlDbType.NVarChar, 50).Value = Password.Text;
                    myInsert.ExecuteNonQuery();
                    myConnection.Close();

            }
                else
                {
                    FailureText.Text = "Invalid username or password.";
                    ErrorMessage.Visible = true;
                }
            }
        }
}