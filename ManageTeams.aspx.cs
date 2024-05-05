//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//public partial class ManageTeams : System.Web.UI.Page
//{
//    protected void Page_Load(object sender, EventArgs e)
//    {
//        if (!IsPostBack)
//        {
//            DisplayTeams();
//        }
//    }


//    protected void AddMemberButton_Click(object sender, EventArgs e)
//    {
//        // Retrieve the selected team's TeamID
//        string selectedTeamID = TeamListBox.SelectedValue;

//        // Add member to the selected team
//        AddMember(selectedTeamID, MemberTextBox.Text);

//        // Refresh the team list
//        DisplayTeams();

//        // Clear the text box after adding member
//        MemberTextBox.Text = "";
//    }

//    protected void DeleteMemberButton_Click(object sender, EventArgs e)
//    {
//        // Retrieve the selected team's TeamID
//        string selectedTeamID = TeamListBox.SelectedValue;

//        // Delete member from the selected team
//        DeleteMember(selectedTeamID, MemberToDeleteTextBox.Text);

//        // Refresh the team list
//        DisplayTeams();

//        // Clear the text box after deleting member
//        MemberToDeleteTextBox.Text = "";
//    }

//    private void DisplayTeams()
//    {
//        TeamListBox.Items.Clear();

//        // Connect to the database
//        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
//        using (SqlConnection connection = new SqlConnection(connectionString))
//        {
//            connection.Open();

//            // Query to retrieve all team information
//            string query = "SELECT TeamID, TeamName, LeaderName, MemberName, EventName FROM Team ORDER BY EventName";
//            using (SqlCommand command = new SqlCommand(query, connection))
//            {
//                using (SqlDataReader reader = command.ExecuteReader())
//                {
//                    // Loop through the result set and add each team's information to the ListBox
//                    while (reader.Read())
//                    {
//                        // Construct the display text for each team
//                        string teamDisplayText = string.Format("Team Name: {0}, Leader Name: {1}, Members: {2}, Event Name: {3}",
//                                                                reader["TeamName"], reader["LeaderName"], reader["MemberName"], reader["EventName"]);

//                        // Add the team to the ListBox, setting the TeamID as the value
//                        ListItem listItem = new ListItem(teamDisplayText, reader["TeamID"].ToString());
//                        TeamListBox.Items.Add(listItem);
//                    }
//                }
//            }
//        }
//    }



//    private void AddMember(string teamID, string memberName)
//    {
//        // Connect to the database
//        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
//        using (SqlConnection connection = new SqlConnection(connectionString))
//        {
//            connection.Open();

//            // Update query to add member to the selected team
//            string query = "UPDATE Team SET MemberName = " +
//                           "CASE WHEN MemberName IS NULL THEN @MemberName " +
//                           "ELSE MemberName + ',' + @MemberName END " +
//                           "WHERE TeamID = @TeamID";

//            using (SqlCommand command = new SqlCommand(query, connection))
//            {
//                command.Parameters.AddWithValue("@MemberName", memberName);
//                command.Parameters.AddWithValue("@TeamID", teamID);

//                // Execute the query
//                command.ExecuteNonQuery();
//            }
//        }
//    }

//    private void DeleteMember(string teamID, string memberName)
//    {
//        // Connect to the database
//        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
//        using (SqlConnection connection = new SqlConnection(connectionString))
//        {
//            connection.Open();

//            // Update query to delete member from the selected team and handle leading/trailing commas
//            string query = @"
//                UPDATE Team
//                SET MemberName = 
//                    CASE 
//                        WHEN CHARINDEX(',' + @MemberName + ',', ',' + MemberName + ',') > 0 THEN 
//                            STUFF(MemberName, CHARINDEX(',' + @MemberName + ',', ',' + MemberName + ','), LEN(@MemberName) + 1, '') 
//                        ELSE 
//                            MemberName 
//                    END 
//                WHERE TeamID = @TeamID";

