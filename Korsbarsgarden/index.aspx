<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Korsbarsgarden.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
            <header id="myCarousel" class="carousel slide">
                <%--<div id="carousel-example-generic" class="carousel slide" data-ride="carousel">--%>
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                        <li data-target="#myCarousel" data-slide-to="3"></li>
                    </ol>

                    <!-- Wrapper for sdflides -->
                    <div class="carousel-inner">
                        <div class="item active">
                            <%--<img class="img-responsive" src="images/hus.png" alt="" style="margin:0 auto" />--%>
                            <div class="fill" style="background-image:url('images/test3.jpg')"></div>
                        </div>
                        <div class="item">
                            <div class="fill" style="background-image:url('images/test4.jpg')"></div>
                        </div>
                        <div class="item">
                            <div class="fill" style="background-image:url('images/test5.jpg')"></div>
                        </div>       
                        <div class="item">
                            <div class="fill" style="background-image:url('images/test6.jpg')"></div>
                        </div>                     
                    </div>

                    <!-- Controls -->
                    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                    </a>
                    <a class="right carousel-control" href="#myCarousel" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                    </a>
                <%--</div>--%>
                </header>
                
                <div class="container" style="background-color: #ededed">
                <div class="row">
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <%--<div class="panel-heading">
                                <h3 class="panel-title">Välkommen till föräldrakoperativet Körsbärsgården!</h3>
                            </div>--%>
                            <div class="panel-body">
                                <h3 class="hfont">Personalkooperativet Körsbärsgården</h3>
                                <hr class="hr2" />
                            <p class="pfont"> Vi är en liten Montessori-inspirerad verksamhet med ett stort hjärta! Körsbärsgårdens rosa villa har plats för runt 22 barn och ligger i Domsten, i norra Helsingborg. 
                                Den stora, lummiga trädgården lockar till lek och vi har strand och skog som närmsta grannar. Domstens by inbjuder till promenader till hamnen och omgivande lekplatser. 
                                Småskaligheten gör att alla barn, föräldrar och våra pedagoger får en nära relation och ger alla en god inblick i verksamheten.
                                Som grund för vår verksamhet har vi skollagen, läroplanen och Montessoripedagogiken.</p>
                        </div>
                        </div>                        
                    </div>

                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <%--<div class="panel-heading">
                                <h3 class="panel-title">Pedagogik</h3>
                            </div>--%>
                            <div class="panel-body">
                                <h3 class="hfont">Pedagogik</h3>
                                <hr class="hr2" />
                            <p class="pfont"> Vi strävar efter att lägga grunden för ett livslångt lärande genom att erbjuda varje barn en trygg och lärorik pedagogisk miljö. 
                                Lärande och lek sammanflätas i en förberedd miljö med empatiska, kompetenta pedagoger som tillsammans med barnen upplever var dag. Hela dagen är lika viktig. 
                                Alla barn blir sedda, hörda och får tid att uttrycka sig och träna sina färdigheter. 
                                Vi tror att varje barn har en inneboende kraft och vilja att utvecklas, utmanas och förändras. 
                                Genom vår förberedda miljö, vårt förhållningssätt, verksamhetens innehåll och vår Montessoripedagogik ger vi varje barn bästa möjliga förutsättningar.</p>
                        </div>
                        </div>
                    </div>
                </div>
                <hr />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-10">
                                    <h3 class="hfont" style="text-align:center">Avdelningar</h3>
                                
                                    <p>På Körsbärsgården har vi två avdelningar, Snäckan och Krabban. 
                                       Lämning sker ute på altanen, där också de små barnen sover efter 
                                       lunchen.</p>
                                </div>
                     
                        <div class="col-md-1"></div>
                    </div>
                    
                    <div class="row">
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                     <img class="img-responsive" src="images/test.jpg" />                     
                            </div>
                            <div class="panel-body">
                            <h3 class="hfont">Snäckan</h3>                                
                            <p class="pfont"> Här finns 8-10 barn, i åldern 1 till 3 år och 2-3 pedagoger. På Snäckan läggs fokus på trygghet, rutiner och att få kunna själv. Miljön är anpassad efter barnen. Låga bord, små stolar och 
                                materiel i lagom storlek och mängd. Vi utgår från barnens behov och intressen och förbereder miljön och aktiviteterna efter det. </p>
                            <p class="pfont">Vi vill skapa en utmanande och tillåtande miljö.
                                Vi har utedagar med uppdrag och utflykter till stranden, skogen eller någon lekplats i närmiljön. Skapande verksamhet, sånger/sagor och rörelse/rytmik är återkommande aktiviteter. Vi arbetar även temainriktat, 
                                med olika områden såsom vatten och “att vara en bra kompis”. Vi vill fånga dagen och uppleva världen med alla våra sinnen.            </p><br />
                        </div>
                        </div>                        
                    </div>

                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <img class="img-responsive" src="images/test2.jpg" /> 
                            </div>
                            <div class="panel-body">
                            <h3 class="hfont">Krabban</h3>
                            <p class="pfont">På Krabban finns 12-14 barn mellan 3 och 6 år och 2 pedagoger. Några dagar i veckan går barnen in vid kl 9.15 för att ha eget arbete. Under arbetsstunden kan barnen välja vad de vill arbeta med. Detta kan bestå av olika praktiska eller sensoriska övningar med Montessorimaterielen för att lära om språk, 
                               matte eller historia mm, men också av skapande verksamhet såsom målning eller så kan de till exempel välja att läsa en bok eller lyssna på cd-saga.  
                              </p>
                            <p class="pfont"> En dag i veckan har vi utedag då vi har spännande uppdrag i naturen. Sångstund tillsammans med barnen på Snäckan är också en stående aktivitet. Vi arbetar temabaserat med utgångspunkt i 
                               barnens frågeställningar och intressen. De barn som går sista året har regelbundet specifika, skolförberedande aktiviteter. </p>
                        </div>
                        </div>
                    </div>
                </div>

</div>
    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>
    $('.carousel').carousel({
        interval: 5000 //changes the speed
    })
    </script>
</asp:Content>
