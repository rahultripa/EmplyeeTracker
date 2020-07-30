using System;
using System.ComponentModel.DataAnnotations;
using Xamarin.Forms;

namespace TrackEmployees.Model
{
    public class Employees 
    {

        [Required, MaxLength(40), EmailAddress]
        public string EmailID { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public string  FirstName { get; set; }
        [Required]
        public string LastName  { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RePassword { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool IsEmp1 { get; set; }
        public bool IsEmp2 { get; set; }
        public bool  IsSupport { get; set; }

    }

}

