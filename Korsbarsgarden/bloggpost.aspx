<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="bloggpost.aspx.cs" Inherits="Korsbarsgarden.bloggpost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form role="form" runat="server">    
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <asp:Label ID="lbl_head" CssClass="lblhead" runat="server" Text="Label"></asp:Label>
                <hr />
                <ol class="breadcrumb">
                    <li>
                        <a href="blogg.aspx">Blogg</a>
                    </li>
                    <li id="paragraph" runat="server" class="actie"></li>
                </ol>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">
                <%--<asp:Label ID="lbl_date" runat="server" Text=""></asp:Label>
                <hr class="hr2"/>--%>
                <img class="img-responsive" src="http://placehold.it/900x300" alt="" />
                <hr />
                <asp:Label CssClass="pfont" ID="lbl_blogtext" runat="server" Text=""></asp:Label>
                <hr />                
                <div class="well">
                    <h4>Lämna en kommentar:</h4>                    
                    <div class="form-group">
                        <asp:TextBox ID="txtBox_kommentar" CssClass="form-control" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <asp:Button ID="btn_sparakommentar" runat="server" Text="Spara" CssClass="btn btn-primary" OnClick="btn_sparakommentar_Click" />
                    <asp:Panel ID="PanelResponse_bloggpost" runat="server" CssClass="alert PanelResponse">
                        <asp:Label ID="LabelResponse_bloggpost" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                </div>
                <hr />
                    <asp:Repeater ID="Repeater_kommentar" runat="server">
                       <ItemTemplate>
                           <div class="media">
                            <div class="media-body">
                                <h4 id="kommentarhead" runat="server" class="media-heading"><%# Eval("publicerare") %> <small id="smallhead" runat="server"><%# Eval("datum") %></small></h4>
                                <p id="kommentartext" runat="server" class="pfont"><%# Eval("text") %></p>
                            </div>
                        </div>
                       </ItemTemplate>                         
                    </asp:Repeater>                
                              
            </div>
            <div class="col-lg-2"></div>
        </div>
    </div>
</form>  
</asp:Content>
