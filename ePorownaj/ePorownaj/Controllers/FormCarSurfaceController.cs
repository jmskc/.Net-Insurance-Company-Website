using Umbraco.Web.Mvc;
using System.Web.Mvc;
using ePorownaj.Models;
using System.Net.Mail;
using ePorownaj.Helpers;

namespace ePorownaj.Controllers
{
    public class FormCarSurfaceController : SurfaceController
    {
        private PreValueHelper preValueHelper => new PreValueHelper();
        public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/";

        public ActionResult RenderForm()
        {
            FormCarModel model = new FormCarModel();
            model.Brands = preValueHelper.GetPreValuesFromAppSettingName("MarkaSamochoduTypeDropdown");
            model.StatusTypes = preValueHelper.GetPreValuesFromAppSettingName("StatusCywilnyTypeDropdown");
            model.CoOwnerTypes = preValueHelper.GetPreValuesFromAppSettingName("YNTypeDropdown");
            model.PetrolTypes = preValueHelper.GetPreValuesFromAppSettingName("PetrolTypeDropdown");
            model.BodyWorkTypes = preValueHelper.GetPreValuesFromAppSettingName("BodyworkTypeDropdown");
            model.GearBoxTypes = preValueHelper.GetPreValuesFromAppSettingName("GearBoxTypeDropdown");
            model.UsageTypes = preValueHelper.GetPreValuesFromAppSettingName("CarUsageTypeDropdown");
            model.ParkingTypes = preValueHelper.GetPreValuesFromAppSettingName("CarParkingTypeDropdown");
            model.OriginTypes = preValueHelper.GetPreValuesFromAppSettingName("CarOriginTypeDropdown");
            return PartialView(PARTIAL_VIEW_FOLDER + "_FormCar.cshtml",model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(FormCarModel model)
        {
            if (ModelState.IsValid)
            {
                SendEmail(model);
                TempData["ContactSuccess"] = true;
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        private void SendEmail(FormCarModel model)
        {
            MailMessage message = new MailMessage(model.EmailAddress, "kontakt@eporownaj.pl");
            message.Subject = string.Format("Ubezpieczenie Samochodu! Zapytanie od {0} {1} - {2}", model.FirstName, model.LastName, model.EmailAddress);
            message.Body = string.Format("Dane klienta:\n\nImię i Nazwisko:\t\t{0} {1}\nData urodzenia:\t\t{2}\nAdres email:\t\t{3}\nNumer telefonu:\t\t{4}\nKod pocztowy:\t\t{5}\nNumer PESEL:\t\t{6}\nStan cywilny:\t\t{7}\nWspółwłaściciel:\t\t{8}\nRok wydania prawa jazdy:\t{9}\n \nDane dotyczące pojazdu:\nMarka:\t\t\t{10}\nRok produkcji:\t\t{11}\nRodzaj paliwa\t\t{12}\nModel:\t\t\t{13}\nPojemność silnika:\t\t{14} cm3\nMoc:\t\t\t{15} kW\nTyp nadwozia:\t\t{16}\nSkrzynia biegów:\t\t{17}\nPrzebieg:\t\t\t{18} km\nPochodzenie:\t\t{19}\nMiejsce parkowania:\t{20}\nUżytkowanie:\t\t{21}\nOkres własności:\t\t{22} lat\nNumer rejestracyjny:\t{23}\nObecny ubezpieczyciel:\t{24}\nKoniec umowy:\t\t{25}"
                ,model.FirstName
                ,model.LastName
                ,model.DOB
                ,model.EmailAddress
                ,model.PhoneNumber
                ,model.PostCode
                ,model.PESEL
                ,model.Status
                ,model.CoOwner
                ,model.DriversLicense
                ,model.Brand
                ,model.ProductionYear
                ,model.Petrol
                ,model.Make
                ,model.Capacity
                ,model.Power
                ,model.Bodywork
                ,model.GearBox
                ,model.Milage
                ,model.Origin
                ,model.Parking
                ,model.Usage
                ,model.Ownership
                ,model.Registration
                ,model.InsuranceCompany
                ,model.InsuranceEnd
                );
            SmtpClient client = new SmtpClient("127.0.0.1", 25);
            client.Send(message);
        }
    }
}