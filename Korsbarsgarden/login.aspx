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
                            <input type="text" class="form-control" id="name" required data-validation-required-message="Ditt Användarnamn" />
                            <p class="help-block"></p>
                        </div>
                    </div>               
               
                         <div class="control-group form-group">
                        <div class="controls">
                            <label>Lösenord</label>
                            <input type="text" class="form-control" id="phone" required data-validation-required-message="Ditt Lösenord" />
                        </div>
                    </div>  
                
                <asp:Button ID="btnLogin" class="btn btn-primary" runat="server" Text="Button" onclick="btnLogin_Click"/>
                

                 </div>
            </div>
        </div>
        </form>
</asp:Content>  
