<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BillingList.aspx.cs" Inherits="HotelManagement._Default" %>

      <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
            <br />
          <div id="WholeContent" >
            <div class="jumbotron" style="text-align:center; background-color:transparent">

                  <asp:Label ID="Label3" runat="server" Text="~ BILLING ~" Font-Size="X-Large" Font-Bold="True" >
                  </asp:Label>
              </div>
            <div style=" width:100%">
                  <div id="Inner" style="width: 492px; border-style: solid; border-width: medium; margin:auto ">

                        <asp:Label ID="Label1" runat="server" Text="TableNo " Font-Bold="True" Font-Size="Medium">
                        </asp:Label>

                        <asp:DropDownList ID="DropDownList1" runat="server"
                              OnSelectedIndexChanged="GridView_SelectedIndexChanged" AutoPostBack="true" Height="40px"
                              Width="125px"></asp:DropDownList>

                        <hr />
                        <asp:GridView ID="GridView" runat="server" OnLoad="GridView_SelectedIndexChanged" Height="185px"
                              Width="289px" CellPadding="4" HorizontalAlign="Center" ForeColor="#333333" GridLines="None">
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

                        <br />
                        <div id="Buttons" tex-align:"center" style="width: 282px; margin:auto">
                              <asp:Button ID="NewOrder" runat="server" Font-Size="15px" Text="Order" Height="27px"
                                    PostBackUrl="~/Pages/Orders.aspx" Width="120px" BorderStyle="Double"
                                    CssClass="btn-success" Font-Bold="True" />

                              <asp:Button ID="BillButton" runat="server" Font-Size="15px" Text="Get Bill"
                                    OnClick="BillButton_Click" BorderStyle="Double" CssClass="btn-primary"
                                    Font-Bold="True" Height="27px" Width="136px" />
                        </div>
                        <br />
                        <div style="text-align:center">
                              <asp:Label ID="Label2" runat="server" Font-Size="16px" CssClass="btn-primary"></asp:Label>
                        </div>
                  </div>

            </div>

              </div>
      </asp:Content>
