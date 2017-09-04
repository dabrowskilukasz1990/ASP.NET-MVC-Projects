using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WarsztatSamochodowy.Models
{
    public class Car
    {
        public int CarId { get; set; }

        [DisplayName("Numer rejestracyjny")]
        [StringLength(8)]
        [Required(ErrorMessage = "Musisz wprowadzić numer rejestracyjny")]
        public string RegisterNumber { get; set; }

        [DisplayName("VIN")]
        public string VinNumber { get; set; }

        [DisplayName("Marka")]
        public string Brand { get; set; }

        [DisplayName("Model")]
        public string Model { get; set; }

        [DisplayName("Osoba odpowiedzialna")]
        public string ResponsiblePerson { get; set; }

        [DisplayName("Lista zadań")]
        public string TaskList { get; set; }

        [DisplayName("Data odbioru")]
        public string DateOfReceipt { get; set; }

        [DisplayName("Cena")]
        public string Price { get; set; }

        public string CarErrorMessage { get; set; }
    }
}