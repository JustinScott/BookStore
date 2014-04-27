<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Testimonials
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

    <br class="clear" /><br />
    <br />
    &nbsp;<span style="font-size: x-large">&nbsp;<br />
    </span>
    <div id="main_column">
&nbsp;<form id="test" name="test" action="/Home/Testimonials" method="post">

<h1><%: ViewData["thankyou"] %></h1>
<br />

            <fieldset>
                <legend style="font-size: x-large">Testimonials</legend>               
            <fieldset style="margin-bottom: 0px">
&nbsp;<ol>
                    <li>
                        <label for="name0">Name</label>
                        <input id="name0" name="name0" type="text" 
                            style="margin-left: 8px; width: 210px;" />
                    </li>
                    <li>                        
                        <textarea id="issue0" name="issue0" rows="4" style="width: 253px">Enter testimonial here.</textarea>
                    </li>                    
                </ol> 
            </fieldset>
            <fieldset class="submit">
                <ol>
                    <li>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        &nbsp;
                        <input id="submit2" name="submit0" type="submit" /></li>
                </ol>
            </fieldset><br />
            <br />
            See what other customers have to say about our website.<br />
            <br />
            <fieldset class="submit">
                <br>
&nbsp;&nbsp;&nbsp;&nbsp; Excellent shipping service. The fastest I seen!<br />
                </br>
&nbsp;&nbsp;&nbsp;&nbsp; <span style="color: #003399">Michael Nelson</span><br>
&nbsp;&nbsp;&nbsp;&nbsp; Long Beach, California</br>
            </fieldset><br />
            <fieldset class="submit">
                <br>
&nbsp;&nbsp;&nbsp;&nbsp;Found the book I was looking for at the lowest price.<br />
                </br>
&nbsp;&nbsp;&nbsp;&nbsp; <span style="color: #000099">Jennifer Palmer</span><br>
&nbsp;&nbsp;&nbsp;&nbsp; San Antonio, Texas</br>
            </fieldset><br />
            <fieldset class="submit">
                <br>
                &nbsp;&nbsp;&nbsp;&nbsp; Very fast and easy website experience.
                <br />
                </br>
&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: #000099"> Peter Gordon</span><br>
&nbsp;&nbsp;&nbsp;&nbsp; Denver, Colorado</br>
            </fieldset>
        <p>&nbsp;</p>
        </form>
    </div>
    
    <div id="right_bar">

        <div id="nav">
            <h1>&nbsp;</h1>
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
