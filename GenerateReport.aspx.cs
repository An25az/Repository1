using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

public partial class Reports : Page
{
    // Connection string
    string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Load initial data or settings
        }
    }

    protected void btnGenerateReports_Click(object sender, EventArgs e)
    {
        // Generate and display reports
        StringBuilder reportContent = new StringBuilder();

        // Example: Retrieving user statistics
        reportContent.Append("<h2>User Participation Report</h2>");
        reportContent.Append("<table border='1'><tr><th>User ID</th><th>Username</th><th>Email</th></tr>");

        DataTable userData = GetUserStatisticsFromDatabase();
        foreach (DataRow row in userData.Rows)
        {
            reportContent.Append("<tr>");
            reportContent.Append($"<td>{row["ID"]}</td>");
            reportContent.Append($"<td>{row["UserName"]}</td>");
            reportContent.Append($"<td>{row["Email"]}</td>");
            reportContent.Append("</tr>");
        }

        reportContent.Append("</table>");

        // Add feedback data to the report
        reportContent.Append("<h2>Feedback Report</h2>");
        DataTable feedbackData = GetFeedbackFromDatabase();
        reportContent.Append("<ul>");
        foreach (DataRow row in feedbackData.Rows)
        {
            reportContent.Append($"<li>{row["EventName"]} - {row["StudentName"]}: {row["Comment"]}</li>");
        }
        reportContent.Append("</ul>");

        // Add team data to the report
        reportContent.Append("<h2>Team Report</h2>");
        DataTable teamData = GetTeamDataFromDatabase();
        reportContent.Append("<table border='1'><tr><th>Team ID</th><th>Member Name</th><th>Leader Name</th><th>Event Name</th></tr>");
        foreach (DataRow row in teamData.Rows)
        {
            reportContent.Append("<tr>");
            reportContent.Append($"<td>{row["TeamID"]}</td>");
            //reportContent.Append($"<td>{row["MemberName"]}</td>");
            reportContent.Append($"<td>{row["LeaderName"]}</td>");
            reportContent.Append($"<td>{row["EventName"]}</td>");
            reportContent.Append("</tr>");
        }
        reportContent.Append("</table>");

        ltReportResults.Text = reportContent.ToString();
    }

    // Example method to retrieve user statistics from the database
    private DataTable GetUserStatisticsFromDatabase()
    {
        DataTable userData = new DataTable();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT ID, UserName, Email FROM [User]";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(userData);
        }

        return userData;
    }

    // Example method to retrieve feedback data from the database
    private DataTable GetFeedbackFromDatabase()
    {
        DataTable feedbackData = new DataTable();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT EventName, StudentName, Comment FROM Feedback";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(feedbackData);
        }

        return feedbackData;
    }

    // Example method to retrieve team data from the database
    private DataTable GetTeamDataFromDatabase()
    {
        DataTable teamData = new DataTable();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT TeamID, LeaderName, EventName FROM Team";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(teamData);
        }

        return teamData;
    }

    protected void btnGoToAdminDashboard_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashboard.aspx");
    }

}
