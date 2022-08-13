<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="HotelManagement.Admin.AddItem" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <br />
        

        <br />
        <br />
        <div style="border-width: medium; margin: auto; width: 470px; text-align: center; height: max-content;">
            <div id="DivAddItems" style="margin-left: 15px; border-radius: 10px; width: 488px; background-color: aliceblue; color: #000000;">
                <br />
                <br />
                <div class="form-label-group">
                    <asp:Label class="control-label" runat="server" Text="ItemName" Font-Size="Larger"></asp:Label>
                    <asp:TextBox ID="ItemName" class="form-control" runat="server" Height="30px" Width="353px" Style="margin: auto"></asp:TextBox>
                </div>

                <br />
             
                <div class="form-label-group">
                    <asp:Label class="control-label" runat="server" Text="Price" Font-Size="Larger"></asp:Label>
                    <asp:TextBox ID="Price" class="form-control" runat="server" Height="30px" Width="353px" Style="margin: auto"></asp:TextBox>
                </div>

                <br />
                <asp:Button ID="AddItemsToMenu" runat="server" Text="Add Item" style="text-align: center" Font-Size="20px"
                    OnClick="AddItemsToMenu_Click" class="btn btn-primary align-content-center"/>
                <hr />
                <asp:Button class="btn btn-primary align-content-center" style="text-align: center" Font-Size="20px" ID="Add_Table" runat="server" Text="Add Table" OnClick="Add_Table_Click" />
                <br />
                <br />
                <asp:Label ID="TableLabel" runat="server" ></asp:Label>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
