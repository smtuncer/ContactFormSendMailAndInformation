using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactFormAndInformation.Models
{
    public class ContactMailForm
    {
        [Required]
        public string ContactMailName { get; set; }
        [Required]
        public string ContactMailSurname { get; set; }
        [Required]
        public string ContactMailEmail { get; set; }
        [Required]
        public string ContactMailSubject { get; set; }
        [Required]
        public string ContactMailMessage { get; set; }
    }
}
