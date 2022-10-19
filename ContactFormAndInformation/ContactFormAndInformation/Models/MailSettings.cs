using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactFormAndInformation.Models
{
    public class MailSettings
    {
        [Key]
        public int MailSettingsId { get; set; }
        [Required]
        public string FromEmailAddress { get; set; }
        [Required]
        public string FromEmailAddressDisplayName { get; set; }
        [Required]
        public string SendEmailAddress { get; set; }
        [Required]
        public string SendEmailAddressDisplayName { get; set; }
        [Required]
        public string SmtpHost { get; set; }
        [Required]
        public string SmtpPort { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string EmailAddressPassword { get; set; }
    }
}
