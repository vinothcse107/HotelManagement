<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kitchen.aspx.cs" Inherits="HotelManagement.Kitchen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
