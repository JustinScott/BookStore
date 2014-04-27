<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<TEAM5OCGS.Models.Book>>" %>

<div id="simple_search">                                
    <form action="/Home/Search" method="post">
    <p>Enter Author, ISBN, or Title to search for a book.<br />
        <select name="category">
            <option value="ALL">ALL</option>
            <% List<string> categories = (List<string>)ViewData["categories"];
                foreach (var item in categories){ %>
                <option value="<%: item %>"><%: item %></option>
            <% } %>
        </select>
        <input id="term" name="term" type="hidden" value="_" />
        <input id="submit" value="Display books" type="submit" /></p>
    </form>                           
</div>
<br class="clear" /><br />

<div id="emp_search_result">
    <ul id="cart_preview">            
        <%  int ndx = 0;            
            foreach (var item in Model) { %>
                <li id="cart_item<%= (ndx + 1) % 2  %>">
                    <div id="cart_item">
                        <%: item.title %><br />
                        ISBN: <%: item.isbn %><br />
                        Author: <%: item.l_name %>, <%: item.f_name %><br />
                        Retail Price: $<%: String.Format("{0:F}", item.retailPrice) %><br />
                        Wholesale Price: $<%: String.Format("{0:F}", item.wholesalePrice) %><br />
                        Quantity on hand: <%: item.qoh %><br />
                    </div>                    
                </li>

         <%  ndx++; 
             } %>
    </ul>
</div>