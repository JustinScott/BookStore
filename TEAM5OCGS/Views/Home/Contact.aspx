<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Contact
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Button1_onclick() {

        }

// ]]>
    </script>
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
        <p>
            <br />
            <table style="width: 55%; height: 333px; margin-top: 0px; margin-right: 118px;">
                <tr>
                    <td colspan="2" style="font-size: large; text-align: center;">
                        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        By Email</strong></td>
                </tr>
                <tr>
                    <td style="width: 114px; height: 35px;">
                        Full Name:</td>
                    <td style="height: 35px; width: 3px;">
                        <input id="Text4" style="width: 292px; height: 23px" type="text" /></td>
                </tr>
                <tr>
                    <td style="width: 114px">
                        Email Address:</td>
                    <td style="width: 3px">
                        <input id="Text3" style="width: 292px; height: 26px" type="text" /></td>
                </tr>
                <tr>
                    <td style="width: 114px">
                        Message:</td>
                    <td style="width: 3px">
                        <input id="Text1" style="width: 291px; height: 89px" type="text" /></td>
                </tr>
                <tr>
                    <td style="width: 114px">
                        &nbsp;</td>
                    <td style="width: 3px">
                        <input id="Button1" style="width: 128px; margin-left: 75px" type="button" 
                            value="Send Mail" onclick="return Button1_onclick()" /></td>
                </tr>
                <tr>
                    <td style="text-align: center;" colspan="2">
                        &nbsp;&nbsp;&nbsp; </td>
                </tr>
                <tr>
                    <td style="font-size: large; text-align: center;" colspan="2">
                        <strong>&nbsp;&nbsp;&nbsp;&nbsp;
                        By Phone</strong></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <span class="Apple-style-span" 
                            
                            style="border-collapse: separate; color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px; -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; "><span class="Apple-style-span" 
                            
                            style="color: rgb(102, 102, 102); font-family: Verdana, Arial, Helvetica, sans-serif; ">
                        <span style="font-size: x-small">Call our Customer Service Center at<span class="Apple-converted-space">&nbsp;</span><span 
                                class="bn-only" style="display: inline; ">1-800-ASK-TEAM<br />
&nbsp;(1-800-175-8326)</span></span></span></span><span class="Apple-style-span" 
                            style="border-collapse: separate; color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px; -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; font-size: medium; "><span class="Apple-style-span" 
                            style="color: rgb(102, 102, 102); font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; "><span 
                            style="font-size: small">.</span></span></span></td>
                </tr>
            </table>
            <br />
        </p>
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
    <br />
    <br />
    <br />
    <br />
    <br />

    <br />
    <br class="clear" /><br />  

</asp:Content>
