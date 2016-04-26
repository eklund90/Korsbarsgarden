<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="bloggpost.aspx.cs" Inherits="Korsbarsgarden.bloggpost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <asp:Label ID="lbl_head" runat="server" Text="Label"></asp:Label>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">
                <hr />
                <asp:Label ID="lbl_date" runat="server" Text=""></asp:Label>
                <hr />
                <img class="img-responsive" src="http://placehold.it/900x300" alt="" />
                <hr />
                <asp:Label ID="lbl_blogtext" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-lg-2"></div>
        </div>
    </div>
</asp:Content>
