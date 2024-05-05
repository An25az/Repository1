using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class EditProfile : Page
{
    // Connection string
    string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Retrieve the logged-in username from the session
            string username = Session["LoggedInUser"] as string;

            if (username != null)
            {
                // Populate user information based on the logged-in username
                PopulateUserInfo(username);
            }
            // No need for else condition as we're not redirecting to the login page
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        // Get updated user information from the form fields
        string email = txtEmail.Text.Trim();
        string password = txtPassword.Text.Trim();

        // Retrieve the entered username from the form
        string username = txtUserName.Text.Trim();

        // Update user information in the database based on the entered username
        try
        {
            UpdateUserInfo(username, email, password);
            lblMessage.Text = "Your profile has been updated successfully.";
        }
        catch (Exception ex)
        {
            lblMessage.Text = "An error occurred while updating your profile. Please try again later.";
            // Log the exception details for debugging purposes
            Console.WriteLine(ex.ToString());
        }
    }

    private void PopulateUserInfo(string username)
    {
        // Retrieve user information from the database based on the username
        string query = "SELECT UserName, Email FROM [User] WHERE UserName = @UserName";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", username);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                txtUserName.Text = reader["UserName"].ToString();
                txtEmail.Text = reader["Email"].ToString();
            }

            reader.Close();
        }
    }

    private void UpdateUserInfo(string username, string email, string password)
    {
        // Update user information in the database based on the entered username
        string query = "UPDATE [User] SET Email = @Email, [Password] = @Password WHERE UserName = @UserName";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", username);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected <= 0)
            {
                throw new Exception("Failed to update profile.");
            }
        }
    }

    protected void btnBackToDashboard_Click(object sender, EventArgs e)
    {
        // Redirect the user back to the dashboard
        Response.Redirect("UserDashboard.aspx");
    }
}
