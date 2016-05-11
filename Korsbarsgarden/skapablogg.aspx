<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="skapablogg.aspx.cs" Inherits="Korsbarsgarden.skapablogg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="container">
            <%--Sidrubrik--%>
            <div class="row">
                
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <h1 style="text-align:center">Ny bloggpost</h1> 
                </div>
                <div class="col-md-3"></div>
            </div>
            <%--Bloggrubrik--%>

            <div class="row">
                 <div class="col-md-3"></div>

                <div class="col-md-6">     
            <div class="panel panel-default">               
            <div class="panel-body">       
                    <asp:Label ID="lbl_rubrik" CssClass="lblhead" runat="server" Text="Rubrik"></asp:Label>
                    <asp:TextBox ID="txtBox_rubrik" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
          </div>
                <div class="col-md-3"></div>
                </div>
            <%--Spara bild--%>
            <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
            <div class="panel panel-default">               
            <div class="panel-body">  
                    <asp:Label ID="lbl_bild" runat="server" Text="Spara bild"></asp:Label>
                    <asp:FileUpload ID="fileupload_blogg" runat="server" />

                    <asp:Label ID="lbl_fil" runat="server" Text="Spara fil"></asp:Label>
                    <asp:FileUpload ID="fileupload_fil" runat="server" />
                        </div>
                    </div>
               </div>
                <div class="col-md-3"></div>
            </div>

            
            <%--Blogginlägg--%>
             <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                <div class="panel panel-default">               
                    <div class="panel-body">  
                    <asp:Label ID="lbl_text" CssClass="lblhead" runat="server" Text="Inlägg"></asp:Label>                    
                    <asp:TextBox ID="txtBox_text" CssClass="form-control" runat="server" Rows="15" TextMode="MultiLine"></asp:TextBox>
                </div>
                    </div>
                    </div>
                <div class="col-md-3"></div>
            </div>
            <%--Sparainlägg--%>
            <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <asp:Button ID="btn_skapainlägg" CssClass="btn btn-primary" runat="server" Text="Skapa Inlägg" OnClick="btn_skapainlägg_Click" />
                    <asp:Panel ID="PanelResponse_skapakonto" runat="server" CssClass="alert PanelResponse">
                        <asp:Label ID="LabelResponse_skapakonto" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                </div>
                <div class="col-md-3"></div>
                </div>
            </div>

    </form>
</asp:Content>
