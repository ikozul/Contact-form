using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace ContactForm.Models
{
    public class MailModel
    {

        public int IDForm { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Name is required!")]
        public String Name { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Surname is required!")]
        public String Surname { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Email is required!")]
        [RegularExpression(
        @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
        ErrorMessage = "Email is not valid!")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Question is required!")]
        public String Question { get; set; }
        public String Answer { get; set; }

        public MailModel()
        {

        }


        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}