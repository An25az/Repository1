using System;
using System.Data.SqlClient;

public partial class AddEvents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddEvent_Click(object sender, EventArgs e)
    {
        string eventName = txtEventName.Text;
        decimal price = Convert.ToDecimal(txtPrice.Text);
        int minTeamCount = Convert.ToInt32(txtMinTeamCount.Text);
        int maxTeamCount = Convert.ToInt32(txtMaxTeamCount.Text);
        DateTime time = Convert.ToDateTime(txtTime.Text);
        int membersPerTeam = Convert.ToInt32(txtMembersPerTeam.Text);


        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
        string query = "INSERT INTO Events (EventName, Price, MinTeamCount, MaxTeamCount, [Time], MembersPerTeam) VALUES (@EventName, @Price, @MinTeamCount, @MaxTeamCount, @Time, @MembersPerTeam)";


        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventName", eventName);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@MinTeamCount", minTeamCount);
                    command.Parameters.AddWithValue("@MaxTeamCount", maxTeamCount);
                    command.Parameters.AddWithValue("@MembersPerTeam", membersPerTeam);
                    command.Parameters.AddWithValue("@Time", time);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Event added successfully!";
                    }
                    else
                    {
                        lblMessage.Text = "Failed to add event!";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "An error occurred: " + ex.Message;
        }
    }

    protected void btnBackToDashboard_Click(object sender, EventArgs e)
    {
        // Redirect back to the dashboard page
        Response.Redirect("AdminDashboard.aspx");
    }
}
