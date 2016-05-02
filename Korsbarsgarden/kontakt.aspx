<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="kontakt.aspx.cs" Inherits="Korsbarsgarden.kontakt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server">
<div class="container" style="background-color: #f2f1f1"> 


        <!-- Content Row -->
        <div class="row">
            <!-- Map Column -->
            <div class="col-md-8">
                <!-- Embedded Google Map -->
                <script src='https://maps.googleapis.com/maps/api/js?v=3.exp'></script><div style='overflow:hidden;height:440px;width:700px;'><div id='gmap_canvas' style='height:440px;width:100%'></div><div><small><a href="http://embedgooglemaps.com">									embed google maps							</a></small></div><div><small><a href="http://freedirectorysubmissionsites.com/">free web directories</a></small></div><style>#gmap_canvas img{max-width:none!important;background:none!important}</style></div><script type='text/javascript'>function init_map() { var myOptions = { zoom: 12, center: new google.maps.LatLng(56.11479809999999, 12.614059300000008), mapTypeId: google.maps.MapTypeId.ROADMAP }; map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions); marker = new google.maps.Marker({ map: map, position: new google.maps.LatLng(56.11479809999999, 12.614059300000008) }); infowindow = new google.maps.InfoWindow({ content: '<strong>Här finns vi</strong><br>Bygatan 1, 255 91 Helsingborg<br>' }); google.maps.event.addListener(marker, 'click', function () { infowindow.open(map, marker); }); infowindow.open(map, marker); } google.maps.event.addDomListener(window, 'load', init_map);</script>
               
            </div>
            <!-- Contact Details Column -->
            <div class="col-md-4">
                <h3>Kontaktuppgifter</h3>
                <p>
                    Körsbärsgården<br>Bygatan 1, 255 91 Helsingborg<br>
                </p>
                <p><i class="fa fa-phone"></i> 
                    <abbr title="Telefon">T</abbr>: 042-912 04</p>
                <p><i class="fa fa-envelope-o"></i> 
                    <abbr title="Email">E</abbr>: <a href="korsbarsgarden@telia.com">korsbarsgarden@telia.com</a>
                </p>
                <p><i class="fa fa-clock-o"></i> 
                    <abbr title="Hours">Ö</abbr>: Måndag - Fredag: 07.30-16.30</p>
                <ul class="list-unstyled list-inline list-social-icons">
                    <li>
                        <a href="#"><i class="fa fa-facebook-square fa-2x"></i></a>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-linkedin-square fa-2x"></i></a>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-twitter-square fa-2x"></i></a>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-google-plus-square fa-2x"></i></a>
                    </li>
                </ul>
            </div>
        </div>
        <!-- /.row -->

        <!-- Contact Form -->
        <!-- In order to set the email address and subject line for the contact form go to the bin/contact_me.php file. -->
        <div class="row">
            <div class="col-md-6">
                <h3>Skicka ett meddelande</h3>

                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Namn</label>
                            <asp:TextBox ID="txtBox_name" class="form-control" required="required" runat="server"></asp:TextBox>

                            <p class="help-block"></p>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Telefonnummer</label>
                            <asp:TextBox ID="txtBox_telenr" runat="server" required="required" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Epostadress</label>
                            <asp:TextBox ID="txtBox_epost" runat="server" required="required" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Meddelande</label>
                            <asp:TextBox ID="txtBox_text" CssClass="form-control" required="required" runat="server" Rows="15" TextMode="MultiLine"></asp:TextBox>
                            
                        </div>
                    </div>
                    <div id="success"></div>
                    <!-- For success/fail messages -->
                    <asp:Button ID="btn_skickamed" type="submit"  class="btn btn-primary" runat="server" Onclick="btn_skickamed_Click" Text="Skicka meddelande" />
            </div>
        </div>
       </div>
</form>
</asp:Content>

