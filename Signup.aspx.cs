using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // Check if any field is empty
        if (string.IsNullOrEmpty(UserName.Text) || string.IsNullOrEmpty(ID.Text) || string.IsNullOrEmpty(Password.Text) ||
            string.IsNullOrEmpty(Confirm_Password.Text) || string.IsNullOrEmpty(Email.Text))
        {
            Warning_msg.Text = "Please fill in all fields.";
            return;
        }

        // Check if password and confirm password match
        if (Password.Text != Confirm_Password.Text)
        {
            Warning_msg.Text = "Password do not match. Please try again";
            return;
        }

        // Retrieve form inputs
        string username = UserName.Text;
        string id = ID.Text;
        string password = Password.Text;
        string email = Email.Text;
        string type = Type.SelectedValue;

        // Create connection and command objects
        using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-EO0CMVG;Initial Catalog=SE;Integrated Security=True"))
        {
            con.Open();

            // Check if the username, ID, and email already exist in the database
            string query = "SELECT COUNT(*) FROM [User] WHERE UserName = @username OR ID = @id OR Email = @email";
            using (SqlCommand cm = new SqlCommand(query, con))
            {
                cm.Parameters.AddWithValue("@username", username);
                cm.Parameters.AddWithValue("@id", id);
                cm.Parameters.AddWithValue("@email", email);

                int count = (int)cm.ExecuteScalar();

                if (count > 0)
                {
                    Warning_msg.Text = "Username, ID, or Email already exists. Please choose different ones.";
                    return;
                }
            }

            // Insert user data into the database
            string insertQuery = "INSERT INTO [User] (UserName, ID, Password, Email, Type) VALUES (@username, @id, @password, @email, @type)";
            using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
            {
                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@id", id);
                insertCmd.Parameters.AddWithValue("@password", password);
                insertCmd.Parameters.AddWithValue("@email", email);
                insertCmd.Parameters.AddWithValue("@type", type);

                insertCmd.ExecuteNonQuery();
            }

            Warning_msg.Text = "You have successfully signed up.";
        }
    }


    protected void Type_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}



