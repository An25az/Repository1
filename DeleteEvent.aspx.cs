using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteEventPage : Page
{
    string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Load events to delete
            LoadEvents();
        }
    }

    // Method to load events
    private void LoadEvents()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT EventName FROM Events";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                // Add events to the CheckBoxList
                chkEventsToDelete.Items.Add(new ListItem(reader["EventName"].ToString()));
            }
            reader.Close();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // Delete selected events
        DeleteSelectedEvents();

        // Redirect back to Admin Dashboard
        Response.Redirect("AdminDashboard.aspx");
    }

    // Method to delete selected events
    private void DeleteSelectedEvents()
    {
        // Iterate through selected events and delete them
        foreach (ListItem item in chkEventsToDelete.Items)
        {
            if (item.Selected)
            {
                DeleteEvent(item.Text);
            }
        }
    }

    // Method to delete an event
    // Method to delete an event
    // Method to delete an event
    private void DeleteEvent(string eventName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Delete associated records from the Feedback table first
                string deleteFeedbackQuery = "DELETE FROM Feedback WHERE EventName = @EventName";
                SqlCommand deleteFeedbackCommand = new SqlCommand(deleteFeedbackQuery, connection);
                deleteFeedbackCommand.Parameters.AddWithValue("@EventName", eventName);
                deleteFeedbackCommand.ExecuteNonQuery();

                // Delete associated records from the Team table
                string deleteTeamQuery = "DELETE FROM Team WHERE EventName = @EventName";
                SqlCommand deleteTeamCommand = new SqlCommand(deleteTeamQuery, connection);
                deleteTeamCommand.Parameters.AddWithValue("@EventName", eventName);
                deleteTeamCommand.ExecuteNonQuery();

                // Then delete the event itself
                string deleteEventQuery = "DELETE FROM Events WHERE EventName = @EventName";
                SqlCommand deleteEventCommand = new SqlCommand(deleteEventQuery, connection);
                deleteEventCommand.Parameters.AddWithValue("@EventName", eventName);
                deleteEventCommand.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }



    protected void btnBack_Click(object sender, EventArgs e)
    {
        // Redirect back to Admin Dashboard
        Response.Redirect("AdminDashboard.aspx");
    }
}
