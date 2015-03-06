<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="Details" CodeFile="Details.aspx.cs" Inherits="Details" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

    <h1>Details</h1>
    <h2>Movie</h2>

    <hr />
    <dl class="dl-horizontal">
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

    <asp:HyperLink ID="lnkEdit" runat="server" Text="Edit"/> | <asp:HyperLink ID="lnkBackToList" runat="server" Text="Back To List" NavigateUrl="~/Default.aspx" />
    <div>
        <asp:Label ID="lblMessage" runat="server" />
    </div>
</asp:Content>
