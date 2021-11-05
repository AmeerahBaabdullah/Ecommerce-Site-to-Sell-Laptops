using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sell_laptop.Models
{
    public class user
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You need to add First Name")]
        public string Fname { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to add Last Name")]
        public string Lname { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "You need to add your Email")]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "You need to add your address")]
        public string address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "You need to add Your City")]
        public string city { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "You need to add Your Country")]
        public string  country { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "You need to add Your Phone")]
        public int phone { get; set; }

        [Display(Name = "password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You need to add Your Password")]
        public string password { get; set; }



    }
}