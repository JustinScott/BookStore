<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TEAM5OCGS.Models.Customer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Complete CheckOut
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        
    <div id="main_column">        
        <div id="customer_info">
            <fieldset id="billing_address">
                <legend>Billing Address</legend>
                <ol>
                    <li>
                        <label for="l_name">Last Name</label>
                        <input id="l_name" name="l_name" value="<%: Model.l_name %>" type="text" />
                    </li>
                    <li>
                        <label for="f_name">First Name</label>
                        <input id="f_name" name="f_name" value="<%: Model.f_name %>" type="text" />
                    </li>
                    <li>
                        <label for="address">Address</label>
                        <input id="address" name="address" value="<%: Model.address %>" type="text" />
                    </li>
                    <li>
                        <label for="city">City</label>
                        <input id="city" name="city" value="<%: Model.city %>" type="text" />
                    </li>
                    <li>
                        <label for="state">State</label>
                        <input id="state" name="state" value="<%: Model.state %>" type="text" />
                    </li>
                    <li>
                        <label for="zip">Zip</label>
                        <input id="zip" name="zip" value="<%: Model.zip %>" type="text" />
                    </li>                
                </ol>
            </fieldset>        

            <br class="clear" /><input id="ship_cb" type="checkbox" />Use billing address information.<br /><br />

            <form action="/Home/CompleteCheckOut2" method="post">
                <fieldset id="shipping_address">
                    <legend>Shipping Address</legend>
                    <ol>
                        <li>
                            <label for="l_name">Last Name</label>
                            <input id="ship_l_name" name="l_name" value="" type="text" />
                        </li>
                        <li>
                            <label for="f_name">First Name</label>
                            <input id="ship_f_name" name="f_name" value="" type="text" />
                        </li>
                        <li>
                            <label for="address">Address</label>
                            <input id="ship_address" name="address" value="" type="text" />
                        </li>
                        <li>
                            <label for="city">City</label>
                            <input id="ship_city" name="city" value="" type="text" />
                        </li>
                        <li>
                            <label for="state">State</label>
                            <input id="ship_state" name="state" value="" type="text" />
                        </li>
                        <li>
                            <label for="zip">Zip</label>
                            <input id="ship_zip" name="zip" value="" type="text" />
                        </li>                
                    </ol>
                </fieldset> 
                <br />    
                <input type="submit" value="Complete Checkout" />   
            </form>
        </div>          
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

