using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Webinar.Database;

namespace Webinar.Controllers
{
    public class HomeController : Controller
    {
        public appstore db = new appstore();


        // GET: Home
        public ActionResult Webinar()
        {
            return View();
        }



        public void SendEmailToUser(string Email, string Subject, string Name, string Company, string message, string Day)
        {


            var fromMail = new MailAddress("Dynamicdna7@gmail.com", "Dynamic DNA"); // set your email  
            var fromEmailpassword = "October2019!@#"; // Set your password   
            var toEmail = new MailAddress(Email);

            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);

            var Message = new MailMessage(fromMail, toEmail);
            Message.Subject = "Work from home program";
            Message.Body = "<br/> Hello " + Name +
                           "<br/> Thank you for registration, we will contact you shortly";
            //"<br/><br/><a href=" + link + ">" + link + "</a>";



            //var fromAddress = e.Email.ToString();




            Message.IsBodyHtml = true;
            smtp.Send(Message);
        }



        public ActionResult success()
        {
            return View();
        }


        public ActionResult Attendees()

        {
            return View(db.Webinars.ToList());
        }






        public ActionResult Contact()
        { return View(); }



        [HttpPost]
        public ActionResult Contact(Webinar.Database.Webinar a)
        {
            if (ModelState.IsValid)
            {
                db.Webinars.Add(a);
                db.SaveChanges();
                SendEmailToUser(a.Name, a.Email, a.Company, a.Message, a.Day.ToString());
                return RedirectToAction("success");
            }

            return View(a);
        }

        private void SendEmailToUser(string name, string email, string company, string v, string Day)
        {

            var fromMail = new MailAddress("Dynamicdna7@gmail.com", "Dynamic DNA"); // set your email  
            var fromEmailpassword = "October2019!@#"; // Set your password   
            var toEmail = new MailAddress(email);

            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);

            var Message = new MailMessage(fromMail, toEmail);
            Message.Subject = "Work from home program";
            Message.Body = "<br/> Hello " + name +
                           "<br/> Thank you for your registration. " + "Your Scheduled date is " + Day + " and your message is as follows '"

                           + v + "'. <b> We will contact you shortly</b>";
            //"<br/><br/><a href=" + link + ">" + link + "</a>";



            //var fromAddress = e.Email.ToString();




            Message.IsBodyHtml = true;
            smtp.Send(Message);
        }
    
}
}