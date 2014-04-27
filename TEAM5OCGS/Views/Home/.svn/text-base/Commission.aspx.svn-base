<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TEAM5OCGS.Models.Commission>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Commission
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="main_column">
        <div class="simple_search2">
            <p>Calculate monthly sales commission.</p>
            <form action="/Home/Commission" method="post">
                <input type="hidden" name="empId" value="<%= Session["empId"] %>" />
                <input type="submit" value="Get Report" />
            </form>
        </div>
        <h1><%: ViewData["status"] %></h1>
        <% if(!String.IsNullOrEmpty((string)ViewData["status"])){ %>
            Total: <%: Model.total %>
        <% } %>
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
