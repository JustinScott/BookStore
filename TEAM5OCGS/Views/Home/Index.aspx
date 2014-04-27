<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<TEAM5OCGS.Models.Book>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <input id="session_custid" type="hidden" value="<%: Session["custId"] %>" />

    <div id="simple_search">                                
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
        <div id="search_result">
                <h1><%: ViewData["listTitle"] %></h1>
                <ul id="preview">            
                <%  int ndx = 0;
                    foreach (var item in Model) {%>                        
                    <li id="item<%= (ndx + 1) % 4  %>">
                        <h3><a href="#" title="<%: item.title %>"><%: item.title %><img src="<%= Url.Content("~/Images/" + item.filename) %>" alt="" /></a></h3>
                        <p><%: item.description %></p>
                        <span>Author: <%: item.l_name %>, <%: item.f_name %>
                        <br />Price: <%: String.Format("{0:F}", item.retailPrice) %>
                        <br />In stock: <%: item.qoh %></span>
                        <a id="cart1" title="add to shopping cart" data-isbn="<%: item.isbn %>"><img src="<%= Url.Content("~/Images/add2cart.jpg") %>" alt="" /></a>
                    </li>
                <%  ndx++; } %>
                </ul>
        </div>
    </div>
    
    <div id="right_bar">

        <div id="nav2">
            <h1>Categories</h1>
            <ul>
                <% foreach (var item in categories){ %>
                    <li><%: Html.ActionLink(item, "Index", "Home", new { category = item }, null)%></li>                        
                <% } %>
            </ul>
        </div>

        <div id="chat_tool">
            <form action="Home/ChatRequest" method="post">
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
                            <input id="submit1" type="submit" value="Start Chat" />
                        </li>
                    </ol>
                </fieldset>
            </form>
        </div>

        <div id="ad2">Advertisment</div>
    </div>

    <br class="clear" /><br />
</asp:Content>
