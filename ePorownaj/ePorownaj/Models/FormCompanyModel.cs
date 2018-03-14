using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ePorownaj.Models
{
    public class FormCompanyModel  
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

        [Required(ErrorMessage = "Wprowaź nazwę firmy")]
        [Display(Name = "Nazwa firmy*")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Wprowadź numer NIP")]
        [MaxLength(10, ErrorMessage = "Wprowadzono zbyt długi numer NIP")]
        [MinLength(10, ErrorMessage = "Wprowadzono zbyt krotki numer NIP")]
        [Display(Name = "Numer NIP*")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Niepoprawny format w polu \"Numer NIP\" (dozwolone są jedynie znaki numeryczne)")]
        public string NIP { get; set; }

        [Required(ErrorMessage = "Wprowadź PKD, które mamy ubezpieczyć")]
        [Display(Name = "PKD, które mamy ubezpieczyć*")]
        public string PKD { get; set; }

        [Required(ErrorMessage = "Wybierz odpowiedź w polu \"Czy były szkody w ostatnich 5 latach?*\"")]
        [Display(Name = "Czy były szkody w ostatnich 5 latach?*")]
        public string Claims { get; set; }
        public List<SelectListItem> ClaimsTypes { get; set; }

        [Required(ErrorMessage = "Wprowadź ilość zatrudnionych pracowników")]
        [Display(Name = "Ilość zatrudnionych pracowników*")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Niepoprawny format w polu \"Ilość zatrudnionych pracowników\" (dozwolone są jedynie znaki numeryczne)")]
        public string Employees { get; set; }

        [Required(ErrorMessage = "Wprowadź kod pocztowy")]
        [MaxLength(6, ErrorMessage = "Wprowadzono zbyt długi kod pocztowy")]
        [MinLength(5, ErrorMessage = "Wprowadzono zbyt krótki kod pocztowy")]
        [Display(Name = "Kod pocztowy*")]
        public string PostCode { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Zgoda na przetważanie danych jest konieczna do przeprowadzenia kalkulacji")]
        public bool Agreement { get; set; }
    }
}