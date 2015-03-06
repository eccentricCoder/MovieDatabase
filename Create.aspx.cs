using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Create : System.Web.UI.Page
{
    private string connString = WebConfigurationManager.ConnectionStrings["MoviesConnection"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void OnClick_btnCreate(object sender, EventArgs e)
    {
        string title = txtTitle.Text;
        string ReleaseDate = txtReleaseDate.Text;
        string Genre = txtGenre.Text;
        string price = txtPrice.Text;

        string cmdText = @"INSERT INTO dbo.Movies (Title, ReleaseDate, Genre, Price)
                           VALUES (@title, @date, @genre, @price);";

        try
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@date", ReleaseDate);
                cmd.Parameters.AddWithValue("@genre", Genre);
                cmd.Parameters.AddWithValue("@price", price);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result <= 0)
                {
                    lblMessage.Style["color"] = "Red";
                    lblMessage.Text = "The movie was not updated.";
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                cmd.Dispose();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "An error occured.<br/>Message: " + ex.Message + "<br />Stack Trace:\n" + ex.StackTrace;
        }
    }
}