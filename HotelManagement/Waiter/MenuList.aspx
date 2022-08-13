<%@ Page Title="" Language="C#" MasterPageFile="~/Waiter/Waiter.Master" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="HotelManagement.Pages.MenuList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <style>
        table {
  border-spacing:unset;
  border-collapse: collapse;
  background: white;
  border: none;
 border-color:transparent;
  border-radius: 5px;
  overflow: hidden;
  width: 80%;
  margin: 0 auto;
  position: relative;
}
table * {
  position: relative;
}
table td, table th {
  padding-left: 8px;
}   
table  th {
  height: 60px;
  background: #36304a;
}
table  tr {
  height: 50px;
}
table  tr:last-child {
 
}
table td.Quantity{
    width:max-content;
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


 th{
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
                <asp:DropDownList class="btn btn-secondary" ID="TablesDropDownList" runat="server"></asp:DropDownList>
                <br />
            </div>
            <br />
            <div style="display: flex; justify-content: center">

                <asp:Button class="btn btn-success mr-1" ID="Button1" runat="server" Text="Veg" OnClick="Button2_Click" value="1" />
                <asp:Button class="btn btn-danger mr-1" ID="Button2" runat="server" Text="Non-Veg" value="2" />
                <asp:Button class="btn btn-info mr-1" ID="Button3" runat="server" Text="Desserts" value="3"/>
                <asp:Button class="btn btn-warning mr-1" ID="Button4" runat="server" Text="Soup" value="4" />
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            </div>
           <%-- <div>
                <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" Height="281px" Width="452px" AutoGenerateSelectButton="True" Font-Names="add">
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
                
           </div>--%>
           
          <%--  <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            <asp:Label ID="Label2" runat="server" Text="Label"> </asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Label"> </asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>--%>
            <br />
            <asp:repeater id="menulist" runat="server">
    <headertemplate  >
        <table cellspacing="0" rules="all"  >
            <tr class="text-center">
                <th scope="col" style="width: 80px">
                    S.No 

                </th>
                <th scope="col" style="width: 120px">
                    Item Name
                </th>
                <th scope="col" style="width: 100px">
                    Price
                </th>
                <th scope="col" style="width: 100px">
                    Quantity
                </th>
                 <th scope="col" style="width: 100px">
                    Add Item
                </th>
               
            </tr>
    </headertemplate>
    <itemtemplate>
        <tr>
            <td>
                <asp:label id="itid" runat="server" text='<%# Eval("ItemId") %>' />
            </td>
            <td>
                <asp:label id="itname" runat="server" text='<%# Eval("ItemName") %>' />
            </td>
            <td>
                <asp:label id="itprice" runat="server" text='<%# Eval("Price") %>' />
            </td>
            <td class="Quantity">
                <asp:TextBox ID="Quantity" runat="server" Width="50px" type="number"></asp:TextBox>
            </td>
            <td>
                <button class="btn btn-success">Add</button>
            </td>
        </tr>
    </itemtemplate>

    <footertemplate>
        </table>
    </footertemplate>
</asp:repeater>
                             <br />
            <div style="display: flex; justify-content: center">
                 <asp:Button ID="Order" class="btn btn-success" runat="server" Text="Place Order" OnClick="Order_Click" />
            
            </div>
            <br />
          &nbsp;
        </div>
    </div>
</asp:Content>
