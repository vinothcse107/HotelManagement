<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="HotelManagement.Admin.AdminDashboard" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
           <div class="container" style="text-align: center; margin-top: 30px; width: 100%">
        <div
            style="border-style: solid ; border-width: thick; margin: auto; width: 470px; text-align: left; height: 571px;">
            <div id="DivAddItems" style="margin-left: 15px; width: 488px; ">

                <asp:Label ID="Label2" runat="server" Text="ItemName " Font-Bold="True"
                    Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="ItemName" runat="server" BorderColor="Black" BorderStyle="Solid"
                    Height="20px" Width="132px"></asp:TextBox>
                <br />
                <br />

                <asp:Label runat="server" Text="Price " Font-Bold="True" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="Price" runat="server" BorderColor="Black" BorderStyle="Solid"
                    Width="117px" Height="16px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="AddItemsToMenu" runat="server" Text="Add Item" Font-Size="20px"
                    OnClick="AddItemsToMenu_Click" CssClass="btn-primary" Font-Bold="True" Height="29px"
                    Width="100px" />
                <hr />
            </div>

            <div style="margin-left: 15px">
                <asp:Label ID="Label3" runat="server" Text="ItemId " Font-Bold="True" Font-Size="Medium">
                </asp:Label>
                <asp:TextBox ID="DeleteItemId" runat="server" BorderStyle="Solid" Height="20px"
                    Width="136px" BorderWidth="2px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="DeleteItemFromMenu" runat="server" Text="Delete Item" Font-Size="16px"
                    OnClick="DeleteItemFromMenu_Click" CssClass="btn-danger" Font-Bold="True"
                    Height="29px" Width="101px" />
                <hr />
            </div>

            <div style="margin-left: 15px">
                <asp:Label ID="Label4" runat="server" Text="TableNo " Font-Bold="True" Font-Size="Medium">
                </asp:Label>
                <asp:Button ID="AddExtraTables" runat="server" Text="Add Table" Font-Size="16px"
                    OnClick="AddExtraTables_Click" CssClass="btn-primary" Font-Bold="True" /><br />
            </div>
            <hr />

            <div id="AddUser" style="margin-left: 15px">
                <asp:Label ID="usernameLabel" runat="server" Text="Username" Font-Bold="True" Font-Size="Medium">
                </asp:Label>

                <asp:TextBox ID="username" runat="server" BorderStyle="Solid" Height="20px"
                    Width="136px" BorderWidth="2px"></asp:TextBox>

                <asp:Label ID="Label5" runat="server" Text="Password" Font-Bold="True" Font-Size="Medium">
                </asp:Label>

                <asp:TextBox ID="password" runat="server" BorderStyle="Solid" Height="20px"
                    Width="136px" BorderWidth="2px"></asp:TextBox>

                <asp:Label ID="Label1" runat="server" Text="Phone" Font-Bold="True" Font-Size="Medium">
                </asp:Label>

                <asp:TextBox ID="phone" runat="server" BorderStyle="Solid" Height="20px"
                    Width="136px" BorderWidth="2px"></asp:TextBox>

                <asp:DropDownList ID="RolesDropDownList" runat="server"></asp:DropDownList>

                <asp:Button ID="AddUser" runat="server" Text="AddUser" Font-Size="16px"
                    OnClick="AddUserToList" CssClass="btn-primary" Font-Bold="True" /><br />
            </div>
        </div>
       </div>
    </div>
</asp:Content>
