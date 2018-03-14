using ePorownaj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ePorownaj.Controllers
{
    public class FormContactSurfaceController : SurfaceController
    {
        public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/";

        public ActionResult RenderForm()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_FormContact.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(FormContactModel model)
        {
            if (ModelState.IsValid)
            {
                SendEmail(model);
                TempData["ContactSuccess"] = true;
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        private void SendEmail(FormContactModel model)
        {
            MailMessage message = new MailMessage(model.EmailAddress, "kontakt@eporownaj.pl");
            message.Subject = string.Format("Zapytanie ePorównaj! Zapytanie od {0} {1} - {2}", model.FirstName, model.LastName, model.EmailAddress);
            message.Body = string.Format(model.Message);
            SmtpClient client = new SmtpClient("127.0.0.1", 25);
            client.Send(message);
        }
    }
}