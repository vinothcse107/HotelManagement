<%@ Page Title="Orders_Page" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"
      CodeBehind="Orders.aspx.cs" Inherits="HotelManagement.NewOrder" %>


      <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            <div>
                  <div class="jumbotron" style="background-color: #FFFFFF; text-align: center">

                        <asp:Label ID="Label1" runat="server" Text="~ MUNNIYANDI VILLAS ~" Font-Size="X-Large"
                              Font-Bold="True"></asp:Label>
                        <br />
                  </div>
                  <div style="width: 100%">
                        <div id="Inner" style="width: 492px; border-style: solid; border-width: medium; margin: auto">
                              <div style="margin: 15px">
                                    <asp:Label ID="Table" runat="server" Text="Table Number " Font-Bold="True"
                                          Font-Size="Medium"></asp:Label>
                                    <asp:DropDownList ID="TablesDropDownList" runat="server" Style="margin-top: 5px"
                                          OnSelectedIndexChanged="GridViewX_SelectedIndexChanged" AutoPostBack="true"
                                          Height="32px" Width="146px" CssClass="mark">
                                    </asp:DropDownList>


                                    <br />
                                    <br />
                                    <asp:Button ID="newOrderBtn" Font-Size="16px" runat="server" Text="New Order"
                                          OnClick="NewOrder_Click" BackColor="#33CC33" BorderColor="Lime"
                                          Font-Bold="True" CssClass="btn-success" />

                              </div>
                              <hr />
                              <div style="margin: 15px">

                                    <asp:Label ID="Item" runat="server" Text="Select Your Item " Font-Bold="True"
                                          Font-Size="Medium"></asp:Label>

                                    <asp:DropDownList ID="ItemsDropDown" runat="server" Style="margin-top: 5px"
                                          OnSelectedIndexChanged="GridViewX_SelectedIndexChanged" Height="32px"
                                          Width="146px" CssClass="mark" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Quantity" runat="server" Text="Quantity " Font-Bold="True"
                                          Font-Size="Medium"></asp:Label>
                                    <asp:TextBox ID="QuantityNo" runat="server" Height="20px" Width="117px"
                                          BorderStyle="Solid"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Button ID="Button2" runat="server" Font-Size="16px" Text="Add Item"
                                          OnClick="AddItems" BackColor="Blue" Font-Bold="True" ForeColor="White"
                                          CssClass="btn-primary" />

                                    <br />

                                    <hr />

                                    <asp:GridView ID="GridViewX" runat="server"
                                          OnSelectedIndexChanged="GridViewX_SelectedIndexChanged" Height="185px"
                                          Width="289px" CellPadding="1" HorizontalAlign="Center"></asp:GridView>
                                    <br />
                              </div>

                              <div style="text-align: center">

                                    <asp:Label ID="ResponseShow" runat="server" CssClass="bg-success"></asp:Label>
                              </div>
                        </div>

                  </div>
            </div>
      </asp:Content>