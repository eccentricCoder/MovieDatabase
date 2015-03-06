using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Details : System.Web.UI.Page
{
    private string connectionString = WebConfigurationManager.ConnectionStrings["MoviesConnection"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }

    private void FillPage()
    {
        string movieId = Request.QueryString["id"];

        if (string.IsNullOrEmpty(movieId) || string.IsNullOrWhiteSpace(movieId))
        {
            // Print out an error message
            return;
        }
        string query = "Select ID, Title, Genre, ReleaseDate, Price FROM Movies WHERE ID = @id";

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", movieId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dsMovie = new DataSet();

                conn.Open();
                adapter.Fill(dsMovie, "Movie");

                foreach (DataRow row in dsMovie.Tables["Movie"].Rows)
                {
                    lblDisplayTitle.Text = row["Title"] as string;
                    lblDisplayReleaseDate.Text = DateTime.Parse(row["ReleaseDate"].ToString()).Date.ToShortDateString();
                    lblDisplayGenre.Text = row["Genre"] as string;
                    lblDisplayPrice.Text = row["Price"].ToString();
                    lnkEdit.NavigateUrl = string.Format("Edit.aspx?id={0}", Int32.Parse(row["ID"].ToString()));
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "An error occured.<br/>Message: " + ex.Message + "<br />Stack Trace:\n" + ex.StackTrace;
        }



    }
}