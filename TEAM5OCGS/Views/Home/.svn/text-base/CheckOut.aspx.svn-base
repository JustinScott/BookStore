<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<TEAM5OCGS.Models.ShoppingCart>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CheckOut
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        
    <div id="main_column">
        <ul id="cart_preview">            
            <%  int ndx = 0;
                decimal totalprice = 0;
                foreach (var item in Model) {
                    totalprice += Convert.ToDecimal(item.book.retailPrice); %>
                    <li id="cart_item<%= (ndx + 1) % 2  %>">
                        <div class="cart_item">
                            <%: item.book.title %><br />
                            ISBN: <%: item.book.isbn %><br />
                            Author: <%: item.book.l_name %>, <%: item.book.f_name %><br />
                            Price: $<%: String.Format("{0:F}", item.book.retailPrice) %><br />
                            Quantity: <input class="quantity" data-isbn="<%: item.book.isbn %>" name="quantity" value="<%: item.quantity %>" size="1"/>
                            <input class="item_cost" type="hidden" value="<%: String.Format("{0:F}", item.book.retailPrice) %>" />                        
                            <input class="quant_upd" data-isbn="<%: item.book.isbn %>" value="Update Quantity" type="button" />
                        </div>
                    </li>

                <%  ndx++; 
                } %>
        </ul>
        <p id="total">Total price: <%: totalprice %></p>
        <form action="/Home/DeleteCart" method="get"> 
            <input id="delete_cart" type="submit" value="Delete Cart" />
        </form>
        <form action="/Home/CompleteCheckOut" method="get">
            <input id="finish_checkout" type="submit" value="Continue Checkout" />              
        </form>
    </div>
    
    <div id="right_bar">
        
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

