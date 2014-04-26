<%@ Page Title="SmartMenu - Add Category" Language="C#" MasterPageFile="~/Main.Master"
    AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="SmartMenu.Portal.Pages.Categories.AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 id="sec0">
        Add Category</h2>
    <div class="container">
        <div class="row" style="height:40px;">
            <div class="col-md-3">
                <asp:Label runat="server" Text="English Name" ID="lblNameEN"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtNameEN" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row" style="height:40px;">
            <div class="col-md-3">
        <asp:Label runat="server" Text="Arabic Name" ID="lblNameAR"></asp:Label>
        </div>
            <div class="col-md-6">
        <asp:TextBox ID="txtNameAR" runat="server"></asp:TextBox>
        </div>
        </div>
        <div class="row" style="height:40px;">
                    <div class="col-md-3">
        <asp:Label runat="server" Text="Image" ID="lblImage"></asp:Label>
        </div>
            <div class="col-md-6">

            <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
        </div>
        <div class="row" style="height:40px;">
            <div class="col-md-3">
        <asp:Label runat="server" Text="State" ID="lblState"></asp:Label></div>
            <div class="col-md-6">
        <asp:RadioButton ID="rbtnTrue" GroupName="state" Checked="true" runat="server" Text="Active"/>
        <asp:RadioButton ID="rbtnFalse" GroupName="state" runat="server" Text="Inactive"/>
        </div>
        </div>
                <div class="row" style="height:40px; text-align:center;">
            <div class="col-md-6">
            <asp:Button runat="server" ID="btnAdd" Text="Add" onclick="btnAdd_Click" />

            </div>
            </div>
    </div>
</asp:Content>