//            using (SqlCommand command = new SqlCommand(query, connection))
//            {
//                command.Parameters.AddWithValue("@MemberName", memberName);
//                command.Parameters.AddWithValue("@TeamID", teamID);

//                // Execute the query
//                command.ExecuteNonQuery();
//            }
//        }
//    }


//    protected void Back_Click(object sender, EventArgs e)
//    {
//        Response.Redirect("~/Admin.aspx");
//    }
//}

using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class ManageTeams : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayTeams();
        }
    }

    //protected void AddMemberButton_Click(object sender, EventArgs e)
    //{
    //    string selectedTeamID = TeamListBox.SelectedValue;
    //    string memberName = MemberTextBox.Text.Trim();

    //    // Check constraints before deleting member
    //    string errorMessage = CheckConstraints(selectedTeamID, memberName);
    //    if (!string.IsNullOrEmpty(errorMessage))
    //    {
    //        // Display the error message
    //        Errors.Text = errorMessage;
    //        return;
    //    }

    //    AddMember(selectedTeamID, memberName);
    //    DisplayTeams();
    //    MemberTextBox.Text = "";

    //}

    //protected void DeleteMemberButton_Click(object sender, EventArgs e)
    //{
    //    // Retrieve the selected team's TeamID
    //    string selectedTeamID = TeamListBox.SelectedValue;

    //    // Get the member name to be deleted
    //    string memberName = MemberToDeleteTextBox.Text.Trim();

    //    // Check constraints before deleting member
    //    string errorMessage = CheckConstraints(selectedTeamID, memberName);
    //    if (!string.IsNullOrEmpty(errorMessage))
    //    {
    //        // Display the error message
    //        Errors.Text = errorMessage;
    //        return;
    //    }

    //    // Delete member from the selected team
    //    DeleteMember(selectedTeamID, memberName);

    //    // Refresh the team list
    //    DisplayTeams();

    //    // Clear the text box after deleting member
    //    MemberToDeleteTextBox.Text = "";
    //}


    private void DisplayTeams()
    {
        TeamListBox.Items.Clear();
        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT TeamID, LeaderName, EventName, Type, TeamName FROM Team ORDER BY EventName";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string teamDisplayText = string.Format("Team Name: {0}, Leader Name: {1}, Type: {2}, Event Name: {3}",
                                                                reader["TeamName"], reader["LeaderName"], reader["Type"], reader["EventName"]);

                        ListItem listItem = new ListItem(teamDisplayText, reader["TeamID"].ToString());
                        TeamListBox.Items.Add(listItem);
                    }
                }
            }

        }
    }

    //private void AddMember(string teamID, string memberName)
    //{
    //    string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";

    //    using (SqlConnection connection = new SqlConnection(connectionString))
    //    {
    //        connection.Open();
    //        string query = "UPDATE Team SET MemberName = " +
    //                       "CASE WHEN MemberName IS NULL THEN @MemberName " +
    //                       "ELSE MemberName + ',' + @MemberName END " +
    //                       "WHERE TeamID = @TeamID";

    //        using (SqlCommand command = new SqlCommand(query, connection))
    //        {
    //            command.Parameters.AddWithValue("@MemberName", memberName);
    //            command.Parameters.AddWithValue("@TeamID", teamID);
    //            command.ExecuteNonQuery();
    //        }
    //    }
    //}

    //private void DeleteMember(string teamID, string memberName)
    //{
    //    string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";

    //    using (SqlConnection connection = new SqlConnection(connectionString))
    //    {
    //        connection.Open();
    //        string query = @"
    //            UPDATE Team
    //            SET MemberName = 
    //                CASE 
    //                    WHEN CHARINDEX(',' + @MemberName + ',', ',' + MemberName + ',') > 0 THEN 
    //                        STUFF(MemberName, CHARINDEX(',' + @MemberName + ',', ',' + MemberName + ','), LEN(@MemberName) + 1, '') 
    //                    ELSE 
    //                        MemberName 
    //                END 
    //            WHERE TeamID = @TeamID";

    //        using (SqlCommand command = new SqlCommand(query, connection))
    //        {
    //            command.Parameters.AddWithValue("@MemberName", memberName);
    //            command.Parameters.AddWithValue("@TeamID", teamID);
    //            command.ExecuteNonQuery();
    //        }
    //    }
    //}

    private string CheckConstraints(string teamID, string memberName)
    {
        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";

        // Check if the member exists in the [User] table
        string userQuery = "SELECT COUNT(*) FROM [User] WHERE UserName = @UserName";

        // Check if the member is of type "Student"
        string userTypeQuery = "SELECT COUNT(*) FROM [User] WHERE UserName = @UserName AND Type = 'Student'";

        // Check the team size constraints
        string teamSizeQuery = @"
        SELECT COUNT(MemberName)
        FROM Team
        WHERE TeamID = @TeamID";

        int teamSize = 0;
        int minTeamCount = 0;
        int maxTeamCount = 0;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(userQuery, connection))
            {
                command.Parameters.AddWithValue("@UserName", memberName);
                int userCount = (int)command.ExecuteScalar();
                if (userCount == 0)
                {
                    // Member does not exist in the [User] table
                    return "Member '" + memberName + "' does not exist.";
                }
            }

            using (SqlCommand command = new SqlCommand(userTypeQuery, connection))
            {
                command.Parameters.AddWithValue("@UserName", memberName);
                int studentCount = (int)command.ExecuteScalar();
                if (studentCount == 0)
                {
                    // Member is not of type "Student"
                    return "Member '" + memberName + "' is not a student.";
                }
            }

            using (SqlCommand command = new SqlCommand(teamSizeQuery, connection))
            {
                command.Parameters.AddWithValue("@TeamID", teamID);
                teamSize = (int)command.ExecuteScalar();
            }

            string eventQuery = "SELECT MinTeamCount, MaxTeamCount FROM Events WHERE EventName IN (SELECT EventName FROM Team WHERE TeamID = @TeamID)";
            using (SqlCommand command = new SqlCommand(eventQuery, connection))
            {
                command.Parameters.AddWithValue("@TeamID", teamID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        minTeamCount = Convert.ToInt32(reader["MinTeamCount"]);
                        maxTeamCount = Convert.ToInt32(reader["MaxTeamCount"]);
                    }
                }
            }
        }

        // Check if deleting one member keeps the team size within limits
        if (teamSize - 1 < minTeamCount || teamSize - 1 > maxTeamCount)
        {
            return "Cannot add/delete member. Team size exceeds the limit.";
        }

        // All constraints are fulfilled
        return "";
    }


    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminDashboard.aspx");
    }

    private void DeleteTeam(string teamID)
    {
        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Delete team members associated with the team ID
            string deleteTeamMembersQuery = "DELETE FROM TeamMembers WHERE TeamID = @TeamID";
            using (SqlCommand deleteMembersCommand = new SqlCommand(deleteTeamMembersQuery, connection))
            {
                deleteMembersCommand.Parameters.AddWithValue("@TeamID", teamID);
                deleteMembersCommand.ExecuteNonQuery();
            }

            // Delete the team itself
            string deleteTeamQuery = "DELETE FROM Team WHERE TeamID = @TeamID";
            using (SqlCommand deleteTeamCommand = new SqlCommand(deleteTeamQuery, connection))
            {
                deleteTeamCommand.Parameters.AddWithValue("@TeamID", teamID);
                deleteTeamCommand.ExecuteNonQuery();
            }
        }
    }


    protected void DeleteTeamButton_Click(object sender, EventArgs e)
    {
        string selectedTeamID = TeamListBox.SelectedValue;

        // Delete the entire selected team
        DeleteTeam(selectedTeamID);

        // Refresh the team list
        DisplayTeams();
    }

    protected void AddTeamButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/RegisterTeam.aspx");
    }
}


