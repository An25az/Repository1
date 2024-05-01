using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class UpdateTeam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadEvents();
        }
    }

    protected void LoadEvents()
    {
        try
        {
            string connectionString = "Data Source=HAMZASHAHID\\SQLEXPRESS;Initial Catalog=SE;Integrated Security=True";
            string query = "SELECT EventName FROM Events";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EventDropDown.Items.Add(reader["EventName"].ToString());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Errors.Text = "Error loading events: " + ex.Message;
        }
    }

    protected void EventDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadTeams(EventDropDown.SelectedValue);
    }

    protected void LoadTeams(string eventName)
    {
        TeamDropDown.Items.Clear();

        try
        {
            string connectionString = "Data Source=HAMZASHAHID\\SQLEXPRESS;Initial Catalog=SE;Integrated Security=True";
            string query = "SELECT TeamID, LeaderName FROM Team WHERE EventName = @EventName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventName", eventName);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Construct the team name based on the leader's name
                            string teamName = $"{reader["LeaderName"].ToString()}'s Team";
                            ListItem item = new ListItem(teamName, reader["TeamID"].ToString());
                            TeamDropDown.Items.Add(item);
                        }
                    }
                }
            }

            // If there's only one team, directly load its details
            if (TeamDropDown.Items.Count == 1)
            {
                LoadTeamDetails(TeamDropDown.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            Errors.Text = "Error loading teams: " + ex.Message;
        }
    }

    protected void TeamDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadTeamDetails(TeamDropDown.SelectedValue);
        LoadTeamMembers(TeamDropDown.SelectedValue);
    }

    protected void LoadTeamDetails(string teamID)
    {
        try
        {
            string connectionString = "Data Source=HAMZASHAHID\\SQLEXPRESS;Initial Catalog=SE;Integrated Security=True";
            string query = "SELECT LeaderName FROM Team WHERE TeamID = @TeamID; " +
                           "SELECT MemberName FROM TeamMembers WHERE TeamID = @TeamID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeamID", teamID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LeaderNameTextBox.Text = reader["LeaderName"].ToString();
                        }

                        // Move to the next result set to read member names
                        reader.NextResult();

                        MembersTextBox.Text = ""; // Clear the text box first

                        while (reader.Read())
                        {
                            // Append each member name to the MembersTextBox
                            MembersTextBox.Text += reader["MemberName"].ToString() + Environment.NewLine;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Errors.Text = "Error loading team details: " + ex.Message;
        }
    }

    protected void LoadTeamMembers(string teamID)
    {
        MembersTextBox.Text = ""; // Clear the text box first

        try
        {
            string connectionString = "Data Source=HAMZASHAHID\\SQLEXPRESS;Initial Catalog=SE;Integrated Security=True";
            string query = "SELECT MemberName FROM TeamMembers WHERE TeamID = @TeamID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeamID", teamID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Append each member name to the MembersTextBox
                            MembersTextBox.Text += reader["MemberName"].ToString() + Environment.NewLine;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Errors.Text = "Error loading team members: " + ex.Message;
        }
    }

    protected void UpdateTeamButton_Click(object sender, EventArgs e)
    {
        try
        {
            string connectionString = "Data Source=HAMZASHAHID\\SQLEXPRESS;Initial Catalog=SE;Integrated Security=True";
            string updateLeaderQuery = "UPDATE Team SET LeaderName = @LeaderName WHERE TeamID = @TeamID";
            string deleteMembersQuery = "DELETE FROM TeamMembers WHERE TeamID = @TeamID";
            string insertMemberQuery = "INSERT INTO TeamMembers (TeamID, MemberName) VALUES (@TeamID, @MemberName)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Update the leader name
                using (SqlCommand command = new SqlCommand(updateLeaderQuery, connection))
                {
                    command.Parameters.AddWithValue("@LeaderName", LeaderNameTextBox.Text);
                    command.Parameters.AddWithValue("@TeamID", TeamDropDown.SelectedValue);
                    command.ExecuteNonQuery();
                }

                // Delete existing team members
                using (SqlCommand command = new SqlCommand(deleteMembersQuery, connection))
                {
                    command.Parameters.AddWithValue("@TeamID", TeamDropDown.SelectedValue);
                    command.ExecuteNonQuery();
                }

                // Insert updated team members
                string[] members = MembersTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string member in members)
                {
                    using (SqlCommand command = new SqlCommand(insertMemberQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TeamID", TeamDropDown.SelectedValue);
                        command.Parameters.AddWithValue("@MemberName", member.Trim());
                        command.ExecuteNonQuery();
                    }
                }
            }

            Errors.Text = "Team details updated successfully!";
        }
        catch (Exception ex)
        {
            Errors.Text = "Error updating team details: " + ex.Message;
        }
    }


    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminDashboard.aspx");
    }
}
