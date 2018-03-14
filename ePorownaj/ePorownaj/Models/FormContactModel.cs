using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ePorownaj.Models
{
    public class FormContactModel
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

        [Required(ErrorMessage = "Brak treści w polu \"Wiadomość\"")]
        [Display(Name = "Wiadomość*")]
        public string Message { get; set; }
    }
}