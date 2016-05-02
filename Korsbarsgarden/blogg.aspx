<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="blogg.aspx.cs" Inherits="Korsbarsgarden.blogg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- Page Content -->
<form runat="server">
    <div class="container">

<%--     <asp:Repeater ID="RepeaterNews" runat="server">
               <ItemTemplate>
                   <div class="row">
                       <div class="col-md">

                       </div>
                       <h2><%# Eval("rubrik") %></h2>
                       <p class="newsDate"><%# Eval("datum").ToString().Split(' ')[0] %></p>
                       <p class="newsText"><%# Eval("text") %></p>
                       <br />
                       <hr />
                   </div>
               </ItemTemplate>
           </asp:Repeater>
       </div>
  --%>

        <!-- /.row -->

        <!-- Blog Post Row -->
      <asp:Repeater ID="RepeaterNews" runat="server">
        <ItemTemplate>
        <div class="row">      
            <div class="col-md-4">
                <%--<p"><%# Eval("text") %></p>--%>
                    <img class="img-responsive img-hover" src='<%#Eval("bild")%>' alt="">
                </a>
            </div>
      
            <div class="col-md-8">
                <h3 class="hfont">
                    <p><%# Eval("datum").ToString().Split(' ')[0] %></p>
                    <a id="blogg_rubrik<%# ((RepeaterItem)Container).ItemIndex + 1%>" href="blog-post.html"><%# Eval("rubrik") %></a>
                </h3>

                <p><%# Eval("text") %>...</p>
                <asp:Button ID="btn_readmore" runat="server" CssClass="btn btn-primary" Text="Read More" OnCommand="btn_readmore_Command" CommandArgument='<%#Eval("id")%>'/>
                <%--<a class="btn btn-primary" href="bloggpost.aspx?field1=<%Eval("rubrik")%>>Read More <i class="fa fa-angle-right"></i></a>--%>
            <hr />

            </div>
            
            </div>
            </ItemTemplate>        
        </asp:Repeater>
        <!-- /.row -->

        

      <%--  <!-- Blog Post Row -->
        <div class="row">
            <div class="col-md-1 text-center">
                <p><i class="fa fa-film fa-4x"></i>
                </p>
                <p>June 17, 2014</p>
            </div>
            <div class="col-md-5">
                <a href="blog-post.html">
                    <img class="img-responsive img-hover" src="http://placehold.it/600x300" alt="">
                </a>
            </div>
            <div class="col-md-6">
                <h3><a href="blog-post.html">Blog Post Title</a>
                </h3>
                <p>by <a href="#">Start Bootstrap</a>
                </p>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>
                <a class="btn btn-primary" href="blog-post.html">Read More <i class="fa fa-angle-right"></i></a>
            </div>
        </div>--%>
        <!-- /.row -->



        <!-- Blog Post Row -->
<%--        <div class="row">
            <div class="col-md-1 text-center">
                <p><i class="fa fa-file-text fa-4x"></i>
                </p>
                <p>June 17, 2014</p>
            </div>
            <div class="col-md-5">
                <a href="blog-post.html">
                    <img class="img-responsive img-hover" src="http://placehold.it/600x300" alt="">
                </a>
            </div>
            <div class="col-md-6">
                <h3><a href="blog-post.html">Blog Post Title</a>
                </h3>
                <p>by <a href="#">Start Bootstrap</a>
                </p>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>
                <a class="btn btn-primary" href="blog-post.html">Read More <i class="fa fa-angle-right"></i></a>
            </div>
        </div>--%>
        <!-- /.row -->

        
<%--        <!-- Pager -->
        <div class="row">
            <ul class="pager">
                <li class="previous"><a href="#">&larr; Older</a>
                </li>
                <li class="next"><a href="#">Newer &rarr;</a>
                </li>
            </ul>
        </div>
        <!-- /.row -->

        <hr />--%>

    </div>
</form>
    <!-- /.container -->
</asp:Content>
