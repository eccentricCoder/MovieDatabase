using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;

public partial class Edit : System.Web.UI.Page
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
                    txtTitle.Text = row["Title"] as string;
                    txtReleaseDate.Text = DateTime.Parse(row["ReleaseDate"].ToString()).Date.ToShortDateString();
                    txtGenre.Text = row["Genre"] as string;
                    txtPrice.Text = row["Price"].ToString();
                    hiddenMovieID.Value = row["ID"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "An error occured.<br/>Message: " + ex.Message + "<br />Stack Trace:\n" + ex.StackTrace;
        }
    }

    protected void OnClick_btnSave(object sender, EventArgs e)
    {
        string title = txtTitle.Text;
        string ReleaseDate = txtReleaseDate.Text;
        string Genre = txtGenre.Text;
        string price = txtPrice.Text;
        string movieId = hiddenMovieID.Value;

        string cmdText = @"UPDATE dbo.Movies
                           SET    Title=@title, ReleaseDate=@date,
                                  Genre=@genre, Price=@price
                           WHERE  ID=@id;";

        try
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@date", ReleaseDate);
                cmd.Parameters.AddWithValue("@genre", Genre);
                cmd.Parameters.AddWithValue("@price", price);
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