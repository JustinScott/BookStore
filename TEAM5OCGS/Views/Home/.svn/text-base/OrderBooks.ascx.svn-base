<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TEAM5OCGS.Models.Book>" %>

<div id="status"><h3>Use this form to re-order books that have a qoh of zero. Enter the ISBN of the book you want to order and click
the "Find by ISBN" button.</h3></div><br />


    <%: Html.ValidationSummary(true) %>
        
    <fieldset id="bookorder">
        <legend>Book Order Form</legend>
        <ol>
        <li>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.isbn) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.isbn) %>
            <%: Html.ValidationMessageFor(model => model.isbn) %>
        </div>
            
        <input id="findbook" type="button" value="Find by ISBN" />
        <br class="clear" />
        </li>
        <li>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.title) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.title) %>
            <%: Html.ValidationMessageFor(model => model.title) %>
        </div>
        </li>
        <li>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.qoh) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.qoh) %>
            <%: Html.ValidationMessageFor(model => model.qoh) %>
        </div>
        </li>
        <li>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.retailPrice) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.retailPrice) %>
            <%: Html.ValidationMessageFor(model => model.retailPrice) %>
        </div>
        </li>
        <li>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.wholesalePrice) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.wholesalePrice) %>
            <%: Html.ValidationMessageFor(model => model.wholesalePrice) %>
        </div>
        </li>
        <li>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.category) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.category) %>
            <%: Html.ValidationMessageFor(model => model.category) %>
        </div>
        </li> 
        <li>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.l_name) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.l_name) %>
            <%: Html.ValidationMessageFor(model => model.l_name) %>
        </div>
        </li>
        <li>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.f_name) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.f_name) %>
            <%: Html.ValidationMessageFor(model => model.f_name) %>
        </div>
        </li>            
        </ol>
        <p>
            <label for="newqoh">Enter the number of books you want to add to the inventory.</label>
            <input id="newqoh" name="newqoh" type="text" />
            <input id="qoh_order" type="button" value="Order book" />
        </p>
    </fieldset>


