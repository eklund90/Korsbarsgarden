<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="skapakonto.aspx.cs" Inherits="Korsbarsgarden.skapakonto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server">    
    <div class="container">
        <div class="row">
            
          <div class="panel panel-default">               
            <div class="panel-body">   
            <div class="col-md-6">
                 <h1 class="rfont" style="text-align:center">Medlemsinfo</h1>
                <hr />
                <div class="control-group form-group">
                    <div class="controls">
                        <label>MedlemsID</label>
                        <asp:TextBox ID="txtBox_skapakonto_id" CssClass="form-control" required="required" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>    
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Förnamn</label>
                        <asp:TextBox ID="txtBox_skapakonto_fornamn" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Efternamn</label>
                        <asp:TextBox ID="txtBox_skapakonto_efternamn" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Personnummer</label>
                        <asp:TextBox ID="txtBox_skapakonto_personnr" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Telefonnummer</label>
                        <asp:TextBox ID="txtBox_skapakonto_telefonnr" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Adress</label>
                        <asp:TextBox ID="txtBox_skapakonto_adress" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Postnummer</label>
                        <asp:TextBox ID="txtBox_skapakonto_postnr" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Postort</label>
                        <asp:TextBox ID="txtBox_skapakonto_postort" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Epost</label>
                        <asp:TextBox ID="txtBox_skapakonto_epost" CssClass="form-control" required="required" runat="server"></asp:TextBox>
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
                <asp:Button ID="btn_skapakonto" class="btn btn-primary" runat="server" Text="Skapa konto" Onclick="btn_skapakonto_Click"/>
                <asp:Button ID="btn_uppdaterakonto" class="btn btn-warning" runat="server" Text="Uppdatera Konto" onclick="btn_uppdaterakonto_Click"/>

                <asp:Button ID="btn_tabortkonto" class="btn btn-danger" runat="server" Text="Ta bort konto" OnClick="btn_tabortkonto_Click" />
                

                <asp:Panel ID="PanelResponse_skapakonto" runat="server" CssClass="alert PanelResponse">
                    <asp:Label ID="LabelResponse_skapakonto" runat="server" Text="asd"></asp:Label>
                </asp:Panel>
            </div>
            <div class="col-md-6">
                <h1 class="rfont" style="text-align:center">Medlemslista</h1>
                <hr />
                <asp:ListBox ID="medlemlist" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="medlemlist_SelectedIndexChanged"></asp:ListBox>
            </div>

        </div>
    </div>
    </div>
 </div>
</form>
</asp:Content>
