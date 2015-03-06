<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="Delte - Movie Database" CodeFile="Delete.aspx.cs" Inherits="Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <h1>Delete</h1>
    <h2>Are you sure you want to delte this?</h2>
    <h3>Movie</h3>

    <hr />
    <dl class="dl-horizontal">
        <asp:HiddenField ID="hiddenMovieID" runat="server" />
      <dt>
        <asp:Label ID="lblTitle" runat="server" Text="Title:" />
      </dt>

      <dd>
        <asp:Label ID="lblDisplayTitle" runat="server" />
      </dd>

      <dt>
        <asp:Label ID="lblReleaseDate" runat="server" Text="Release Date:" />
      </dt>

      <dd>
        <asp:Label ID="lblDisplayReleaseDate" runat="server" />
      </dd>

      <dt>
        <asp:Label ID="lblGenre" runat="server" Text="Genre:" />
      </dt>

      <dd>
        <asp:Label ID="lblDisplayGenre" runat="server" />
      </dd>

      <dt>
        <asp:Label ID="lblPrice" runat="server" Text="Price:" />
      </dt>
      <dd>
        <asp:Label ID="lblDisplayPrice" runat="server" />
      </dd>
    </dl>
    <hr />

    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"/> 
    <br />

    <asp:HyperLink ID="lnkBackToList" runat="server" Text="Back To List" NavigateUrl="~/Default.aspx" />
    <div>
        <asp:Label ID="lblMessage" runat="server" />
    </div>

</asp:Content>
