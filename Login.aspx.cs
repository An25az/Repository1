using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // You can add any initialization logic here
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        string username = UserName.Text;
        string password = Password.Text;

        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            string query = "SELECT COUNT(*) FROM [User] WHERE UserName = @username AND Password = @password";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    string type = "";

                    Warning_msg.Text = "You have successfully logged in to your account.";

                    // Set username in the session
                    Session["Username"] = username;

                    string query2 = "SELECT Type FROM [User] WHERE UserName = @username AND Password = @password";
                    using (SqlCommand cmd2 = new SqlCommand(query2, con))
                    {
                        cmd2.Parameters.AddWithValue("@username", username);
                        cmd2.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd2.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                type = reader["Type"].ToString();
                            }
                        }
                    }

                    if (type == "Student")
                    {
                        Response.Redirect("~/UserDashboard.aspx");
                    }
                    else if (type == "Admin")
                    {
                        Response.Redirect("~/AdminDashboard.aspx");
                    }
                    else if (type == "Sponser")
                    {
                        Response.Redirect("SponserPackageSelection.aspx?param1=" + username);

                    }
                    else if (type == "FacultyMentor")
                    {
                        Response.Redirect("~/StudentExecutiveManagement.aspx");
                    }
                    else
                    {
                        Warning_msg.Text = "Only students, admin, sponsers, and faculty mentors are allowed to access the dashboards.";
                    }
                }
                else
                {
                    Warning_msg.Text = "Incorrect username or password.";
                }
            }
        }
    }
}
