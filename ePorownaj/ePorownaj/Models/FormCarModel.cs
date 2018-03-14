using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ePorownaj.Models
{
    public class FormCarModel : FormPersonalDetails
    {
        [Required(ErrorMessage = "Wybierz rok produkcji pojazdu")]
        [Display(Name = "Rok produkcji pojazdu*")]
        public string ProductionYear { get; set; }

        [Required(ErrorMessage = "Wybierz markę pojazdu z listy")]
        [Display(Name = "Marka samochodu*")]
        public string Brand { get; set; }
        public List<SelectListItem> Brands { get; set; }

        [Required(ErrorMessage = "Brak informacji odnośnie współwałaności")]
        [Display(Name = "Wspówaciciel*")]
        public string CoOwner { get; set; }
        public List<SelectListItem> CoOwnerTypes { get; set; }

        [Required(ErrorMessage = "Wprowadź datę wydania prawa jazdy")]
        [Display(Name = "Data wydania prawa jazdy*")]
        public string DriversLicense { get; set; }

        [Required(ErrorMessage = "Brak informacji odnośnie rodzaju paliwa")]
        [Display(Name = "Rodaj paliwa*")]
        public string Petrol { get; set; }
        public List<SelectListItem> PetrolTypes { get; set; }

        [Display(Name = "Model pojazdu")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Wprowadź pojemność silnika")]
        [MaxLength(5, ErrorMessage = "Wprowadzono zbyt wysoką wartość w polu  \"pojemność silnika\"")]
        [MinLength(3, ErrorMessage = "Wprowadzono zbyt niską wartość w polu  \"pojemność silnika\"")]
        [Display(Name = "Pojemność silnika w cm3*")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Wprowadzono niepoprawną wartość odnośnie pojemności silnika (upewnij się, żę pole zawiera tylko cyfry)")]
        public string Capacity { get; set; }

        [Required(ErrorMessage = "Wprowadź moc silnika w kW")]
        [MaxLength(4, ErrorMessage = "Wprowadzono zbyt wysoką wartość w polu \"moc silnika\"")]
        [MinLength(1, ErrorMessage = "Wprowadzono zbyt niską wartość w polu \"moc silnika\"")]
        [Display(Name = "Moc silnika w kW*")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Wprowadzono niepoprawną wartość odnośnie mocy silnika (upewnij się, żę pole zawiera tylko cyfry)")]
        public string Power { get; set; }

        [Required(ErrorMessage = "Brak informacji odnośnie nadwozia")]
        [Display(Name = "Typ nadwozia*")]
        public string Bodywork { get; set; }
        public List<SelectListItem> BodyWorkTypes { get; set; }

        [Required(ErrorMessage = "Brak informacji odnośnie rodzaju skrzyni biegów")]
        [Display(Name = "Rodzaj skrzyni biegów*")]
        public string GearBox { get; set; }
        public List<SelectListItem> GearBoxTypes { get; set; }

        [Required(ErrorMessage = "Wprowadź przebieg pojazdu w Km")]
        [MaxLength(7, ErrorMessage = "Wprowadzono zbyt wysoką wartość w polu \"Przebieg pojazdu\"")]
        [Display(Name = "Przebieg pojazdu w Km*")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Wprowadzono niepoprawną wartość odnośnie przebiegu pojazdu (upewnij się, żę pole zawiera tylko cyfry)")]
        public string Milage { get; set; }

        [Required(ErrorMessage = "Brak informacji odnośnie pochodzenia pojazdu")]
        [Display(Name = "Pochodzenie pojazdu*")]
        public string Origin { get; set; }
        public List<SelectListItem> OriginTypes { get; set; }

        [Required(ErrorMessage = "Brak informacji odnośnie miesca parkowania w ciągu nocy")]
        [Display(Name = "Miejsce parkowania w ciągu nocy*")]
        public string Parking { get; set; }
        public List<SelectListItem> ParkingTypes { get; set; }

        [Required(ErrorMessage = "Brak informacji odnośnie użytkowania pojazdu")]
        [Display(Name = "Rodzaj użytkowania pojazdu*")]
        public string Usage { get; set; }
        public List<SelectListItem> UsageTypes { get; set; }

        [Required(ErrorMessage = "Wprowadź liczbę lat posiadania pojazdu")]
        [MaxLength(2, ErrorMessage = "Wprowadzono zbyt wysoką wartość w polu \"Posiadanie pojazdu\"")]
        [MinLength(1, ErrorMessage = "Wprowadzono zbyt niską wartość w polu \"Posiadanie pojazdu\"")]
        [Display(Name = "Posiadanie pojazdu w latach*")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Wprowadzono niepoprawną wartość odnośnie posiadania pojazdu (upewnij się, żę pole zawiera tylko cyfry)")]
        public string Ownership { get; set; }

        [Required(ErrorMessage = "Wprowadź numer rejestracyjny pojazdu")]
        [MaxLength(7, ErrorMessage = "Wprowadzono zbyt długi numer rejestracyjny pojazdu (upewnij się, że numer nie posiada spacji)")]
        [MinLength(7, ErrorMessage = "Wprowadzono zbyt krótki number rejestracyjny pojazdu")]
        [Display(Name = "Numer rejestracyjny pojazdu*")]
        public string Registration { get; set; }

        [Display(Name = "Data zakończenia obecnej umowy ubezpieczeniowej")]
        public string InsuranceEnd { get; set; }

        [Display(Name = "Nazwa obecnego ubezpieczyciela")]
        public string InsuranceCompany { get; set; }

    }
}