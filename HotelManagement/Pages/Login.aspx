<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HotelManagement.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   

     <section class="" 
   style="overflow:hidden">

        <div class="container-fluid">
            <div  style="text-align:center" class="text-light" >
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <h3 class=" mb-3 pb-3 " style="letter-spacing: 1px;">Log in</h3>
                        <div class="mb-4">
                            <label class="form-label" >Username </label><br />
                            <asp:TextBox type="text" ID="username"  style="text-align:center" class="form-control" Text="LogeshS" runat="server" Height="46px" Width="1009px"></asp:TextBox>
                            
                        </div>
                        <div class="mb-4" style="text-align:center">
                              <label class="form-label" for="Passtxt">Password</label><br />
                            <asp:TextBox type="password" ID="password"  style="text-align:center" class="form-control" runat="server" Text="LogeshS" Height="44px" Width="440px"></asp:TextBox>
                          
                        </div>
                        <div class="pt-1 mb-4">
                            <asp:Button ID="Button1" OnClick="LoginBtn_Click" runat="server" Text="Log in" class="btn btn-info" />
                        </div>
                    <asp:Label ID="ResponseLabel" runat="server" Text=""></asp:Label>
                </div>
           
        </div>

    </section>

</asp:Content>

