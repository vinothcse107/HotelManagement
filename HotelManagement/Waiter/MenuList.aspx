<%@ Page Title="" Language="C#" MasterPageFile="~/Waiter/Waiter.Master" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="HotelManagement.Pages.MenuList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Aboreto&family=B612&family=Copse&family=Lato&display=swap');

        table {
            border-spacing: unset;
            border-collapse: collapse;
            background: white;
            border: none;
            border-color: transparent;
            border-radius: 5px;
            overflow: hidden;
            width: 80%;
            margin: 0 auto;
            position: relative;
        }

            table * {
                position: relative;
                font-family: 'Lato', sans-serif;
                font-weight: 500
            }

            table td, table th {
                padding-left: 8px;
            }

            table th {
                height: 60px;
                background: #36304a;
                /*font-family: 'Aboreto', cursive;*/
                font-family: 'B612', sans-serif;
            }

            table tr {
                height: 50px;
            }

            table td.Quantity {
                width: max-content;
            }

            table td, table th {
                text-align: center;
            }

                table td.l, table th.l {
                    text-align: right;
                }

                table td.c, table th.c {
                    text-align: center;
                }

                table td.r, table th.r {
                    text-align: center;
                }


        th {
            font-family: Fira Sans;
            font-size: 18px;
            color: #fff;
            line-height: 1.2;
            font-weight: unset;
        }

        tr:nth-child(even) {
            background-color: #f5f5f5;
        }

        tr {
            font-family: OpenSans-Regular;
            font-size: 15px;
            color: #808080;
            line-height: 1.2;
            font-weight: unset;
        }

            tr:hover {
                color: #555555;
                background-color: #f5f5f5;
                cursor: pointer;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <br />
        <br />
        <br />
        <div class="m-2" id="Outer">
            <br />
            <div style="display: flex; justify-content: center">

                <div class="btn-group px-3" role="group">
                    <button type="button" class="btn btn-secondary">Table</button>
                    <div class="btn-group" role="group">
                        <asp:DropDownList class="btn btn-secondary" ID="TablesDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="GetCurrentOrderId"></asp:DropDownList>
                    </div>
                </div>
                <br />
                <br />
                <asp:Button ID="NewOrder" class="btn btn-success" runat="server" Text="New Order" OnClick="NewOrder_Click" />
                <br />
            </div>
            <br />
            <div style="display: flex; justify-content: center">
                <asp:Button class="btn btn-success mr-1" ID="Button1" runat="server" Text="Veg" value="1" OnCommand="ItemsByCategory" CommandName="veg" CommandArgument="1" />
                <asp:Button class="btn btn-danger mr-1" ID="Button2" runat="server" Text="Non-Veg" value="2" OnCommand="ItemsByCategory" CommandName="nonveg" CommandArgument="2" />
                <asp:Button class="btn btn-info mr-1" ID="Button3" runat="server" Text="Desserts" value="3" OnCommand="ItemsByCategory" CommandName="dessert" CommandArgument="3" />
                <asp:Button class="btn btn-warning mr-1" ID="Button4" runat="server" Text="Soup" value="4" OnCommand="ItemsByCategory" CommandName="soup" CommandArgument="4" />
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <asp:Repeater ID="menulist" runat="server">
                <HeaderTemplate>
                    <table cellspacing="0" rules="all">
                        <tr class="text-center">
                            <th scope="col" style="width: 80px">S.No 

                            </th>
                            <th scope="col" style="width: 120px">Item Name
                            </th>
                            <th scope="col" style="width: 100px">Price
                            </th>
                            <th scope="col" style="width: 100px">Quantity
                            </th>
                            <th scope="col" style="width: 100px">Add Item
                            </th>
                            <th scope="col" style="width: 100px">Availablity
                            </th>

                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="itid" runat="server" Text='<%# Container.ItemIndex + 1 %>' />
                            <asp:Label ID="ItemId" runat="server" Visible="false" Text='<%# Eval("ItemId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="itname" runat="server" Text='<%# Eval("ItemName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="itprice" runat="server" Text='<%# Eval("Price") %>' />
                        </td>

                        <td class="Quantity">
                            <asp:TextBox ID="Quantity" runat="server" Width="50px" required min="0" max="500" Enabled='<%# (int)Eval("TotalQuantity") == 0 ? false : true%>' Text="0" type="number"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="AddBtn" runat="server" class="btn btn-success" Text="Add" OnClick="Add_Click" CommandArgument='<%# Eval("ItemId")  %>' />
                        </td>
                        <td>

                            <asp:Label Text='<%# (int)Eval("TotalQuantity") > 0 ? "Available" : "Not Available" %>'
                                class='<%# (int)Eval("TotalQuantity") > 0 ? "bg-success" : "bg-danger" %>'
                                runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Label ID="Label2" runat="server" Text="" Style="color: white"></asp:Label>
            <br />
            <div style="display: flex; justify-content: center">
                <asp:Button ID="Order" class="btn btn-success" href="GenerateBill" runat="server" Text="Place Order" OnClick="Order_Click" />
            </div>
            <br />
            &nbsp;
        </div>
    </div>
</asp:Content>
