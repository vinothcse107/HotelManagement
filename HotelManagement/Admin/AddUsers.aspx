<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddUsers.aspx.cs" Inherits="HotelManagement.Admin.AddWaiter" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <div
            style="border-width: medium; margin: auto; width: 470px; text-align: center; height: max-content;">
            <div id="DivAddItems" style="margin-left: 15px; border-radius: 10px; width: 488px; background-color: aliceblue; color: #000000;">
                <br />
                <br />
                <asp:DropDownList class="btn btn-secondary" ID="DropDownList1" runat="server">
                    <asp:ListItem class="text-center" Value="2">Waiter</asp:ListItem>
                    <asp:ListItem class="text-center" Value="1">Admin</asp:ListItem>

                </asp:DropDownList>

                <br />
                <br />
                <div class="form-label-group">
                    <asp:Label ID="Label2" class="control-label" runat="server" Text="Username" Font-Size="Larger"></asp:Label>
                    <asp:TextBox ID="username" class="form-control" runat="server" required Minlength="8" MaxLength="16" Height="30px" Width="353px" Style="margin: auto"></asp:TextBox>
                </div>

                <br />

                <div class="form-label-group">
                    <asp:Label ID="Label1" class="control-label" runat="server" Text="Password" Font-Size="Larger"></asp:Label>
                    <asp:TextBox ID="password" type="password" class="form-control" required Minlength="8" MaxLength="16" runat="server" Height="30px" Width="353px" Style="margin: auto"></asp:TextBox>
                </div>

                <br />

                <div class="form-label-group">
                    <asp:Label ID="Label3" class="control-label" runat="server" Text="Phone" Font-Size="Larger"></asp:Label>
                    <asp:TextBox ID="phone" type="number" class="form-control" runat="server" required Minlength="10" MaxLength="10" Height="30px" Width="353px" Style="margin: auto"></asp:TextBox>
                </div>


                <br />
                <asp:Button ID="adder" runat="server" Text="Add Waiter" Style="text-align: center" Font-Size="20px"
                    OnClick="Add_Waiter" class="btn btn-success" />
                <hr />
            </div>
        </div>
    </div>


</asp:Content>
