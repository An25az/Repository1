using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisterTeam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadEvents();
        }
        else
        {
            // Recreate member entry controls on postback
            RecreateMemberEntryControls();
        }
    }

    protected void LoadEvents()
    {
        try
        {
            string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
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
                            ddlEvents.Items.Add(reader["EventName"].ToString());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Error loading events: " + ex.Message;
            lblError.Visible = true;
        }
    }

    protected void ddlEvents_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedEvent = ddlEvents.SelectedValue;
        if (!string.IsNullOrEmpty(selectedEvent))
        {
            pnlTeamDetails.Visible = true;
            hdnLeaderName.Value = Request.QueryString["username"];
            CreateMemberEntryControls(selectedEvent);
        }
        else
        {
            pnlTeamDetails.Visible = false;
        }
    }

    protected void CreateMemberEntryControls(string selectedEvent)
    {
        pnlMemberEntry.Controls.Clear();
        int maxTeamSize = GetMaxTeamSize(selectedEvent);
        for (int i = 1; i <= maxTeamSize; i++)
        {
            var txtMember = new TextBox();
            txtMember.ID = "txtMember" + i;
            txtMember.CssClass = "form-control";
            txtMember.Attributes["placeholder"] = "Member " + i;
            pnlMemberEntry.Controls.Add(txtMember);
            pnlMemberEntry.Controls.Add(new LiteralControl("<br />"));
        }
    }

    protected int GetMaxTeamSize(string eventName)
    {
        try
        {
            string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
            string query = "SELECT MembersPerTeam FROM Events WHERE EventName = @EventName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventName", eventName);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Error retrieving max team size: " + ex.Message;
            lblError.Visible = true;
        }
        return 5; // Default to 5 if retrieval fails
    }

    protected void RecreateMemberEntryControls()
    {
        // Recreate member entry controls on postback
        string selectedEvent = ddlEvents.SelectedValue;
        if (!string.IsNullOrEmpty(selectedEvent))
        {
            pnlTeamDetails.Visible = true;
            CreateMemberEntryControls(selectedEvent);
        }
        else
        {
            pnlTeamDetails.Visible = false;
        }
    }

    protected void btnConfirmRegistration_Click(object sender, EventArgs e)
    {
        try
        {
            string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Insert team details into the Team table
                string insertTeamQuery = "INSERT INTO Team (LeaderName, EventName, Type, TeamName) VALUES (@LeaderName, @EventName, @Type, @TeamName); SELECT SCOPE_IDENTITY();";
                SqlCommand insertTeamCommand = new SqlCommand(insertTeamQuery, connection);
                insertTeamCommand.Parameters.AddWithValue("@LeaderName", txtLeaderName.Text);
                insertTeamCommand.Parameters.AddWithValue("@EventName", ddlEvents.SelectedValue);
                insertTeamCommand.Parameters.AddWithValue("@TeamName", txtTeamName.Text);
                insertTeamCommand.Parameters.AddWithValue("@Type", "Fast"); // Default value is "Fast"
                object teamIdObj = insertTeamCommand.ExecuteScalar();
                int teamId = Convert.ToInt32(teamIdObj);

                // Insert team members into the TeamMembers table
                foreach (Control control in pnlMemberEntry.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txtMember = (TextBox)control;
                        string memberName = txtMember.Text;
                        string insertMemberQuery = "INSERT INTO TeamMembers (TeamID, MemberName) VALUES (@TeamID, @MemberName)";
                        SqlCommand insertMemberCommand = new SqlCommand(insertMemberQuery, connection);
                        insertMemberCommand.Parameters.AddWithValue("@TeamID", teamId);
                        insertMemberCommand.Parameters.AddWithValue("@MemberName", memberName);
                        insertMemberCommand.ExecuteNonQuery();
                    }
                }
            }
            // Registration successful, redirect to user dashboard
            Response.Redirect("~/UserDashboard.aspx?username=" + Request.QueryString["username"]);
        }
        catch (Exception ex)
        {
            lblError.Text = "Error registering team: " + ex.Message;
            lblError.Visible = true;
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        // Retrieve the current user's type from the [User] table using the provided UserName
        string currentUserType = "";
        string userName = Session["username"] as string;

        if (!string.IsNullOrEmpty(userName))
        {
            // Connection string to your database
            string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";

            // SQL query to retrieve the user's type based on the provided UserName
            string query = "SELECT Type FROM [User] WHERE UserName = @UserName";

            // Establish connection and execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter for UserName
                    command.Parameters.AddWithValue("@UserName", userName);

                    try
                    {
                        connection.Open();
                        // Execute the query
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            currentUserType = result.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions, such as database connection error
                        // Log the exception or display an error message
                    }
                }
            }

            // Check the user's type and redirect accordingly
            if (currentUserType == "Student")
            {
                // Redirect to the user dashboard page
                Response.Redirect("~/UserDashboard.aspx?username=" + userName);
            }
            else
            {
                // Redirect to the admin dashboard page
                Response.Redirect("~/AdminDashboard.aspx");
            }
        }
        else
        {
            // Handle case where username is not available
            // Redirect to some error page or take appropriate action
        }
    }


}
