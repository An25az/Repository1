using System;

public partial class UserDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Check if the user is logged in
        if (Session["Username"] != null)
        {
            // If the user is logged in, set the label text to the username
            lblLoggedInUser.Text = Session["Username"].ToString();
        }
        else
        {
            // If no one is logged in, set the label text to "USER"
            lblLoggedInUser.Text = "USER";
        }
    }

    protected void BackToLoginButton_Click(object sender, EventArgs e)
    {
        // Redirect the user to the Login page
        Response.Redirect("~/Login.aspx");
    }
}
