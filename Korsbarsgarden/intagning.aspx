<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="intagning.aspx.cs" Inherits="Korsbarsgarden.intagning" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="container" style="background-color: #f2f1f1">
        <div class="row">
        <div class="col-md-2">
        </div>
            <div class="col-md-8">
                <h1 style="text-align:center">Intagning            
                </h1>
    <hr />

     <p>Varje termin tar vi in nya barn. Om du är intresserad av att ditt barn ska få en plats så är första steget att kontakta oss för att boka in ett besök på Körsbärsgården. 
Då får personalen tillfälle att berätta mer om vår förskola och du som förälder får en inblick i hur förskolan ser ut och fungerar. 
Sedan sätter du upp ditt barn i kö hos Helsingborgs kommun eftersom att Körsbärsgården är knuten till den kommunala barnomsorgskön. 
Barnet måste alltså stå i den kommunala kön för att kunna erbjudas en plats på Körsbärsgården. 
Äldst barn hamnar längst fram i kön. Då vi är en liten enhet måste vi även ta hänsyn till köns- och åldersfördelning när vi tar in barn.</p>
         <br />
<div style="text-align:center">
         <p>
För mer information samt bokning av besök, klicka nedan</p>
                <form runat="server">
<asp:Button href="kontakt.aspx" ID="btnKontakt" runat="server" class="btn btn-primary" Text="Kontakta oss" Width="228px" /> </form>
</div>
</div>  
                     <div class="col-md-2">
                     </div>
        
    </div>    
             <div class="row">
                 <div class="col-md-3">
        </div>
       
            <div class="col-md-3 img-portfolio">
                <a href="portfolio-item.html">
                    <img class="img-responsive img-hover img-thumbnail" src="http://www.korsbarsgarden.org/Korsbarsgarden.org/Kooperativ_files/DSC_0683%20-%20Version%202.jpg" alt=""/>
                </a>
            </div>
            <div class="col-md-3 img-portfolio">
                <a href="portfolio-item.html">
                    <img class="img-responsive img-hover img-thumbnail" src="http://www.korsbarsgarden.org/Korsbarsgarden.org/Kooperativ_files/shapeimage_3.png" alt=""/>
                </a>
            </div>
                                 <div class="col-md-3">
        </div>
   </div>
    </div>

</asp:Content>

    

