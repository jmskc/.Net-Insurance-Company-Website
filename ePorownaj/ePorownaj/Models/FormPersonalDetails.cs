using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ePorownaj.Models
{
    public class FormPersonalDetails
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

        [Required(ErrorMessage = "Wprowadź numer PESEL")]
        [MaxLength(11, ErrorMessage = "Wprowadzono zbyt długi numer PESEL")]
        [MinLength(11, ErrorMessage = "Wprowadzono zbyt krótki numer PESEL")]
        [Display(Name = "Numer PESEL*")]
        public string PESEL { get; set; }

        [Required(ErrorMessage = "Wybierz stan cywilny")]
        [Display(Name = "Stan cywilny*")]
        public string Status { get; set; }
        public List<SelectListItem> StatusTypes { get; set; }

        [Required(ErrorMessage = "Wprowadź datę urodzenia")]
        [Display(Name = "Data urodzenia*")]
        public string DOB { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Zgoda na przetważanie danych jest konieczna do przeprowadzenia kalkulacji")]
        public bool Agreement { get; set; }
    }
}