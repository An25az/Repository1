using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Retrieve the username from the query string
            string username = Request.QueryString["username"];
            PopulateEventDropdown();

        }
    }

    protected void PopulateEventDropdown()
    {
        try
        {
            // Connection string to your database
            string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";

            // SQL query to retrieve event names from the Events table
            string query = "SELECT EventName FROM Events";

            // Establish connection and execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Open connection
                    connection.Open();

                    // Execute the query and load event names into the dropdown
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListItem item = new ListItem(reader["EventName"].ToString());
                            EventDropdown.Items.Add(item);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions
            // For example:
            // Errors.Text = "Error loading events: " + ex.Message;
        }
    }
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        // Get current user's name
        string studentName = Request.QueryString["username"];

        // Retrieve inputs from the form
        string eventName = EventDropdown.SelectedValue;
        string rating = GetSelectedRating();
        string comment = Comment.Value;

        // Insert feedback into the database
        InsertFeedback(eventName, studentName, rating, comment);
    }

    // Function to get the selected rating from the radio buttons
    private string GetSelectedRating()
    {
        // Get all radio buttons with name "rating"
        foreach (Control control in form1.Controls)
        {
            if (control is HtmlInputRadioButton radioButton && radioButton.Name == "rating" && radioButton.Checked)
            {
                // Return the value of the selected radio button
                return radioButton.Value;
            }
        }
        return string.Empty;
    }



    protected void InsertFeedback(string eventName, string studentName, string rating, string comment)
    {
        try
        {
            // Connection string to your database
            string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";

            // SQL query to insert feedback into the Feedback table
            string query = "INSERT INTO Feedback (EventName, StudentName, Rating, Comment) VALUES (@EventName, @StudentName, @Rating, @Comment)";

            // Establish connection and execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@EventName", eventName);
                    command.Parameters.AddWithValue("@StudentName", studentName);
                    command.Parameters.AddWithValue("@Rating", rating);
                    command.Parameters.AddWithValue("@Comment", comment);

                    // Open connection and execute the query
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Display success message or redirect to a confirmation page
            // For example:
            Response.Redirect("~/UserDashboard.aspx");
        }
        catch (Exception ex)
        {
            // Handle any exceptions, such as database connection error
            // Log the exception or display an error message
            // For example:
            // Errors.Text = "Error submitting feedback: " + ex.Message;
        }
    }
}
