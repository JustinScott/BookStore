using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using TEAM5OCGS.Models;

namespace TEAM5OCGS.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            int custId, empId;
            object x;
            if (ModelState.IsValid)
            {
                //if (MembershipService.ValidateUser(model.UserName, model.Password))
                custId = Customer.ValidateUser(model.UserName, model.Password);
                empId = Employee.ValidateUser(model.UserName, model.Password);
                if(custId != -1)
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    Session["custId"] = custId;
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else if (empId != -1)
                {
                    FormsService.SignIn(model.UserName, false);
                    Session["empId"] = empId;                    
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Employee", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            //ViewData["PasswordLength"] = 4;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            int custId;
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                //MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);
                custId = Customer.CreateNewUser(model.UserName, model.Password, model.Email, model.f_name, model.l_name, model.address, model.city, model.state, model.zip, model.region);

                //if (createStatus == MembershipCreateStatus.Success)
                if (custId > 0)
                {
                    FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    Session["custId"] = custId;
                    return RedirectToAction("Index", "Home");
                }
                else if (custId == -2)
                {
                    ModelState.AddModelError("", "User name not available. Please choose another one.");
                }
                else
                {
                    //ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                    ModelState.AddModelError("", "The registration info you provdied has errors.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;            
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

    }
}
