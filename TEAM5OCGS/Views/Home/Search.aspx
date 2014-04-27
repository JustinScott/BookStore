<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<TEAM5OCGS.Models.Book>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Search
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="main_column">
        
        <div id="search_result">
            <ul id="preview">            
            <%  int ndx = 0;
                foreach (var item in Model) {%>                        
                <li id="item<%= (ndx + 1) % 4  %>">
                    <h3><a href="#" title="<%: item.title %>"><%: item.title %><img src="<%= Url.Content("~/Images/no-img-sm._AA75_.gif") %>" alt="" /></a></h3>
                    <p>Author: <%: item.authorId %></p>
                    <p>Price: <%: item.retailPrice %></p>
                </li>
            <%  ndx++; } %>
            </ul>
        </div>   
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
        
    <div id='simple_search'>
        <fieldset>
            <legend>Book details</legend>
                
            <ol>
                <li>
                    <label for="title">Book Title:</label>
                    <input id="title" name="title" type="text" />
                </li>
                <li>
                        <label for="subject">Subject:</label>
                        <input id="Text1" name="subject" type="text" />
                </li>
            </ol>
        </fieldset>
        <fieldset class="alt">
            <legend>Author details</legend>
                <ol>
                    <li>
                        <label for="first name">Author First Name:</label>
                        <input id="first name" name="first name" type="text" />
                    </li>
                    <li>
                        <label for="last name">Author Last Name:</label>
                        <input id="last name" name="last name" type="text" />
                    </li>
                </ol>
        </fieldset>            
        <fieldset>
            <legend>Publication details</legend>
                <ol>
                    <li>
                        <label for="isbn">ISBN Number:</label>
                        <input id="isbn" name="isbn" type="text" />
                    </li>
                    <li>
                        <label for="month">Publication Month:</label>
                        <input id="month" name="month" type="text" />
                    </li>
                    <li>
                        <label for="year">Publication Year:</label>
                        <input id="year" name="year" type="text" />
                    </li>
                </ol> 
        </fieldset>
        <fieldset class="submit">                  
                <ol>                                                   
                    <li>
                        <label for="submit"> </label>
                        <input id="submit" name="submit" type="submit" />
                    </li>
                </ol>
        </fieldset>
    </div>   
    

</asp:Content>
