using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TestAppMVC.Models
{
    public class Customer
    {
        public string ID { get; set; }
        [Required]
        [DisplayName("First Name")]
        [StringLength(40,ErrorMessage ="Your Name is too long")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        public string Telephone { get; set; }
    }

}