using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class FacultyMentorManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
        }
    }

    protected void BindGridView()
    {
        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
        string query = "SELECT ID, UserName, Email FROM [User] WHERE [Type] = 'FacultyMentor'";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    gvFacultyMentors.DataSource = dt;
                    gvFacultyMentors.DataBind();
                }
            }
        }
    }

    protected void gvFacultyMentors_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvFacultyMentors.EditIndex = e.NewEditIndex;
        BindGridView();
    }

    protected void gvFacultyMentors_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gvFacultyMentors.Rows[e.RowIndex];
        int userId = Convert.ToInt32(gvFacultyMentors.DataKeys[e.RowIndex].Value);
        string userName = (row.FindControl("txtUserName") as TextBox).Text;
        string email = (row.FindControl("txtEmail") as TextBox).Text;

        // Update the user in the database using userId, userName, and email
        UpdateUser(userId, userName, email);

        gvFacultyMentors.EditIndex = -1;
        BindGridView();
        ShowMessage("Faculty Mentor updated successfully.");
    }

    protected void gvFacultyMentors_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvFacultyMentors.EditIndex = -1;
        BindGridView();
    }

    protected void gvFacultyMentors_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int userId = Convert.ToInt32(gvFacultyMentors.DataKeys[e.RowIndex].Value);

        // Delete the user from the database using userId
        DeleteUser(userId);

        BindGridView();
        ShowMessage("Faculty Mentor deleted successfully.");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(txtNewUserID.Text);
        string userName = txtNewUserName.Text;
        string email = txtNewEmail.Text;
        string password = txtNewPassword.Text; // Assuming you have a TextBox named txtNewPassword

        // Add new user to the database
        AddUser(userId, userName, email, password);

        BindGridView();
        ShowMessage("New Faculty Mentor added successfully.");
    }

    private void AddUser(int userId, string userName, string email, string password)
    {
        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
        string query = "INSERT INTO [User] (ID, UserName, Email, [Password], [Type]) VALUES (@UserID, @UserName, @Email, @Password, 'FacultyMentor')";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }


    private void UpdateUser(int userId, string userName, string email)
    {
        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
        string query = "UPDATE [User] SET UserName = @UserName, Email = @Email WHERE ID = @UserID";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@UserID", userId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    private void DeleteUser(int userId)
    {
        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
        string query = "DELETE FROM [User] WHERE ID = @UserID";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", userId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    private void ShowMessage(string message)
    {
        // Display success message
        ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{message}');", true);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminDashboard.aspx");
    }
}
