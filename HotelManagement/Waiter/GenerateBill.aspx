<%@ Page Title="" Language="C#" MasterPageFile="~/Waiter/Waiter.Master" AutoEventWireup="true" CodeBehind="GenerateBill.aspx.cs" Inherits="HotelManagement.Waiter.GenerateBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <style>
        .td {
            border: none;
        }

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

        .amount {
            background-color: white;
            color: black;
            height: fit-content;
            width: 100%;
            font-size: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <br />
        <br />
        <div class="m-2" id="Outer">
            <br />
            <%--    <div style="display: flex; justify-content: center">

                <div class="btn-group px-3" role="group">
                    <button type="button" class="btn btn-secondary">Table</button>
                    <div class="btn-group" role="group">
                        <asp:DropDownList class="btn btn-secondary" ID="TablesDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="GetCurrentOrderId"></asp:DropDownList>
                    </div>--%>
            <div style="display: flex; justify-content: center">
                <asp:Repeater ID="tableList" runat="server">
                    <ItemTemplate>
                        <asp:Label ID="tableno" runat="server" Visible="false" Text='<%# Eval("TableId") %>'></asp:Label>
                        <asp:Button ID="TableId" runat="server" Text='<%# Eval("TableId") %>' OnClick="TableNo" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <asp:Repeater ID="Orderedlist" runat="server">
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
                            <th scope="col" style="width: 100px">Delete Item
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
                            <asp:Label ID="Quantity" runat="server" Text='<%# Eval("Quantity") %>' />
                        </td>
                        <td>
                            <asp:Button ID="DelBtn" runat="server" class="btn btn-danger" Text="Delete" OnClick="Del_Click" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

        </div>
        <br />
        <div class="amount">
            <asp:Label ID="Amount" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    <br />

    <br />



</asp:Content>
