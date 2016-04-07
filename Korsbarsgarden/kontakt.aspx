<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="kontakt.aspx.cs" Inherits="Korsbarsgarden.kontakt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
        <div class="container">

        <!-- Page Heading/Breadcrumbs -->
<%--        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Kontakta oss
                </h1>
                <ol class="breadcrumb">
                    <li><a href="index.aspx">Home</a>
                    </li>
                    <li class="active">Kontakt</li>
                </ol>
            </div>
        </div>--%>

        <!-- TestÄNDRING -->
            <p>HEJ JIMMY</p>

        <!-- Content Row -->
        <div class="row">
            <!-- Map Column -->
            <div class="col-md-8">
                <!-- Embedded Google Map -->
                <script src='https://maps.googleapis.com/maps/api/js?v=3.exp'></script><div style='overflow:hidden;height:440px;width:700px;'><div id='gmap_canvas' style='height:440px;width:100%'></div><div><small><a href="http://embedgooglemaps.com">									embed google maps							</a></small></div><div><small><a href="http://freedirectorysubmissionsites.com/">free web directories</a></small></div><style>#gmap_canvas img{max-width:none!important;background:none!important}</style></div><script type='text/javascript'>function init_map() { var myOptions = { zoom: 12, center: new google.maps.LatLng(56.11479809999999, 12.614059300000008), mapTypeId: google.maps.MapTypeId.ROADMAP }; map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions); marker = new google.maps.Marker({ map: map, position: new google.maps.LatLng(56.11479809999999, 12.614059300000008) }); infowindow = new google.maps.InfoWindow({ content: '<strong>Här finns vi</strong><br>Bygatan 1, 255 91 Helsingborg<br>' }); google.maps.event.addListener(marker, 'click', function () { infowindow.open(map, marker); }); infowindow.open(map, marker); } google.maps.event.addDomListener(window, 'load', init_map);</script>
                <%--<iframe width="100%" height="400px" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="http://maps.google.com/maps?hl=en&amp;ie=UTF8&amp;ll=37.0625,-95.677068&amp;spn=56.506174,79.013672&amp;t=m&amp;z=4&amp;output=embed"></iframe>--%>
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
            <div class="col-md-8">
                <h3>Skicka ett meddelande</h3>
                <form name="sentMessage" id="contactForm" novalidate>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Namn</label>
                            <input type="text" class="form-control" id="name" required data-validation-required-message="Ditt namn" />
                            <p class="help-block"></p>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Telefonnummer</label>
                            <input type="tel" class="form-control" id="phone" required data-validation-required-message="Ditt telfonnummer" />
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Epostadress</label>
                            <input type="email" class="form-control" id="email" required data-validation-required-message="Din epostadress" />
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <label>Meddelande</label>
                            <textarea rows="10" cols="100" class="form-control" id="message" required data-validation-required-message="Ditt meddelande" maxlength="999" style="resize:none"></textarea>
                        </div>
                    </div>
                    <div id="success"></div>
                    <!-- For success/fail messages -->
                    <button type="submit" class="btn btn-primary">Send Message</button>
                
            </div>
        </div>
       </div>
    <br />
    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
</asp:Content>

