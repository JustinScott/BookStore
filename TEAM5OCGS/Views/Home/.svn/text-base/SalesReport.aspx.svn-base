<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<TEAM5OCGS.Models.Book>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SalesReport
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="main_column">
        
        <div class="simple_search2">                                
            <form action="/Home/SalesReport" method="post">
            <p>Display details, including percentage profit, of all the books in the inventory by category.<br />
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
                            Percent Profit: %<%: String.Format("{0:F}", item.percentProfit) %><br />
                            Quantity on hand: <%: item.qoh %>
                        </div>                    
                    </li>
                <%  ndx++; 
                    } %>
        </ul>
        
    </div>

    <div id="right_bar">
        <div id="nav2">
            <h1>Navigation</h1>
            <ul>
                <li><%: Html.ActionLink("Customer Chat", "Employee", "Home")%></li>
                <li><%: Html.ActionLink("Order Books", "OrderBooks", "Home")%></li>
                <li><%: Html.ActionLink("Sales Reports", "SalesReports", "Home")%></li>                        
                <li><%: Html.ActionLink("Commission", "Commission", "Home")%></li>
            </ul>
        </div>
        
        <div id="ad2">Advertisment</div>
    </div>


</asp:Content>
