using Umbraco.Web.Mvc;
using System.Web.Mvc;
using ePorownaj.Models;
using System.Net.Mail;
using ePorownaj.Helpers;

namespace ePorownaj.Controllers
{
    public class FormPropertySurfaceController : SurfaceController
    {
        private PreValueHelper preValueHelper => new PreValueHelper();
        public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/";

        public ActionResult RenderForm()
        {
            FormPropertyModel model = new FormPropertyModel();
            model.PropoertTypes = preValueHelper.GetPreValuesFromAppSettingName("PropertyTypeTypeDropdown");
            model.LegalStatusTypes = preValueHelper.GetPreValuesFromAppSettingName("LegalStatusTypeDropdown");
            return PartialView(PARTIAL_VIEW_FOLDER + "_FormProperty.cshtml", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(FormPropertyModel model)
        {
            if (ModelState.IsValid)
            {
                SendEmail(model);
                TempData["ContactSuccess"] = true;
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        private void SendEmail(FormPropertyModel model)
        {
            MailMessage message = new MailMessage(model.EmailAddress, "kontakt@eporownaj.pl");
            message.Subject = string.Format("Ubezpieczenie Nieruchomości! Zapytanie od {0} {1} - {2}", model.FirstName, model.LastName, model.EmailAddress);
            message.Body = string.Format("Dane klienta:\n\nImię i Nazwisko:\t\t{0} {1}\nAdres email:\t\t{2}\nNumer telefonu:\t\t{3}\n \nDane dotyczące nieruchomości:\nKod pocztowy:\t\t{4}\nMiejscowość:\t\t{5}\nTyp nieruchomości:\t\t{6}\nTytuł prawny lokalu:\t{7}\nPowierzchnia:\t\t{8} m2\nRok budowy:\t\t{9}\nMienie nieruchome:\t\t{10} zł\nMienieruchome\t\t{11} zł"
                , model.FirstName
                , model.LastName
                , model.EmailAddress
                , model.PhoneNumber
                , model.PostCode
                , model.City
                , model.PropertyType
                , model.LegalStatus
                , model.Area
                , model.YearBuilt
                , model.ConstantSum
                , model.MovableSum
                );
            SmtpClient client = new SmtpClient("127.0.0.1", 25);
            client.Send(message);
        }
    }
}