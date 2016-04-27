<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="bloggpost.aspx.cs" Inherits="Korsbarsgarden.bloggpost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="hfont" style="text-align:center">
                <asp:Label ID="lbl_head" runat="server" Text="Label"></asp:Label>
                    </h3>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">          
                <p style="text-align:center">
                <asp:Label ID="lbl_blogtext" runat="server" Text="" ></asp:Label>
                </p>
                <img class="img-responsive" src="http://placehold.it/900x300" alt="" />
            </div>
            <div class="col-lg-2"></div>
        </div>
    </div>
</asp:Content>
