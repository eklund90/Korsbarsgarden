<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="bloggpost.aspx.cs" Inherits="Korsbarsgarden.bloggpost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="hfont">Test av Jimmy</h1>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">
                <hr />
                <asp:Label ID="lbl_blogghead" runat="server" Text="2016-04-26"></asp:Label>
                <hr />
                <img class="img-responsive" src="http://placehold.it/900x300" alt="" />

            </div>
            <div class="col-lg-2"></div>
        </div>
    </div>
</asp:Content>
