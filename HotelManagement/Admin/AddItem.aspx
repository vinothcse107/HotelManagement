﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="HotelManagement.Admin.AddItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/css/toastr.css" rel="stylesheet"/>
<script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/js/toastr.js"></script>
    <style>
       
    </style>
    <script>
        $(document).ready(function () {

            //success toast
            $('#AddItemsToMenu').click(function () {

                toastr.options = {
                    "closeButton": true,
                    "debug": true,
                    "newestOnTop": false,
                    "progressBar": true,
                    "positionClass": "toast-top-right",
                    "preventDuplicates": false,
                    "showDuration": "300",
                    "hideDuration": "1000000",
                    "timeOut": "3000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                }
                toastr["success"]("Table Added");
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

    <div>
        <br />
        <br />
        <br />
        <br />
        <div style="border-width: medium; margin: auto; width: 470px; text-align: center; height: max-content;">
            <div id="DivAddItems" style="margin-left: 15px; border-radius: 10px; width: 488px; background-color: aliceblue; color: #000000;">
                <br />
                <br />
                <div class="form-label-group">
                    <asp:Label class="control-label" runat="server" Text="ItemName" Font-Size="Larger"></asp:Label>
                    <asp:TextBox ID="ItemName" class="form-control" runat="server" required Minlength="5" MaxLength="30" Height="30px" Width="353px" Style="margin: auto"></asp:TextBox>
                </div>

                <br />

                <div class="form-label-group">
                    <asp:Label class="control-label" runat="server" Text="Price" Font-Size="Larger"></asp:Label>
                    <asp:TextBox ID="Price" class="form-control" runat="server" min="1" max="1000" Height="30px" type="number" Width="353px" Style="margin: auto"></asp:TextBox>
                </div>

                <br />

                <div class="btn-group px-3" role="group">
                    <button type="button" class="btn btn-secondary">Item Category</button>
                    <div class="btn-group" role="group">
                        <asp:DropDownList class="btn btn-secondary" ID="CategoryList" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <br />
                <br />
                <asp:Button ID="AddItemsToMenu" runat="server" Text="Add Item" Style="text-align: center" Font-Size="20px"
                    OnClick="AddItemsToMenu_Click"  class="btn btn-primary align-content-center" />

                <hr />
                <asp:Button class="btn btn-primary align-content-center" Style="text-align: center" Font-Size="20px" ID="Add_Table" runat="server" Text="Add Table" OnClick="Add_Table_Click" />
                <br />
                <br />
                <asp:Label ID="TableLabel" runat="server"></asp:Label>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
