<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
      CodeBehind="BillingList.aspx.cs" Inherits="HotelManagement._Default" %>

      <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

            <br />
            <div class="jumbotron" style="background-color: #FFFFFF; text-align:center">

                  <asp:Label ID="Label3" runat="server" Text="~ BILLING ~" Font-Size="X-Large" Font-Bold="True">
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
                              Width="289px" CellPadding="1" HorizontalAlign="Center"></asp:GridView>

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


      </asp:Content>