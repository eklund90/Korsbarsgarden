<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Korsbarsgarden.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
<div class="container">
 <div class="row">
     
            <div class="col-md-6">
                <h1 style="text-align:center">Logga in
                    </h1>
                
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Användarnamn</label>
                            <asp:TextBox ID="txtbox_emaillogin" CssClass="form-control" runat="server" required="required"></asp:TextBox>
                            <p class="help-block"></p>
                        </div>
                    </div>               
               
                         <div class="control-group form-group">
                        <div class="controls">
                            <label>Lösenord</label>
                            <asp:TextBox ID="txtbox_password" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                        </div>
                    </div>  
                
                <asp:Button ID="btnLogin" class="btn btn-primary" runat="server" Text="Button" onclick="btnLogin_Click"/>
                

                 </div>
            </div>
        </div>
        </form>
</asp:Content>  
