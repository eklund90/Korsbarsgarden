<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="skapablogg.aspx.cs" Inherits="Korsbarsgarden.skapablogg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="container">
           
            <%--Sidrubrik--%>
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <h1 style="text-align:center">Ny bloggpost</h1> 
                </div>
                <div class="col-md-3"></div>
            <div class="row"> 
            <%--Bloggrubrik--%>
                <br />
                <hr />

           

            
            <div class="panel panel-default">               
            <div class="panel-body">       
                    <h3>Rubrik:</h3>
                    <asp:TextBox ID="txtBox_rubrik" CssClass="form-control" runat="server"></asp:TextBox>           
            <%--Spara bild--%>
<br />
                    <h3>Spara bild:</h3>
                    <asp:FileUpload ID="fileupload_blogg" runat="server" />

                    <h3>Spara fil:</h3>
                    <asp:FileUpload ID="fileupload_fil" runat="server" />

 

       

            
            <%--Blogginlägg--%>
             
                    <h3>Text:</h3>               
                    <asp:TextBox ID="txtBox_text" CssClass="form-control" runat="server" Rows="15" TextMode="MultiLine"></asp:TextBox>
                        <br />
                    <asp:Button ID="btn_skapainlägg" CssClass="btn btn-primary" runat="server" Text="Skapa Inlägg" OnClick="btn_skapainlägg_Click" />
                    <asp:Panel ID="PanelResponse_skapakonto" runat="server" CssClass="alert PanelResponse"> </asp:Panel>
                    <asp:Label ID="LabelResponse_skapakonto" runat="server" Text=""></asp:Label>

                        </div>       
                    </div>            
                </div>
            </div>
            <%--Sparainlägg--%>
            

    </form>
</asp:Content>
