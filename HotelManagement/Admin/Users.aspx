<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="HotelManagement.Admin.AddWaiter" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/css/toastr.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/js/toastr.js"></script>
    <style>
       
    </style>
    <script>
        window.onload = function () {

            document.getElementById("openid").click();
        };

    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <br />
        <br />
        <br />
        <%------------------------------------%>
        <p>
            <button class="btn btn-primary " id="openid" type="button" data-toggle="collapse" data-target="#multiCollapseExample1" aria-expanded="true" aria-controls="multiCollapseExample1" onclick="HideDel()">Add Users</button>
            <button class="btn btn-primary" id="delid" type="button" data-toggle="collapse" data-target="#multiCollapseExample2" aria-expanded="false" aria-controls="multiCollapseExample1" onclick="HideAdd()">Delete Users</button>
        </p>
        <div style="display: flex; justify-content: center">
            <div class="row" style="display: flex; justify-content: center">
                <div class="col">
                    <div class="collapse multi-collapse" id="multiCollapseExample1">
                        <div class="card card-body" style="background-color: aliceblue;">
                            <div
                                style="border-width: medium; margin: auto; width: 470px; text-align: center; height: max-content;">
                                <div id="DivAddItems" style="margin-left: 15px; border-radius: 10px; width: 488px; background-color: aliceblue; color: #000000;">
                                    <br />
                                    <br />
                                    <div class="btn-group px-3" role="group">
                                        <button type="button" class="btn btn-secondary">Role</button>
                                        <div class="btn-group" role="group">
                                            <asp:DropDownList class="btn btn-secondary" ID="DropDownList1" runat="server">
                                                <asp:ListItem class="text-center" Value="2">Waiter</asp:ListItem>
                                                <asp:ListItem class="text-center" Value="1">Admin</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>


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
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="collapse multi-collapse" id="multiCollapseExample2">
                    <div class="card card-body">
                        <div style="display: flex; overflow: scroll; height: 400px; justify-content: center">
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="354px" Width="505px"
                                AutoGenerateDeleteButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="OnRowDeleting">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%------------------------------------%>
    </div>
</asp:Content>
