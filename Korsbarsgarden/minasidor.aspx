<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="minasidor.aspx.cs" Inherits="Korsbarsgarden.minasidor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <form runat="server">
    <div class="container">
      <div class="row">
            <br />

        <div id="regMedlemstavlingarFold" class="form-control" onclick="toggleSection('medlemstavlingar')"><p>Mina tävlingar</p></div>
        <div id="medlemstavlingar">
        <p>sadasd</p>  
        </div>
       <div id="medlemsregistreringFold" class="form-control" onclick="toggleSection('medlemsregistrering')"><p>Mina medlemsuppgifter</p></div>
        <div id="medlemsregistrering">
            <div id="medlemsuppgifter">
                <div class="col-md-6">
                 <h2 style="text-align:center">Medlemsinfo</h2>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>MedlemsID</label>
                        <asp:TextBox ID="txtbox_minasidor_id" CssClass="form-control" required="required" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>                   
                <div class="controls">
                <label>Namn</label>
                <asp:TextBox ID="txtbox_minasidor_fornamn" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="controls">
                <label>Efternamn</label>
                <asp:TextBox ID="txtbox_minasidor_efternamn" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="controls">
                <label>Personnummer</label>
                <asp:TextBox ID="txtbox_minasidor_personnr" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="controls">
                <label>Telefonnummer</label>
                <asp:TextBox ID="txtbox_minasidor_telefonnr" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="controls">
                <label>Adress</label>
                <asp:TextBox ID="txtbox_minasidor_adress" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="controls">
                <label>Postnummer</label>
                <asp:TextBox ID="txtbox_minasidor_postnr" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="controls">
                <label>Postort</label>
                <asp:TextBox ID="txtbox_minasidor_postort" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                </div>  
                <div class="controls">
                <label>Epost(Användarnamn)</label>
                <asp:TextBox ID="txtbox_minasidor_epost" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                </div> 
                <div class="controls">
                <label>Lösenord</label>
                <asp:TextBox ID="txtbox_minasidor_losenord" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                </div>                                                                                                                                                                                         
            </div>
          </div>
          </div>
</div>

        <asp:HiddenField ID="hfmedlemsgolfrundorFolded" runat="server" />
        <asp:HiddenField ID="hfmedlemstavlingarFolded" runat="server" />
        <asp:HiddenField ID="hfmedlemsregistreringFolded" runat="server" />  

        <script>
        function toggleSection(section) {
            if ($("#ContentPlaceHolder1_hf" + section + "Folded").val() == "true") {
                $("#" + section).show();
                $("#ContentPlaceHolder1_hf" + section + "Folded").val("false");
            }
            else {
                $("#" + section).hide();
                $("#ContentPlaceHolder1_hf" + section + "Folded").val("true");
            }
        }

        function isPostBack() {
            return document.referrer.indexOf(document.location.href) > -1;
        }

        if (isPostBack()) {
            if ($("#ContentPlaceHolder1_hfmedlemsgolfrundorFolded").val() == "true") {
                $("#medlemsgolfrundor").show();
            }
            else {
                $("#medlemsgolfrundor").show();
            }

            if ($("#ContentPlaceHolder1_hfmedlemstavlingarFolded").val() == "true") {
                $("#medlemstavlingar").hide();
            }
            else {
                $("#medlemstavlingar").show();
            }
            if ($("#ContentPlaceHolder1_hfsponsorsFolded").val() == "true") {
                $("#medlemsregistrering").hide();
            }
            else {
                $("#medlemsregistrering").show();
            }
        }
        else {
            toggleSection("medlemsgolfrundor");
            toggleSection("medlemstavlingar");
            toggleSection("medlemsregistrering");
        }
            </script>   
        </div>

   </form>
</asp:Content>
