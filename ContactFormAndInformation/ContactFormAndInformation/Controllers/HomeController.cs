using ContactFormAndInformation.Data;
using ContactFormAndInformation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ContactFormAndInformation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Contact()
        {
            ViewBag.ContactInformationData = _context.Contact.FirstOrDefault();
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactMailForm m)
        {
            var mailSettings = _context.MailSettings.FirstOrDefault();
            MailMessage msg = new MailMessage();
            msg.Subject = m.ContactMailSubject;
            msg.From = new MailAddress(mailSettings.FromEmailAddress, mailSettings.FromEmailAddressDisplayName);
            msg.To.Add(new MailAddress(mailSettings.SendEmailAddress, mailSettings.SendEmailAddressDisplayName));
            msg.IsBodyHtml = true;
            msg.Body = "Email: " + m.ContactMailEmail + "<br>" + "Name Surname : " + m.ContactMailName + " " + m.ContactMailSurname + "<br><br><br>" + m.ContactMailMessage;
            msg.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient(mailSettings.SmtpHost, Int32.Parse(mailSettings.SmtpPort));
            NetworkCredential AccountInfo = new NetworkCredential(mailSettings.EmailAddress, mailSettings.EmailAddressPassword);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = false;
            try
            {
                smtp.Send(msg);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Contact");
        }
        public IActionResult ContactSettingsPage()
        {
            ViewBag.ContactInformationData = _context.Contact.FirstOrDefault();
            ViewBag.MailSettingsData = _context.MailSettings.FirstOrDefault();
            return View();
        }



        //CONTACTINFORMATION CRUD
        [HttpGet]
        public IActionResult ContactInformationAdd()
        {

            return View();
        }
        [HttpPost]
        public IActionResult ContactInformationAdd(ContactInformation p)
        {
            var dataCount = _context.Contact.ToList().Count();
            if (dataCount < 1)
            {
                _context.Add(p);
                _context.SaveChanges();
                return RedirectToAction("ContactSettingsPage");
            }
            else
            {
                return RedirectToAction("ContactSettingsPage");
            }
        }
        [HttpGet]
        public IActionResult ContactInformationEdit(int id)
        {
            var data = _context.Contact.FirstOrDefault(x => x.ContactId == id);
            return View(data);
        }
        [HttpPost]
        public IActionResult ContactInformationEdit(ContactInformation p)
        {
            _context.Update(p);
            _context.SaveChanges();
            return RedirectToAction("ContactSettingsPage");
        }
        public IActionResult ContactInformationRemove(int id)
        {
            var dataId = _context.Contact.FirstOrDefault(x => x.ContactId == id);
            _context.Remove(dataId);
            _context.SaveChanges();
            return RedirectToAction("ContactSettingsPage");
        }





        //MAILSETTINGS CRUD

        [HttpGet]
        public IActionResult MailSettingsAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MailSettingsAdd(MailSettings p)
        {
            var dataCount = _context.MailSettings.ToList().Count();
            if (dataCount < 1)
            {
                _context.Add(p);
                _context.SaveChanges();
                return RedirectToAction("ContactSettingsPage");
            }
            else
            {
                return RedirectToAction("ContactSettingsPage");
            }
        }
        [HttpGet]
        public IActionResult MailSettingsEdit(int id)
        {
            var data = _context.MailSettings.FirstOrDefault(x => x.MailSettingsId == id);
            return View(data);
        }
        [HttpPost]
        public IActionResult MailSettingsEdit(MailSettings p)
        {
            _context.Update(p);
            _context.SaveChanges();
            return RedirectToAction("ContactSettingsPage");
        }
        public IActionResult MailSettingsRemove(int id)
        {
            var dataId = _context.MailSettings.FirstOrDefault(x => x.MailSettingsId == id);
            _context.Remove(dataId);
            _context.SaveChanges();
            return RedirectToAction("ContactSettingsPage");
        }
    }
}
