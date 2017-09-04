using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WarsztatSamochodowy.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [DisplayName("Login")]
        [Required(ErrorMessage = "Musisz wprowadzić login")]
        public string Login { get; set; }


        [DisplayName("Hasło")]
        [Required(ErrorMessage = "Musisz wprowadzić hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Imię")]
        [Required(ErrorMessage = "Musisz wprowadzić imię")]
        public string FirstName { get; set; }

        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Musisz wprowadzić nazwisko")]
        public string LastName { get; set; }

        public string Role { get; set; }

        public string LoginErrorMessage { get; set; }

    }
}
