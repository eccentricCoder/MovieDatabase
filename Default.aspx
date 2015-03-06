<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="Movies Database" CodeFile="Default.aspx.cs" Inherits="_Default"%>


<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

    <h1>Movies</h1>


    <asp:HyperLink ID="lnkCreate" runat="server" NavigateUrl="~/Create.aspx" Text="Create New"/>
        <br /><br />

    <asp:SqlDataSource ID="sourceMovies" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:MoviesConnection %>"
                       SelectCommand="SELECT ID, Title, ReleaseDate, Genre, Price
                                      FROM   dbo.Movies 
                                      ORDER BY ID ASC;"/>

    <asp:GridView ID="MoviesGrid" runat="server" DataSourceID="sourceMovies"
                  AutoGenerateColumns="False" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="ReleaseDate" HeaderText="Release Date" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="Genre" HeaderText="Genre" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="Details.aspx?id={0}" Text="Details" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="Edit.aspx?id={0}" Text="Edit" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="Delete.aspx?id={0}" Text="Delete" />
        </Columns>
    </asp:GridView>

</asp:Content>


