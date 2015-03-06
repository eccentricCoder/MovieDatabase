<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="Create.aspx.cs" Inherits="Create" %>

<asp:Content ID="CreateContent" ContentPlaceHolderID="Main" runat="server">
    <h1>Create</h1>
    <h2>Movie</h2>

<hr />
    <dl class="dl-horizontal">
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
    <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="OnClick_btnCreate" />
    <br />
    <asp:HyperLink ID="lnkBackToList" runat="server" Text="Back To List" NavigateUrl="~/Default.aspx" />
    <div>
        <asp:Label ID="lblMessage" runat="server" />
    </div>
</asp:Content>
