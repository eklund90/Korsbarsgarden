﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="skapakonto.aspx.cs" Inherits="Korsbarsgarden.skapakonto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server">    
    <div class="container container-background">
        <div class="row">
            <div class="col-md-3"></div>
            
            <div class="col-md-6">
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Förnamn</label>
                        <asp:TextBox ID="txtBox_skapakonto_fornamn" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Efternamn</label>
                        <asp:TextBox ID="txtBox_skapakonto_efternamn" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Personnummer</label>
                        <asp:TextBox ID="txtBox_skapakonto_personnr" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Telefonnummer</label>
                        <asp:TextBox ID="txtBox_skapakonto_telefonnr" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Adress</label>
                        <asp:TextBox ID="txtBox_skapakonto_adress" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Postnummer</label>
                        <asp:TextBox ID="txtBox_skapakonto_postnr" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Postort</label>
                        <asp:TextBox ID="txtBox_skapakonto_postort" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Epost</label>
                        <asp:TextBox ID="txtBox_skapakonto_epost" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Lösenord</label>
                        <asp:TextBox ID="txtBox_skapakonto_losenord" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Behörighet</label>
                        <asp:DropDownList ID="dropdown_skapakonto_behorighet" CssClass="form-control" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="1">Personal</asp:ListItem>
                            <asp:ListItem Value="2">Förälder</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <asp:Button ID="skapamedlem" runat="server" Text="Button" OnClick="skapamedlem_Click" />
            <div class="col-md-3"></div>

        </div>
    </div>
</form>
</asp:Content>
