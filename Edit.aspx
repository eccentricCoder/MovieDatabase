<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="Edit - Movie Database" CodeFile="Edit.aspx.cs" Inherits="Edit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
<h1>Edit</h1>
    <h2>Movie</h2>
    <hr />
    <dl class="dl-horizontal">
        <asp:HiddenField ID="hiddenMovieID" runat="server" />
      <dt>
        <asp:Label ID="lblTitle" runat="server" Text="Title:" />
      </dt>

      <dd>
        <asp:TextBox ID="txtTitle" runat="server" />
      </dd>

      <dt>
        <asp:Label ID="lblReleaseDate" runat="server" Text="Release Date:" />
      </dt>

      <dd>
        <asp:TextBox ID="txtReleaseDate" runat="server" />
      </dd>

      <dt>
        <asp:Label ID="lblGenre" runat="server" Text="Genre:" />
      </dt>

      <dd>
        <asp:TextBox ID="txtGenre" runat="server" />
      </dd>

      <dt>
        <asp:Label ID="lblPrice" runat="server" Text="Price:" />
      </dt>
      <dd>
        <asp:TextBox ID="txtPrice" runat="server" />
      </dd>
    </dl>
    <hr />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="OnClick_btnSave" />
    <br />
    <asp:HyperLink ID="lnkBackToList" runat="server" Text="Back To List" NavigateUrl="~/Default.aspx" />
    <div>
        <asp:Label ID="lblMessage" runat="server" />
    </div>
</asp:Content>