using JanperWebsite.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdacsPLUS.Controllers
{
    public class EnquiriesController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View(new Model_Contact());
        //}

        [ChildActionOnly]
        public ActionResult _Enquiries()
        {
            return View(new Model_Contact());
        }

        [HttpPost]
        public ActionResult Index(Model_Contact form_data)
        {
            return View(form_data);
        }

        private bool IsHuman()
        {
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LdaXkAUAAAAAKkYNn1fynKmAI2MK4PRTmJ2lLHB";

            var client = new WebClient();
            var result =
                client.DownloadString(
                    $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={response}");

            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");

            return status;
        }

        [HttpPost]
        public async Task<ActionResult> ContactPost(Model_Contact model)
        {
            if (ModelState.IsValid && IsHuman())
            {
                string infoMail = ConfigurationManager.AppSettings["infoMail"].ToString();
                string emailTemplateConfirmation = ConfigurationManager.AppSettings["templateConfirmation"].ToString();
                string emailTemplateNotification = ConfigurationManager.AppSettings["templateNotification"].ToString();
                string mailBody = string.Empty;
                string Name = model.Name;
                string PhoneNumber = model.Phone;
                string EmailAddress = model.Email;
                string AdditionalComment = model.AdditionalComments;
                //bool PrivacyAccepted = model.TermsAndConditions;
                try
                {
                    //Email to customer
                    mailBody = System.IO.File.ReadAllText(Server.MapPath(emailTemplateConfirmation));
                    mailBody = mailBody.Replace("??FIRSTNAME??", Name);

                    using (MailMessage mailObjConfirmation = new MailMessage())
                    {
                        mailObjConfirmation.From = new MailAddress(infoMail);
                        mailObjConfirmation.To.Add(new MailAddress(EmailAddress));
                        mailObjConfirmation.Subject = "Your enquiry on the Janper website";
                        mailObjConfirmation.IsBodyHtml = true;
                        mailObjConfirmation.Body = mailBody;
                        mailObjConfirmation.Sender = new MailAddress(infoMail);
                        SmtpClient SMTPServerConfirmation = new SmtpClient();
                        SMTPServerConfirmation.Host = ConfigurationManager.AppSettings["hostName"].ToString();
                        SMTPServerConfirmation.Send(mailObjConfirmation);
                    }
                    //email to staff
                    mailBody = System.IO.File.ReadAllText(Server.MapPath(emailTemplateNotification));
                    mailBody = mailBody.Replace("??FIRSTNAME??", Name);
                    mailBody = mailBody.Replace("??EMAIL??", EmailAddress);
                    mailBody = mailBody.Replace("??PHONE??", PhoneNumber);

                    mailBody = mailBody.Replace("??COMMENTS??", AdditionalComment);



                    using (MailMessage mailObjConfirmation = new MailMessage())
                    {
                        mailObjConfirmation.From = new MailAddress(infoMail);
                        mailObjConfirmation.To.Add(new MailAddress(infoMail));
                        mailObjConfirmation.Subject = "New enquiry from the Janper website";
                        mailObjConfirmation.IsBodyHtml = true;
                        mailObjConfirmation.Body = mailBody;

                        SmtpClient SMTPServerConfirmation = new SmtpClient();
                        SMTPServerConfirmation.Host = ConfigurationManager.AppSettings["hostName"].ToString();
                        SMTPServerConfirmation.Send(mailObjConfirmation);
                        //model.successful = true;
                    }
                    //ModelState.AddModelError("Result", StringEnum.GetStringValue(ResponseActivityEnum.Success));
                }
                catch (Exception ex)
                {
                    string errorResponse = ex.Message.ToString();
                    //ModelState.AddModelError("Result", StringEnum.GetStringValue(ResponseActivityEnum.Error));
                }

                return PartialView("_Enquiries", model);
            }
            else
            {
                return PartialView("_Enquiries", model);
            }

        }
    }
}

