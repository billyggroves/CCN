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
        string myname = Request.QueryString["myname"];
        txtUser.Text = myname;
        string strUser = HttpContext.Current.User.Identity.Name.ToString();

        string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        SqlConnection myConnection = new SqlConnection(strConnection);
        string strSelect = "SELECT [ValueScore] FROM [User] WHERE (Username = @User)";
        SqlCommand mySelect = new SqlCommand(strSelect, myConnection);
        mySelect.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myConnection.Open();
        SqlDataReader myReader = mySelect.ExecuteReader();
        myReader.Read();
        Int32 intTemp = Convert.ToInt32(myReader[0]);
        lblAdvocated.Visible = false;

        if (intTemp >= 10)
        {
            Image2.Visible = true;
        }
        if (intTemp >= 100)
        {
            Image3.Visible = true;
        }

    }

    protected void btnBalance_Click(object sender, EventArgs e)
    {
        
        string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        SqlConnection myConnection = new SqlConnection(strConnection);
        string strSelect = "SELECT [ValueScore] FROM [User] WHERE (Username = @User)";
        SqlCommand mySelect = new SqlCommand(strSelect, myConnection);
        mySelect.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myConnection.Open();
        SqlDataReader myReader = mySelect.ExecuteReader();
        myReader.Read();
        Int32 intTemp = Convert.ToInt32(myReader[0]);
        intTemp += 10;
        myReader.Close();

        string strIn = "UPDATE [User] SET [ValueScore] = @Score WHERE [Username] = @User";
        SqlCommand myIn = new SqlCommand(strIn, myConnection);
        myIn.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myIn.Parameters.Add("@Score", System.Data.SqlDbType.Int).Value = intTemp;
        myIn.ExecuteNonQuery();
        myConnection.Close();


        string strValue = "Balance";
        lblAdvocated.Visible = true;
        lblAdvocated.Text = "You advocated for " + txtUser.Text + "'s ability to balance their work and personal lives.";

        string strSql = "INSERT INTO [Recognition] ([Advocated], [Advocator], [DateTime], [SpecificValue], [RecognitionNote]) VALUES (@Advocated, @Advocator, @Date, @Value, @Note)";
        SqlCommand myInsert = new SqlCommand(strSql, myConnection);
        myInsert.Parameters.Add("@Advocated", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myInsert.Parameters.Add("@Advocator", System.Data.SqlDbType.NVarChar, 25).Value = HttpContext.Current.User.Identity.Name.ToString();
        myInsert.Parameters.Add("@Date", System.Data.SqlDbType.DateTime).Value = System.DateTime.Now;
        myInsert.Parameters.Add("@Value", System.Data.SqlDbType.NVarChar, 25).Value = strValue;
        myInsert.Parameters.Add("@Note", System.Data.SqlDbType.NVarChar, 25).Value = txtRecognition.Text;
        myConnection.Open();
        myInsert.ExecuteNonQuery();
        myConnection.Close();

        btnBalance.Enabled = false;
        btnCulture.Enabled = false;
        btnDelivery.Enabled = false;
        btnGood.Enabled = false;
        btnInnovation.Enabled = false;
        btnIntegrity.Enabled = false;
        btnStewardship.Enabled = false;
        btnVisible.Visible = true;

        Response.Redirect(Request.RawUrl);
    }

    protected void btnVisible_Click(object sender, EventArgs e)
    {
        if (txtRecognition.Text == "")
        {
            lblAdvocated.Text = "Please write your note of recognition";
        }
        else
        {

        lblAdvocated.Text = "Please Choose a Value";
        btnBalance.Enabled = true;
        btnCulture.Enabled = true;
        btnDelivery.Enabled = true;
        btnGood.Enabled = true;
        btnInnovation.Enabled = true;
        btnIntegrity.Enabled = true;
        btnStewardship.Enabled = true;
        btnVisible.Visible = false;
        }
    }

    protected void btnGood_Click(object sender, EventArgs e)
    {
        string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        SqlConnection myConnection = new SqlConnection(strConnection);
        string strSelect = "SELECT [ValueScore] FROM [User] WHERE (Username = @User)";
        SqlCommand mySelect = new SqlCommand(strSelect, myConnection);
        mySelect.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myConnection.Open();
        SqlDataReader myReader = mySelect.ExecuteReader();
        myReader.Read();
        Int32 intTemp = Convert.ToInt32(myReader[0]);
        intTemp += 10;
        myReader.Close();

        string strIn = "UPDATE [User] SET [ValueScore] = @Score WHERE [Username] = @User";
        SqlCommand myIn = new SqlCommand(strIn, myConnection);
        myIn.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myIn.Parameters.Add("@Score", System.Data.SqlDbType.Int).Value = intTemp;
        myIn.ExecuteNonQuery();
        myConnection.Close();


        string strValue = "Good";
        lblAdvocated.Visible = true;
        lblAdvocated.Text = "You advocated for " + txtUser.Text + "'s ability for being a good samaritan.";

        string strSql = "INSERT INTO [Recognition] ([Advocated], [Advocator], [DateTime], [SpecificValue], [RecognitionNote]) VALUES (@Advocated, @Advocator, @Date, @Value, @Note)";
        SqlCommand myInsert = new SqlCommand(strSql, myConnection);
        myInsert.Parameters.Add("@Advocated", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myInsert.Parameters.Add("@Advocator", System.Data.SqlDbType.NVarChar, 25).Value = HttpContext.Current.User.Identity.Name.ToString();
        myInsert.Parameters.Add("@Date", System.Data.SqlDbType.DateTime).Value = System.DateTime.Now;
        myInsert.Parameters.Add("@Value", System.Data.SqlDbType.NVarChar, 25).Value = strValue;
        myInsert.Parameters.Add("@Note", System.Data.SqlDbType.NVarChar, 25).Value = txtRecognition.Text;
        myConnection.Open();
        myInsert.ExecuteNonQuery();
        myConnection.Close();

        btnBalance.Enabled = false;
        btnCulture.Enabled = false;
        btnDelivery.Enabled = false;
        btnGood.Enabled = false;
        btnInnovation.Enabled = false;
        btnIntegrity.Enabled = false;
        btnStewardship.Enabled = false;
        btnVisible.Visible = true;

        Response.Redirect(Request.RawUrl);
    }

    protected void btnInnovation_Click(object sender, EventArgs e)
    {
        string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        SqlConnection myConnection = new SqlConnection(strConnection);
        string strSelect = "SELECT [ValueScore] FROM [User] WHERE (Username = @User)";
        SqlCommand mySelect = new SqlCommand(strSelect, myConnection);
        mySelect.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myConnection.Open();
        SqlDataReader myReader = mySelect.ExecuteReader();
        myReader.Read();
        Int32 intTemp = Convert.ToInt32(myReader[0]);
        intTemp += 10;
        myReader.Close();

        string strIn = "UPDATE [User] SET [ValueScore] = @Score WHERE [Username] = @User";
        SqlCommand myIn = new SqlCommand(strIn, myConnection);
        myIn.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myIn.Parameters.Add("@Score", System.Data.SqlDbType.Int).Value = intTemp;
        myIn.ExecuteNonQuery();
        myConnection.Close();


        string strValue = "Innovation";
        lblAdvocated.Visible = true;
        lblAdvocated.Text = "You advocated for " + txtUser.Text + "'s ability to innovate.";

        string strSql = "INSERT INTO [Recognition] ([Advocated], [Advocator], [DateTime], [SpecificValue], [RecognitionNote]) VALUES (@Advocated, @Advocator, @Date, @Value, @Note)";
        SqlCommand myInsert = new SqlCommand(strSql, myConnection);
        myInsert.Parameters.Add("@Advocated", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myInsert.Parameters.Add("@Advocator", System.Data.SqlDbType.NVarChar, 25).Value = HttpContext.Current.User.Identity.Name.ToString();
        myInsert.Parameters.Add("@Date", System.Data.SqlDbType.DateTime).Value = System.DateTime.Now;
        myInsert.Parameters.Add("@Value", System.Data.SqlDbType.NVarChar, 25).Value = strValue;
        myInsert.Parameters.Add("@Note", System.Data.SqlDbType.NVarChar, 25).Value = txtRecognition.Text;
        myConnection.Open();
        myInsert.ExecuteNonQuery();
        myConnection.Close();

        btnBalance.Enabled = false;
        btnCulture.Enabled = false;
        btnDelivery.Enabled = false;
        btnGood.Enabled = false;
        btnInnovation.Enabled = false;
        btnIntegrity.Enabled = false;
        btnStewardship.Enabled = false;
        btnVisible.Visible = true;

        Response.Redirect(Request.RawUrl);
    }

    protected void btnStewardship_Click(object sender, EventArgs e)
    {
        string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        SqlConnection myConnection = new SqlConnection(strConnection);
        string strSelect = "SELECT [ValueScore] FROM [User] WHERE (Username = @User)";
        SqlCommand mySelect = new SqlCommand(strSelect, myConnection);
        mySelect.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myConnection.Open();
        SqlDataReader myReader = mySelect.ExecuteReader();
        myReader.Read();
        Int32 intTemp = Convert.ToInt32(myReader[0]);
        intTemp += 10;
        myReader.Close();

        string strIn = "UPDATE [User] SET [ValueScore] = @Score WHERE [Username] = @User";
        SqlCommand myIn = new SqlCommand(strIn, myConnection);
        myIn.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myIn.Parameters.Add("@Score", System.Data.SqlDbType.Int).Value = intTemp;
        myIn.ExecuteNonQuery();
        myConnection.Close();


        string strValue = "Stewardship";
        lblAdvocated.Visible = true;
        lblAdvocated.Text = "You advocated for " + txtUser.Text + "'s ability to show stewardship.";

        string strSql = "INSERT INTO [Recognition] ([Advocated], [Advocator], [DateTime], [SpecificValue], [RecognitionNote]) VALUES (@Advocated, @Advocator, @Date, @Value, @Note)";
        SqlCommand myInsert = new SqlCommand(strSql, myConnection);
        myInsert.Parameters.Add("@Advocated", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myInsert.Parameters.Add("@Advocator", System.Data.SqlDbType.NVarChar, 25).Value = HttpContext.Current.User.Identity.Name.ToString();
        myInsert.Parameters.Add("@Date", System.Data.SqlDbType.DateTime).Value = System.DateTime.Now;
        myInsert.Parameters.Add("@Value", System.Data.SqlDbType.NVarChar, 25).Value = strValue;
        myInsert.Parameters.Add("@Note", System.Data.SqlDbType.NVarChar, 25).Value = txtRecognition.Text;
        myConnection.Open();
        myInsert.ExecuteNonQuery();
        myConnection.Close();

        btnBalance.Enabled = false;
        btnCulture.Enabled = false;
        btnDelivery.Enabled = false;
        btnGood.Enabled = false;
        btnInnovation.Enabled = false;
        btnIntegrity.Enabled = false;
        btnStewardship.Enabled = false;
        btnVisible.Visible = true;

        Response.Redirect(Request.RawUrl);
    }

    protected void btnDelivery_Click(object sender, EventArgs e)
    {
        string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        SqlConnection myConnection = new SqlConnection(strConnection);
        string strSelect = "SELECT [ValueScore] FROM [User] WHERE (Username = @User)";
        SqlCommand mySelect = new SqlCommand(strSelect, myConnection);
        mySelect.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myConnection.Open();
        SqlDataReader myReader = mySelect.ExecuteReader();
        myReader.Read();
        Int32 intTemp = Convert.ToInt32(myReader[0]);
        intTemp += 10;
        myReader.Close();

        string strIn = "UPDATE [User] SET [ValueScore] = @Score WHERE [Username] = @User";
        SqlCommand myIn = new SqlCommand(strIn, myConnection);
        myIn.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myIn.Parameters.Add("@Score", System.Data.SqlDbType.Int).Value = intTemp;
        myIn.ExecuteNonQuery();
        myConnection.Close();


        string strValue = "Deliver";
        lblAdvocated.Visible = true;
        lblAdvocated.Text = "You advocated for " + txtUser.Text + "'s ability to deliver excellence.";

        string strSql = "INSERT INTO [Recognition] ([Advocated], [Advocator], [DateTime], [SpecificValue], [RecognitionNote]) VALUES (@Advocated, @Advocator, @Date, @Value, @Note)";
        SqlCommand myInsert = new SqlCommand(strSql, myConnection);
        myInsert.Parameters.Add("@Advocated", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myInsert.Parameters.Add("@Advocator", System.Data.SqlDbType.NVarChar, 25).Value = HttpContext.Current.User.Identity.Name.ToString();
        myInsert.Parameters.Add("@Date", System.Data.SqlDbType.DateTime).Value = System.DateTime.Now;
        myInsert.Parameters.Add("@Value", System.Data.SqlDbType.NVarChar, 25).Value = strValue;
        myInsert.Parameters.Add("@Note", System.Data.SqlDbType.NVarChar, 25).Value = txtRecognition.Text;
        myConnection.Open();
        myInsert.ExecuteNonQuery();
        myConnection.Close();

        btnBalance.Enabled = false;
        btnCulture.Enabled = false;
        btnDelivery.Enabled = false;
        btnGood.Enabled = false;
        btnInnovation.Enabled = false;
        btnIntegrity.Enabled = false;
        btnStewardship.Enabled = false;
        btnVisible.Visible = true;

        Response.Redirect(Request.RawUrl);
    }

    protected void btnCulture_Click(object sender, EventArgs e)
    {
        string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        SqlConnection myConnection = new SqlConnection(strConnection);
        string strSelect = "SELECT [ValueScore] FROM [User] WHERE (Username = @User)";
        SqlCommand mySelect = new SqlCommand(strSelect, myConnection);
        mySelect.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myConnection.Open();
        SqlDataReader myReader = mySelect.ExecuteReader();
        myReader.Read();
        Int32 intTemp = Convert.ToInt32(myReader[0]);
        intTemp += 10;
        myReader.Close();

        string strIn = "UPDATE [User] SET [ValueScore] = @Score WHERE [Username] = @User";
        SqlCommand myIn = new SqlCommand(strIn, myConnection);
        myIn.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myIn.Parameters.Add("@Score", System.Data.SqlDbType.Int).Value = intTemp;
        myIn.ExecuteNonQuery();
        myConnection.Close();


        string strValue = "Culture";
        lblAdvocated.Visible = true;
        lblAdvocated.Text = "You advocated for " + txtUser.Text + "'s ability to adapt to Centric's culture.";

        string strSql = "INSERT INTO [Recognition] ([Advocated], [Advocator], [DateTime], [SpecificValue], [RecognitionNote]) VALUES (@Advocated, @Advocator, @Date, @Value, @Note)";
        SqlCommand myInsert = new SqlCommand(strSql, myConnection);
        myInsert.Parameters.Add("@Advocated", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myInsert.Parameters.Add("@Advocator", System.Data.SqlDbType.NVarChar, 25).Value = HttpContext.Current.User.Identity.Name.ToString();
        myInsert.Parameters.Add("@Date", System.Data.SqlDbType.DateTime).Value = System.DateTime.Now;
        myInsert.Parameters.Add("@Value", System.Data.SqlDbType.NVarChar, 25).Value = strValue;
        myInsert.Parameters.Add("@Note", System.Data.SqlDbType.NVarChar, 25).Value = txtRecognition.Text;
        myConnection.Open();
        myInsert.ExecuteNonQuery();
        myConnection.Close();

        btnBalance.Enabled = false;
        btnCulture.Enabled = false;
        btnDelivery.Enabled = false;
        btnGood.Enabled = false;
        btnInnovation.Enabled = false;
        btnIntegrity.Enabled = false;
        btnStewardship.Enabled = false;
        btnVisible.Visible = true;

        Response.Redirect(Request.RawUrl);
    }

    protected void btnIntegrity_Click(object sender, EventArgs e)
    {
        string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        SqlConnection myConnection = new SqlConnection(strConnection);
        string strSelect = "SELECT [ValueScore] FROM [User] WHERE (Username = @User)";
        SqlCommand mySelect = new SqlCommand(strSelect, myConnection);
        mySelect.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myConnection.Open();
        SqlDataReader myReader = mySelect.ExecuteReader();
        myReader.Read();
        Int32 intTemp = Convert.ToInt32(myReader[0]);
        intTemp += 10;
        myReader.Close();

        string strIn = "UPDATE [User] SET [ValueScore] = @Score WHERE [Username] = @User";
        SqlCommand myIn = new SqlCommand(strIn, myConnection);
        myIn.Parameters.Add("@User", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myIn.Parameters.Add("@Score", System.Data.SqlDbType.Int).Value = intTemp;
        myIn.ExecuteNonQuery();
        myConnection.Close();


        string strValue = "Integrity";
        lblAdvocated.Visible = true;
        lblAdvocated.Text = "You advocated for " + txtUser.Text + "'s ability to show true integrity.";

        string strSql = "INSERT INTO [Recognition] ([Advocated], [Advocator], [DateTime], [SpecificValue], [RecognitionNote]) VALUES (@Advocated, @Advocator, @Date, @Value, @Note)";
        SqlCommand myInsert = new SqlCommand(strSql, myConnection);
        myInsert.Parameters.Add("@Advocated", System.Data.SqlDbType.NVarChar, 25).Value = txtUser.Text;
        myInsert.Parameters.Add("@Advocator", System.Data.SqlDbType.NVarChar, 25).Value = HttpContext.Current.User.Identity.Name.ToString();
        myInsert.Parameters.Add("@Date", System.Data.SqlDbType.DateTime).Value = System.DateTime.Now;
        myInsert.Parameters.Add("@Value", System.Data.SqlDbType.NVarChar, 25).Value = strValue;
        myInsert.Parameters.Add("@Note", System.Data.SqlDbType.NVarChar, 25).Value = txtRecognition.Text;
        myConnection.Open();
        myInsert.ExecuteNonQuery();
        myConnection.Close();

        btnBalance.Enabled = false;
        btnCulture.Enabled = false;
        btnDelivery.Enabled = false;
        btnGood.Enabled = false;
        btnInnovation.Enabled = false;
        btnIntegrity.Enabled = false;
        btnStewardship.Enabled = false;
        btnVisible.Visible = true;

        Response.Redirect(Request.RawUrl);
    }

    protected void sdsRecognition_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        //Empty
    }

    protected void fvName_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {

    }
}
