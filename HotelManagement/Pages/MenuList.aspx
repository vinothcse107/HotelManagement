<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="HotelManagement.Pages.MenuList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        <br />
        <br />
        <br />
      <div class= "m-2" id="Outer" style=" border:solid 1px;" >
             <div style="display:flex;  justify-content:center">
            <asp:Button class="btn btn-success mr-1" ID="Button2" runat="server" Text="Veg" />
            <asp:Button class="btn btn-danger mr-1" ID="Button1" runat="server" Text="Non-Veg" />
            <asp:Button class="btn btn-info mr-1" ID="Button3" runat="server" Text="Soup" />
            <asp:Button class="btn btn-warning mr-1" ID="Button4" runat="server" Text="Desserts" />
            </div>
            <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" ForeColor="#333333"   GridLines="None" Height="281px" Width="452px" AutoGenerateSelectButton="True" Font-Names="add">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
          <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

          <asp:Label ID="Label2" runat="server" Text="Label"> </asp:Label>
          <asp:Label ID="Label3" runat="server" Text="Label" > </asp:Label>
          <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
    <%--<asp:repeater id="menulist" runat="server">
    <headertemplate>
        <table cellspacing="0" rules="all" border="1">
            <tr>
                <th scope="col" style="width: 80px">
                    item id
                </th>
                <th scope="col" style="width: 120px">
                    item name
                </th>
                <th scope="col" style="width: 100px">
                    price
                </th>
            </tr>
    </headertemplate>
    <itemtemplate>
        <tr>
            <td>
                <asp:label id="itid" runat="server" text='<%# eval("itemid") %>' />
            </td>
            <td>
                <asp:label id="itname" runat="server" text='<%# eval("itemname") %>' />
            </td>
            <td>
                <asp:label id="itprice" runat="server" text='<%# eval("price") %>' />
            </td>
        </tr>
    </itemtemplate>
    <footertemplate>
        </table>
    </footertemplate>
</asp:repeater>--%>
          </>
            </div>
    </div>
</asp:Content>
