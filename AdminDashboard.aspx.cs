using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class AdminDashboard : Page
{
    string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Load registered users only if it's the initial page load
            LoadRegisteredUsers();

            // Load events
            LoadEvents();
        }
    }

    // Method to load registered users
    public void LoadRegisteredUsers()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT ID AS UserID, UserName AS Username, Email, Type AS UserType FROM [User]";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable usersTable = new DataTable();
            adapter.Fill(usersTable);

            // Set the DataTable as the DataSource for the GridView
            userTable.DataSource = usersTable;
            userTable.DataBind();
        }
    }

    protected void btnDeleteEvent_Click(object sender, EventArgs e)
    {
        // Delete selected events
        DeleteSelectedEvents();

        // Reload events after deletion
        LoadEvents();
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
                // chkEvents.Items.Add(new ListItem(reader["EventName"].ToString()));
            }
            reader.Close();
        }
    }

    // Method to delete selected events
    private void DeleteSelectedEvents()
    {
        // Add your logic here to delete selected events
    }

    // Method to delete an event
    private void DeleteEvent(string eventName)
    {
        // Add your logic here to delete the event from the database
    }

    protected void btnUpdateTeam_Click(object sender, EventArgs e)
    {
        // Redirect to UpdateTeam.aspx
        Response.Redirect("UpdateTeam.aspx");
    }

    protected void btnManageTeams_Click(object sender, EventArgs e)
    {
        // Redirect to ManageTeams.aspx
        Response.Redirect("ManageTeams.aspx");
    }

    protected void btnFacultyMentorManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("FacultyMentorManagement.aspx");
    }

    protected void btnGenerateReportsPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerateReport.aspx");
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        // Clear session or any authentication data if needed
        // Redirect to Login page
        Response.Redirect("Login.aspx");
    }

    protected void btnAddEvent_Click(object sender, EventArgs e)
    {
        // Redirect to AddEvent.aspx
        Response.Redirect("AddEvent.aspx");
    }
}
