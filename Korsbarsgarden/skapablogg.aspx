<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="skapablogg.aspx.cs" Inherits="Korsbarsgarden.skapablogg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="container">

            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <h1 style="text-align: center">Ny bloggpost</h1>
                        <h3>Rubrik:</h3>
                        <asp:TextBox ID="txtBox_rubrik" CssClass="form-control" runat="server"></asp:TextBox>

                        <br />
                        <h3>Spara bild:</h3>
                        <asp:FileUpload ID="fileupload_blogg" runat="server" />

                        <h3>Spara fil:</h3>
                        <asp:FileUpload ID="fileupload_fil" runat="server" />

                        <h3>Text:</h3>
                        <asp:TextBox ID="txtBox_text" CssClass="form-control" runat="server" Rows="15" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <asp:Button ID="btn_skapainlägg" CssClass="btn btn-primary" runat="server" Text="Skapa Inlägg" OnClick="btn_skapainlägg_Click" />
                        <asp:Panel ID="PanelResponse_skapakonto" runat="server" CssClass="alert PanelResponse">
                            <asp:Label ID="LabelResponse_skapakonto" runat="server" Text=""></asp:Label>
                        </asp:Panel>                        
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
