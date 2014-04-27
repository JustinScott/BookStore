<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TEAM5OCGS.Models.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create a New Account</h2>
    <p>
        Use the form below to create a new account. 
    </p>
    <p>
        Passwords are required to be a minimum of <%: ViewData["PasswordLength"] %> characters in length.
    </p>

    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Account creation was unsuccessful. Please correct the errors and try again.") %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.UserName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserName) %>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Email) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Email) %>
                    <%: Html.ValidationMessageFor(m => m.Email) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Password) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.Password) %>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.ConfirmPassword) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                    <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.f_name) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.f_name) %>
                    <%: Html.ValidationMessageFor(m => m.f_name) %>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.l_name) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.l_name) %>
                    <%: Html.ValidationMessageFor(m => m.l_name) %>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.address) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.address) %>
                    <%: Html.ValidationMessageFor(m => m.address) %>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.city) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.city) %>
                    <%: Html.ValidationMessageFor(m => m.city) %>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.state) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.state) %>
                    <%: Html.ValidationMessageFor(m => m.state) %>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.zip) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.zip) %>
                    <%: Html.ValidationMessageFor(m => m.zip) %>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.region) %>
                </div>
                <div class="editor-field">
                    <select name="region">
                        <option value="N">N</option>
                        <option value="NE">NE</option>
                        <option value="E">E</option>
                        <option value="SE">SE</option>
                        <option value="S">S</option>
                        <option value="SW">SW</option>
                        <option value="W">W</option>
                        <option value="NW">NW</option>
                    </select>                    
                </div>
                
                <p>
                    <input type="submit" value="Register" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
