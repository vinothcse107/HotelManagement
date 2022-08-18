<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kitchen.aspx.cs" Inherits="HotelManagement.Kitchen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Aboreto&family=B612&family=Copse&family=Lato&display=swap');

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

        .raise:hover,
        .raise:focus {
            box-shadow: 0 0.5em 0.5em -0.4em var(--hover);
            transform: translateY(-0.25em);
            color: #ffa260
        }

        button {
            background: white;
            border: 2px solid;
            font: inherit;
            line-height: 1;
            font-size: 7px;
            font-weight: 500;
            height: 45px;
            width: 40px
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="No Orders Available"></asp:Label>
        <div style="display: flex; justify-content: center">
            <asp:Repeater ID="tableList" runat="server">
                <ItemTemplate>
                    <asp:Label ID="orderno" runat="server" Visible="false" Text='<%# Eval("OrderId") %>'></asp:Label>
                    <asp:Button class="raise mr-1 mb-1 px-2 py-1" ID="Button1" OnClick="TableNo" runat="server" Text='<%# Eval("OrderId") %>' />
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
                        <th scope="col" style="width: 100px">Quantity
                        </th>

                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="itid" runat="server" Text='<%# Container.ItemIndex + 1 %>' />
                    </td>
                    <td>
                        <asp:Label ID="itname" runat="server" Text='<%# Eval("ItemName") %>' />
                    </td>
                    <td class="Quantity">
                        <asp:Label ID="Quantity" runat="server" Text='<%# Eval("Quantity") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <td>
                    <asp:Button ID="DelBtn" runat="server" class="btn btn-danger" Text="Ready" OnClick="Ready_Click" />
                </td>
            </FooterTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
