<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HotelManagement.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <asp:Label ID="usernameLabel" runat="server" Text="Username"></asp:Label>
    <asp:TextBox ID="username" runat="server" Text="Logesh"></asp:TextBox>

    <br />
    <br />
    <asp:Label ID="passwordLabel" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="password" runat="server" Text="Logesh"></asp:TextBox>
    <br />
    <br />

    <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
    <hr />
    <asp:Label ID="ResponseLabel" runat="server" Text=""></asp:Label>


</asp:Content>
