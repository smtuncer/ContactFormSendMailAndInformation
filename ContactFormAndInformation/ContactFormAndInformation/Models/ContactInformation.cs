using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactFormAndInformation.Models
{
    public class ContactInformation
    {
        [Key]
        public int ContactId { get; set; }
        [Required]
        public string ContactAddress { get; set; }
        [Required]
        public string ContactPhone { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        [Required]
        public string ContactMapIframe { get; set; }
    }
}
