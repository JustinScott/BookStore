<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Press
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id='simple_search'>                                
        <form action="/Home/Index" method="post">
        <p>Enter Author, ISBN, or Title to search for a book.<br />
            <select name="category">
                <option value="ALL">ALL</option>
                <% List<string> categories = (List<string>)ViewData["Categories"];
                    foreach (var item in categories){ %>
                    <option value="<%: item %>"><%: item %></option>
                <% } %>
            </select>
            <input id="term" name="term" type="text" />
            <input id="submit" value="Search" type="submit" /></p>
        </form>                           
    </div>

    <div id="shopping_cart">
        <span id="cart_count"><%: Session["cart_count"] %> items in</span>
        <div id="cart_picture"></div>
        <a href="/Home/CheckOut" id="checkout_picture" title="checkout" ><img src="<%= Url.Content("~/Images/check_out_now.gif") %>" alt="" /></a>        
    </div>
    
    <br class="clear" /><br /><br />
        
    <div id="main_column">
      <%--  <p style="color: #000099"><strong><span style="color: #000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TEAM5OCGS Latest News:</span></strong></p>--%>
      <p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Team5OCGS latest News</strong></p>
        <ul>
            <li>&nbsp; TEAM5OCGS is working on introducing electronic books (ebooks).&nbsp;
                <span style="color: #0000CC"><em>04/24/2011</em></span></li>
        </ul>
        </br>
        <p style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <strong>Our First Client Ever!</strong></p>
        <p style="text-align: left">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <img src="http://www2.cs.uh.edu/~vhilford/index_files/image3351.jpg" /></p>
        <p style="text-align: left">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Dr. Victoria Hilfordd</p>
        <p>&nbsp;</p>
        <p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TEAM5OCGS developing building 
            </strong> </p>
        <p>
            &nbsp;&nbsp;&nbsp;
            <img src="http://www.uh.edu/maps/photos/pgh_01.jpg" 
                style="height: 237px; width: 360px" /></p>
        <p>&nbsp;</p>
    </div>
    
    <div id="right_bar">

        <div id="nav">
            <h1>Helpful Information</h1>
            <ul>
                <li><%: Html.ActionLink("About", "About", "Home")%></li>
                <li><%: Html.ActionLink("Contact", "Contact", "Home")%></li>
                <li><%: Html.ActionLink("Press", "Press", "Home")%></li>
                <li><%: Html.ActionLink("Testimonials", "Testimonials", "Home")%></li>
            </ul>
        </div>

        <div id="chat_tool">
            <fieldset>
                <legend>Live Chat</legend>                
                <ol>
                    <li>
                        <label for="name">Name</label>
                        <input id="name" name="name" type="text" />
                    </li>
                    <li>                        
                        <textarea id="issue" name="issue" rows="4" cols="18">Describe the problem you are having.</textarea>
                    </li>                    
                </ol> 
            </fieldset>
            <fieldset class="submit">
                <ol>
                    <li>
                        <label for="submit"> </label>
                        <input id="submit1" name="submit" type="submit" />
                    </li>dd
                </ol>
            </fieldset>
        </div>

        <div id="ad2">Advertisement</div>

    </div>

    <br class="clear" />
    <br />
    <br />
    <br />          

</asp:Content>
