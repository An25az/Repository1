using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class StudentExecutiveManagement : System.Web.UI.Page
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
        string query = "SELECT StudentID, FullName, Category, Position FROM StudentExecutives";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    gvStudentExecutives.DataSource = dt;
                    gvStudentExecutives.DataBind();
                }
            }
        }
    }

    protected void gvStudentExecutives_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvStudentExecutives.EditIndex = e.NewEditIndex;
        BindGridView();
    }

    protected void gvStudentExecutives_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gvStudentExecutives.Rows[e.RowIndex];
        TextBox txtFullName = (TextBox)row.Cells[1].Controls[0]; // FullName is in the second column
        TextBox txtCategory = (TextBox)row.Cells[2].Controls[0]; // Category is in the third column
        TextBox txtPosition = (TextBox)row.Cells[3].Controls[0]; // Position is in the fourth column

        if (txtFullName != null && txtCategory != null && txtPosition != null)
        {
            string fullName = txtFullName.Text;
            string category = txtCategory.Text;
            string position = txtPosition.Text;

            // Get the studentId from the GridView's DataKeys
            int studentId = Convert.ToInt32(gvStudentExecutives.DataKeys[e.RowIndex].Value);

            // Update the student executive in the database
            UpdateStudentExecutive(studentId, fullName, category, position);

            // Show success message
            ShowMessage("Student Executive updated successfully.");
        }
        else
        {
            // Handle the case when the controls are not found
            ShowMessage("Failed to update. Please check the input fields.");
        }

        // Exit edit mode
        gvStudentExecutives.EditIndex = -1;

        // Re-bind GridView to reflect changes
        BindGridView();
    }
    protected void gvStudentExecutives_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvStudentExecutives.EditIndex = -1;
        BindGridView();
    }

    protected void gvStudentExecutives_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int studentId = Convert.ToInt32(gvStudentExecutives.DataKeys[e.RowIndex].Value);

        // Delete the student executive from the database using studentId
        DeleteStudentExecutive(studentId);

        BindGridView();
        ShowMessage("Student Executive deleted successfully.");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string fullName = txtFullName.Text;
        string category = txtCategory.Text;
        string position = txtPosition.Text;

        // Add new student executive to the database
        AddStudentExecutive(fullName, category, position);

        BindGridView();
        ShowMessage("New Student Executive added successfully.");
    }

    private void UpdateStudentExecutive(int studentId, string fullName, string category, string position)
    {
        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
        string query = "UPDATE StudentExecutives SET FullName = @FullName, Category = @Category, Position = @Position WHERE StudentID = @StudentID";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FullName", fullName ?? string.Empty);
                command.Parameters.AddWithValue("@Category", category ?? string.Empty);
                command.Parameters.AddWithValue("@Position", position ?? string.Empty);
                command.Parameters.AddWithValue("@StudentID", studentId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        ShowMessage("Student Executive updated successfully.");
                    }
                    else
                    {
                        ShowMessage("Update failed, please try again.");
                    }
                }
                catch (SqlException ex)
                {
                    ShowMessage("Error updating data: " + ex.Message);
                }
                catch (Exception ex)
                {
                    ShowMessage("Error updating data: " + ex.Message);
                }
            }
        }
    }
    private void DeleteStudentExecutive(int studentId)
    {
        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
        string query = "DELETE FROM StudentExecutives WHERE StudentID = @StudentID";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentID", studentId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    private void AddStudentExecutive(string fullName, string category, string position)
    {
        
   

        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
        string query = "INSERT INTO StudentExecutives (StudentID, FullName, Category, Position) VALUES (@StudentID, @FullName, @Category, @Position)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                int newStudentID = GetNextStudentID();

                command.Parameters.AddWithValue("@StudentID", newStudentID);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Category", category);
                command.Parameters.AddWithValue("@Position", position);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    private int GetNextStudentID()
    {
        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
        string query = "SELECT MAX(StudentID) FROM StudentExecutives";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                int currentMaxID = (int)command.ExecuteScalar();
                return currentMaxID + 1;
            }
        }
    }

    private void ShowMessage(string message)
    {
        // Display success message
        ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{message}');", true);
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }
}
