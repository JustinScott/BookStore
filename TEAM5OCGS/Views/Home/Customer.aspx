<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TEAM5OCGS.Models.Customer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Customer
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
         
         <h1><%: ViewData["status"] %></h1><br />
           
        <fieldset id="cust_profile">
            <legend>Customer Profile</legend>
            <ul>
                <li>
                    <%= Html.LabelFor(model => model.f_name) %>
                    <%= Html.TextBoxFor(model => model.f_name) %>
                </li>
                <li>
                    <%= Html.LabelFor(model => model.l_name) %>
                    <%= Html.TextBoxFor(model => model.l_name) %>
                </li>
                <li>
                    <%= Html.LabelFor(model => model.address) %>
                    <%= Html.TextBoxFor(model => model.address) %>
                </li>
                <li>
                    <%= Html.LabelFor(model => model.city) %>
                    <%= Html.TextBoxFor(model => model.city) %>
                </li>
                <li>
                    <%= Html.LabelFor(model => model.state) %>
                    <%= Html.TextBoxFor(model => model.state) %>
                </li>
                <li>
                    <%= Html.LabelFor(model => model.zip) %>
                    <%= Html.TextBoxFor(model => model.zip) %>
                </li>
                <li>
                    <%= Html.LabelFor(model => model.region) %>
                    <select name="region" ">
                        <option value="N" <%if(Model.region == "N"){%> selected="selected" <%}%>>N</option>
                        <option value="NE" <%if(Model.region == "NE"){%> selected="selected" <%}%>>NE</option>
                        <option value="E" <%if(Model.region == "E"){%> selected="selected" <%}%>>E</option>
                        <option value="SE" <%if(Model.region == "SE"){%> selected="selected" <%}%>>SE</option>
                        <option value="S" <%if(Model.region == "S"){%> selected="selected" <%}%>>S</option>
                        <option value="SW" <%if(Model.region == "SW"){%> selected="selected" <%}%>>SW</option>
                        <option value="W" <%if(Model.region == "W"){%> selected="selected" <%}%>>W</option>
                        <option value="NW" <%if(Model.region == "NW"){%> selected="selected" <%}%>>NW</option>
                    </select>
                </li>                
                <li>
                    <%= Html.LabelFor(model => model.email) %>
                    <%= Html.TextBoxFor(model => model.email) %>
                </li>
            </ul><br />
            <input id="upd_profile" type="button" value="Update profile" />
        </fieldset>
    </div>

    <div id="right_bar">

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
