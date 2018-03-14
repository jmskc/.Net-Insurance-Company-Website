using Umbraco.Web.Mvc;
using System.Web.Mvc;
using ePorownaj.Models;
using System.Net.Mail;
using ePorownaj.Helpers;

namespace ePorownaj.Controllers
{
    public class FormCompanySurfaceController : SurfaceController
    {
        private PreValueHelper preValueHelper => new PreValueHelper();
        public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/";

        public ActionResult RenderForm()
        {
            FormCompanyModel model = new FormCompanyModel();
            model.ClaimsTypes = preValueHelper.GetPreValuesFromAppSettingName("YNTypeDropdown");
            return PartialView(PARTIAL_VIEW_FOLDER + "_FormCompany.cshtml", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(FormCompanyModel model)
        {
            if (ModelState.IsValid)
            {
                SendEmail(model);
                TempData["ContactSuccess"] = true;
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        private void SendEmail(FormCompanyModel model)
        {
            MailMessage message = new MailMessage(model.EmailAddress, "kontakt@eporownaj.pl");
            message.Subject = string.Format("Ubezpieczenie na Firmę! Zapytanie od {0} {1} - {2}", model.FirstName, model.LastName, model.EmailAddress);
            message.Body = string.Format("Dane klienta:\n\nImię i Nazwisko:\t\t{0} {1}\nAdres email:\t\t{2}\nNumer telefonu:\t\t{3}\n \nDane dotyczące firmy:\nKod pocztowy:\t\t{4}\nLiczba pracowników:\t{5}\nNazwa firmy:\t\t{6}\nNIP:\t\t\t{7}\nSzkody:\t\t\t{8}\nPKD:\t\t\t{9}"
                , model.FirstName
                , model.LastName
                , model.EmailAddress
                , model.PhoneNumber
                , model.PostCode
                , model.Employees
                , model.CompanyName
                , model.NIP
                , model.PKD
                , model.Claims
                );
            SmtpClient client = new SmtpClient("127.0.0.1", 25);
            client.Send(message);
        }
    }
}