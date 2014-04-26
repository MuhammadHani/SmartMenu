<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="SmartMenu.Portal.Pages.Categories.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <h2 id="sec0">Categories</h2>
                    <div class="container">
        <div class="row" style="height:40px;">
            <div class="col-md-6">
<asp:GridView ID="grdCat" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    AllowSorting="false" Width="100%" AllowPaging="false" 
                    EnableTheming="false">
                    <Columns>
                        <asp:TemplateField HeaderText="PrimaryKey1" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="ClsLabel1" runat="server" Text='<%# Eval("ID") %> '>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="English Name">
                            <ItemTemplate>
                                <%# Eval("NameEN") != null ? Eval("NameEN").ToString() : ""%>
                            </ItemTemplate>
                            <ItemStyle Width="140px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Arabic Name">
                            <ItemTemplate>
                                <%# Eval("NameAR") != null ? Eval("NameAR").ToString() : ""%>
                            </ItemTemplate>
                            <ItemStyle Width="125px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Created">
                            <ItemTemplate>
                                <%# Eval("DateCreated") != null ? Eval("DateCreated").ToString() : ""%>
                            </ItemTemplate>
                            <ItemStyle Width="125px" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div class="NoRecordFound">
                            No Records Found
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
                </div>
                </div>
                </div>
        <div class="row" style="height:40px; padding-top:20px; text-align:center;">
            <div class="col-md-6">
        <asp:Button runat="server" ID="btnAdd" Text="Add New Category" 
                onclick="btnAdd_Click" />
                </div>
        </div>
</asp:Content>

