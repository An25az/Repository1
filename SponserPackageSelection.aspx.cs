using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SponsorshipPackageSelection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSponsorshipPackages();
        }
    }

    protected void BindSponsorshipPackages()
    {
        string connectionString = "Data Source=HAMZASHAHID\\SQLEXPRESS;Initial Catalog=SE;Integrated Security=True";
        string query = "SELECT PackageID, PackageName, Benefits, Cost FROM SponsorshipPackages";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    gvSponsorshipPackages.DataSource = dt;
                    gvSponsorshipPackages.DataBind();
                }
            }
        }
    }

    protected void gvSponsorshipPackages_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "SelectPackage")
        {
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name; // Retrieve the username of the current logged-in user

                int packageID = Convert.ToInt32(e.CommandArgument);
                string packageName = GetPackageName(packageID);

                // Display a popup success message with the username and package ID chosen
                string message = $"Package selection successful for sponsor {username}. Thank you!\r\nSelected Package: {packageName} (ID: {packageID})";
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMessage", $"showMessage('{message}');", true);

                // Display the username and package selected on screen
                lblSelectedPackage.Text = $"Selected Package: {packageName} (ID: {packageID}) for sponsor {username}";
                lblSelectedPackage.Visible = true;
            }
            else
            {
                string message = "Please login to select a package.";
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMessage", $"showMessage('{message}');", true);
                Response.Redirect("~/Login.aspx");
            }
        }
    }


    private int GetSponsorIDByUsername(string username)
    {
        int sponsorID = 0;
        string connectionString = "Data Source=HAMZASHAHID\\SQLEXPRESS;Initial Catalog=SE;Integrated Security=True";
        string query = "SELECT ID FROM [User] WHERE UserName = @Username AND [Type] = 'Sponser'";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    sponsorID = Convert.ToInt32(result);
                }
            }
        }

        return sponsorID;
    }

    private bool RecordSelectedPackage(int sponsorID, int packageID)
    {
        bool success = false;
        string connectionString = "Data Source=HAMZASHAHID\\SQLEXPRESS;Initial Catalog=SE;Integrated Security=True";
        string query = "UPDATE Sponsor SET SelectedPackageID = @PackageID WHERE SponsorID = @SponsorID";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PackageID", packageID);
                    command.Parameters.AddWithValue("@SponsorID", sponsorID);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        success = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Log the exception
        }

        return success;
    }

    private string GetPackageName(int packageID)
    {
        string packageName = string.Empty;
        string connectionString = "Data Source=HAMZASHAHID\\SQLEXPRESS;Initial Catalog=SE;Integrated Security=True";
        string query = "SELECT PackageName FROM SponsorshipPackages WHERE PackageID = @PackageID";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PackageID", packageID);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        packageName = result.ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Log the exception
        }

        return packageName;
    }

    private void ShowMessage(string message)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{message}');", true);
    }
}
