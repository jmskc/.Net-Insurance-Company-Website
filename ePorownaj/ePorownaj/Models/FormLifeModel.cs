using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ePorownaj.Models
{
    public class FormLifeModel
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

        [Required(ErrorMessage = "Wprowadź datę urodzenia")]
        [Display(Name = "Data urodzenia*")]
        public string DOB { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Zgoda na przetważanie danych jest konieczna do przeprowadzenia kalkulacji")]
        public bool Agreement { get; set; }

        [Required(ErrorMessage = "Wprowaź wykonywany zawód")]
        [Display(Name = "Wykonywany zawód*")]
        public string Profession { get; set; }

        [Required(ErrorMessage = "Wprowaź sugerowaną sumę ubezpieczenia")]
        [Display(Name = "Sugerowana suma ubezpieczenia*")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Niepoprawny format sumy ubezpieczenia (dozwolone są jedynie znaki numeryczne)")]
        public string Sum { get; set; }

        [Required(ErrorMessage = "Odpowiedz na pytanie - Czy chorowałeś/aś lub byłeś/aś w szpitalu w ostatnich 10 latach?")]
        [Display(Name = "Czy chorowałeś/aś lub byłeś/aś w szpitalu w ostatnich 10 latach?*")]
        public string Sickness { get; set; }
        public List<SelectListItem> SicknesstTypes { get; set; }
    }
}