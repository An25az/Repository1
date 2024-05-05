using System;
using System.Data.SqlClient;

public partial class SponsorshipPackageSelection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string username = Request.QueryString["param1"];
        }
    }

    protected void SelectPackage(object sender, EventArgs e)
    {
        string sponsorName = Request.QueryString["param1"]; 
        //if (string.IsNullOrWhiteSpace(sponsorName))
        //{
        //    ShowErrorMessage("Please enter the sponsor name.");
        //    return;
        //}

        // Get the selected package name
        string packageName = ((System.Web.UI.WebControls.Button)sender).CommandArgument;

        // Save sponsor details in the Sponsors table
        if (SaveSponsorDetails(sponsorName, packageName))
        {
            string message = $"Package selection successful for sponsor {sponsorName}. Thank you!\r\nSelected Package: {packageName}";
            ShowSuccessMessage(message);
        }
        else
        {
            ShowErrorMessage("Failed to save sponsor details. Please try again later.");
        }
    }

    private bool SaveSponsorDetails(string sponsorName, string packageName)
    {
        bool success = false;
        string connectionString = "Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True";
        string query = "INSERT INTO Sponsors (SponsorName, SelectedPackage, CreatedDate) VALUES (@SponsorName, @SelectedPackage, GETDATE())";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SponsorName", sponsorName);
                    command.Parameters.AddWithValue("@SelectedPackage", packageName);

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

    private void ShowSuccessMessage(string message)
    {
        lblSuccessMessage.Text = message;
        lblSuccessMessage.Visible = true;
        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", $"alert('{message}');", true);
    }

    private void ShowErrorMessage(string message)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", $"alert('{message}');", true);
    }
}