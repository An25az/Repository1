using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if user is logged in
            //if (Session["username"] == null)
            //{
            //    Response.Redirect("~/Login.aspx"); // Redirect to login page if not logged in
            //}

            string username = "";
            // Check if the query string parameter exists
            if (Request.QueryString["username"] != null)
            {
                username = Request.QueryString["username"];
                // Do something with the username if needed
            }

            // Retrieve username of the logged-in user
            //string loggedInUsername = Session["username"].ToString();

        }
    }

    protected void ManageTeams_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ManageTeams.aspx?username=" + Server.UrlEncode(Request.QueryString["username"]));
    }

    protected void ViewTeams_Click(object sender, EventArgs e)
    {
        // Connect to the database
        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True"; // Replace with your actual connection string
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            // Query to retrieve teams for the logged-in user
            string query = "SELECT TeamID,LeaderName,MemberName,EventName FROM Team order by EventName";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Display teams in the UI
                        TeamListBox.Items.Add("Team ID: " + reader["TeamID"].ToString());
                        TeamListBox.Items.Add("Team Name: " + reader["TeamName"].ToString());
                        TeamListBox.Items.Add("Team Leader: " + reader["LeaderName"].ToString());
                        TeamListBox.Items.Add("Team Members: " + reader["MemberName"].ToString());
                        TeamListBox.Items.Add("Event Name: " + reader["EventName"].ToString());
                        TeamListBox.Items.Add("\n");

                        //// Construct the team information string
                        //string teamInfo = string.Format("Team ID: {0}\nTeam Name: {1}\nTeam Leader: {2}\nTeam Members: {3}\nEvent Name: {4}\n",
                        //    reader["TeamID"], reader["TeamName"], reader["LeaderName"], reader["MemberName"], reader["EventName"]);

                        //// Add the formatted team information to the ListBox
                        //TeamListBox.Items.Add(teamInfo);
                    }
                }
            }
        }
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }
}