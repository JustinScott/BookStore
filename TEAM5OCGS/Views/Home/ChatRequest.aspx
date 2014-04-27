<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ChatRequest
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="chat_window">
        <h2><%= ViewData["Name"] %>, your business is very important to us. Please 
        wait while we find a customer service representative.</h2>

        <div id="progress">Progress Bar</div>

        <input id="joinchat" type="button" value="meh" />
     </div>
</asp:Content>
