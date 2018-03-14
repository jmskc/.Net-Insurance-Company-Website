using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ePorownaj.Models
{
    public class FormPropertyModel 
    {
        [Required(ErrorMessage = "Wprowaź poprawne imię")]
        [Display(Name = "Imię*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Wprowaź poprawne nazwisko")]
        [Display(Name = "Nazwisko*")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Wprowadź swój email")]
        [EmailAddress(ErrorMessage = "Niepoprawny format adresu email")]
        [Display(Name = "Adres email*")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Wprowadź numer telefonu")]
        [MaxLength(13, ErrorMessage = "Wprowadzono zbyt długi numer telefonu")]
        [Phone(ErrorMessage = "Niepoprawny format numeru telefonu")]
        [MinLength(9, ErrorMessage = "Wprowadzono zbyt krotki numer telefonu")]
        [Display(Name = "Numer telefonu*")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Niepoprawny format numeru telefonu")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Wprowadź kod pocztowy")]
        [MaxLength(6, ErrorMessage = "Wprowadzono zbyt długi kod pocztowy")]
        [MinLength(5, ErrorMessage = "Wprowadzono zbyt krótki kod pocztowy")]
        [Display(Name = "Kod pocztowy*")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwę miejscowości")]
        [Display(Name = "Miejscowość*")]
        public string City { get; set; }

        [Required(ErrorMessage = "Wybierz typ nieruchomości")]
        [Display(Name = "Typ nieruchomości*")]
        public string PropertyType { get; set; }
        public List<SelectListItem> PropoertTypes { get; set; }

        [Required(ErrorMessage = "Wybierz tytuł prawny nieruchomości")]
        [Display(Name = "Tytuł prawny nieruchomości*")]
        public string LegalStatus { get; set; }
        public List<SelectListItem> LegalStatusTypes { get; set; }

        [Required(ErrorMessage = "Wprowadź powierzchnię nieruchomości w m2")]
        [Display(Name = "Powierzchnia nieruchomości w m2*")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Niepoprawny format w polu \"Powierzchnia nieruchomości\" (dozwolone są jedynie znaki numeryczne)")]
        public string Area { get; set; }

        [Required(ErrorMessage = "Wprowadź rok budowy nieruchomości")]
        [Display(Name = "Rok budowy*")]
        [MaxLength(4, ErrorMessage = "Niepoprawny format w polu \"Rok budowy\"")]
        [MinLength(4, ErrorMessage = "Niepoprawny format w polu \"Rok budowy\"")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Niepoprawny format w polu \"Rok budowy\" (dozwolone są jedynie znaki numeryczne)")]
        public string YearBuilt { get; set; }

        [Required(ErrorMessage = "Wprowadź sumę ubezpieczenia murów i stałych elementów")]
        [Display(Name = "Suma ubezpieczenia murów i stałych elementów*")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Niepoprawny format w polu \"Suma ubezpieczenia murów i stałych elementów\" (dozwolone są jedynie znaki numeryczne)")]
        public string ConstantSum { get; set; }

        [Required(ErrorMessage = "Wprowadź sumę ubezpieczenia mienia ruchomego")]
        [Display(Name = "Suma ubezpieczenia mienia ruchomego*")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Niepoprawny format w polu \"Suma ubezpieczenia mienia ruchomego\" (dozwolone są jedynie znaki numeryczne)")]
        public string MovableSum { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Zgoda na przetważanie danych jest konieczna do przeprowadzenia kalkulacji")]
        public bool Agreement { get; set; }
    }
}