using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Students : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Retrieve the username from the query string
            string username = Request.QueryString["username"];

            // Check if the current user is a team leader
            bool isTeamLeader = IsTeamLeader(username);

            // Hide the "Update Teams" button if the user is not a team leader
            UpdateTeams.Visible = isTeamLeader;

            // Display upcoming events
            DisplayUpcomingEvents();
        }
    }

    private bool IsTeamLeader(string username)
    {
        // Query the database to check if the user is listed as a team leader for any team
        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
        string query = "SELECT COUNT(*) FROM Team WHERE LeaderName = @Username";

        // Create a SqlConnection and SqlCommand
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            // Add the @Username parameter
            command.Parameters.AddWithValue("@Username", username);

            // Open the connection
            connection.Open();

            // Execute the query and read the results
            int teamCount = (int)command.ExecuteScalar();

            // Return true if the user is a team leader, otherwise false
            return teamCount > 0;
        }
    }

    private void DisplayUpcomingEvents()
    {
        // Connection string to your database
        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";

        // Query to retrieve the top 3 recent most events ordered by Time
        string query = "SELECT TOP 3 EventName, Price, MinTeamCount, MaxTeamCount, Time " +
                       "FROM Events " +
                       "ORDER BY Time"; // Assuming Time is a datetime column

        // Create a new table dynamically
        Table eventsTable = new Table();
        eventsTable.CssClass = "event-table";

        // Create a header row
        TableRow headerRow = new TableRow();
        headerRow.BackColor = System.Drawing.Color.FromName("#007bff");
        headerRow.ForeColor = System.Drawing.Color.White;

        // Add header cells
        string[] headers = { "Event Name", "Price", "Min Team Count", "Max Team Count", "Time" };
        foreach (string header in headers)
        {
            TableHeaderCell headerCell = new TableHeaderCell();
            headerCell.Text = header;
            headerRow.Cells.Add(headerCell);
        }

        // Add the header row to the table
        eventsTable.Rows.Add(headerRow);

        // Create a SqlConnection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Create a SqlCommand with the query and connection
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Open the connection
                connection.Open();

                // Execute the query and read the results
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Loop through the results and display them
                    while (reader.Read())
                    {
                        // Create a new row for each event
                        TableRow row = new TableRow();

                        // Create a cell for each event property
                        TableCell eventNameCell = new TableCell();
                        eventNameCell.Text = reader["EventName"].ToString();
                        row.Cells.Add(eventNameCell);

                        TableCell priceCell = new TableCell();
                        priceCell.Text = reader["Price"].ToString();
                        row.Cells.Add(priceCell);

                        TableCell minTeamCountCell = new TableCell();
                        minTeamCountCell.Text = reader["MinTeamCount"].ToString();
                        row.Cells.Add(minTeamCountCell);

                        TableCell maxTeamCountCell = new TableCell();
                        maxTeamCountCell.Text = reader["MaxTeamCount"].ToString();
                        row.Cells.Add(maxTeamCountCell);

                        TableCell timeCell = new TableCell();
                        timeCell.Text = ((DateTime)reader["Time"]).ToString("dddd, MMMM dd, yyyy - hh:mm tt");
                        row.Cells.Add(timeCell);

                        // Add the row to the table
                        eventsTable.Rows.Add(row);
                    }
                }
            }
        }

        // Add the table to the EventsContainer
        EventsContainer.Controls.Add(eventsTable);
    }




    protected void RegisterTeam_Click(object sender, EventArgs e)
    {
        // Retrieve the username from the query string
        string username = Request.QueryString["username"];

        // Redirect to RegisterTeam.aspx with username as a query parameter
        Response.Redirect("~/RegisterTeam.aspx?username=" + Server.UrlEncode(username));
    }

    protected void UpdateTeams_Click(object sender, EventArgs e)
    {
        // Retrieve the username from the query string
        string username = Request.QueryString["username"];

        //Redirect to UpdateTeam.aspx with username as a query parameter
        Response.Redirect("~/UpdateTeam.aspx?username=" + Server.UrlEncode(username));
    }
    
    protected void BackToDashboard_Click(object sender, EventArgs e)
    {
        // Redirect to UserDashboard.aspx
        Response.Redirect("~/UserDashboard.aspx");
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        // Redirect to Login.aspx
        Response.Redirect("~/Login.aspx");
    }
}
