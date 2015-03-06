using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Delete : System.Web.UI.Page
{
    private string connString = WebConfigurationManager.ConnectionStrings["MoviesConnection"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillData();
        }
    }

    private void FillData()
    {
        string cmdText = @"Select ID, Title, Genre, ReleaseDate, Price 
                           FROM   Movies 
                           WHERE  ID = @id";
        string movieId = Request.QueryString["id"];
        try
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
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
                    hiddenMovieID.Value = row["ID"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "An error occured.<br/>Message: " + ex.Message + "<br />Stack Trace:\n" + ex.StackTrace;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string movieId = hiddenMovieID.Value;

        string cmdText = @"DELETE FROM   dbo.Movies
                           WHERE  ID=@id;";

        try
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@id", movieId);

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