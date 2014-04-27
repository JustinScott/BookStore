<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CompleteCheckOut2
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="main_column">        
        <h1>Order complete!</h1><br />
        Thank you <%: ViewData["name"] %> for shopping with us. A receipt of this order has been sent to
        your email address.<br /><br />
        <%: Html.ActionLink("Return to the homepage.", "Index", "Home")%>
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
