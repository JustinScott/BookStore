<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    
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
        <p><span style="color: #000066; font-family: Arial; font-size: large">TEAM5OCGS - 
            The Internet&#39;s Newest Bookstore. </span>
            <br style="color: #000066; font-family: Arial" />
            <br style="color: #000066; font-family: Arial" />
            <span style="color: #000066; font-family: Arial">Founded at the Univesity of 
            Houston in the Spring of 2011.</span><br 
                style="color: #000066; font-family: Arial" />
            <br style="color: #000066; font-family: Arial" />
            <span style="color: #000066; font-family: Arial">The TEAM5OCGS developers, 
            marketing department, and designers all graduated from the University of Houston 
            and wield degree in Computer Science.</span><br 
                style="color: #000066; font-family: Arial" />
            <br style="color: #000066; font-family: Arial" />
            <span style="color: #000066; font-family: Arial">We are dedicated to provide 
            quality books and merchandise at great prices.</span><br 
                style="color: #000066; font-family: Arial" />
            <br style="color: #000066; font-family: Arial" />
            <span style="color: #000066; font-family: Arial">Our goal is to deliver the best 
            customer experience.</span></p>
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
                    </li>
                </ol>
            </fieldset>
        </div>

        <div id="ad2">Advertisement</div>

    </div>

    <br class="clear" /><br />

             
    
</asp:Content>
