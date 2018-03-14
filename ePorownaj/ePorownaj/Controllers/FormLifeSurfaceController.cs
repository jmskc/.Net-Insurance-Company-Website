using ePorownaj.Helpers;
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
    public class FormLifeSurfaceController : SurfaceController
    {
        private PreValueHelper preValueHelper => new PreValueHelper();
        public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/";

        public ActionResult RenderForm()
        {
            FormLifeModel model = new FormLifeModel();
            model.SicknesstTypes = preValueHelper.GetPreValuesFromAppSettingName("YNTypeDropdown");
            return PartialView(PARTIAL_VIEW_FOLDER + "_FormLife.cshtml", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(FormLifeModel model)
        {
            if (ModelState.IsValid)
            {
                SendEmail(model);
                TempData["ContactSuccess"] = true;
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        private void SendEmail(FormLifeModel model)
        {
            MailMessage message = new MailMessage(model.EmailAddress, "website@ePorownaj.web.local");
            message.Subject = string.Format("Ubezpieczenie na Życie! Zapytanie od {0} {1} - {2}", model.FirstName, model.LastName, model.EmailAddress);
            message.Body = string.Format("Dane klienta:\n\nImię i Nazwisko:\t\t{0} {1}\nAdres email:\t\t{2}\nNumer telefonu:\t\t{3}\nData urodzenia:\t\t{4}\nZawód:\t\t\t{5}\nSugerowana Suma:\t\t{6} zł\nChoroba lub Szpital:\t{7}\n"
                , model.FirstName
                , model.LastName
                , model.EmailAddress
                , model.PhoneNumber
                , model.DOB
                , model.Profession
                , model.Sum
                , model.Sickness
                );
            SmtpClient client = new SmtpClient("127.0.0.1", 25);
            client.Send(message);
        }
    }
}