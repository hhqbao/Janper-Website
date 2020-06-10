using JanperWebsite.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IdacsPLUS.Controllers
{
    public class EnquiriesController : Controller
    {
        private readonly string _systemEmail = ConfigurationManager.AppSettings["infoMail"];
        private readonly string _receptionEmail = ConfigurationManager.AppSettings["ReceptionEmail"];
        private readonly SmtpClient _smtpClient;

        public EnquiriesController()
        {
            _smtpClient = new SmtpClient(ConfigurationManager.AppSettings["hostName"]);
        }

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
            const string secretKey = "6LdaXkAUAAAAAKkYNn1fynKmAI2MK4PRTmJ2lLHB";

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
                try
                {
                    //Email to customer
                    await EmailToCustomerAsync(model);

                    //email to staff
                    await EmailToStaffAsync(model);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return PartialView("_Enquiries", model);
            }
            else
            {
                return PartialView("_Enquiries", model);
            }

        }

        private async Task EmailToCustomerAsync(Model_Contact model)
        {
            var mailBody = System.IO.File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["templateConfirmation"]));
            mailBody = mailBody.Replace("??FIRSTNAME??", model.Name);

            using (var message = new MailMessage(_systemEmail, model.Email))
            {
                message.Sender = new MailAddress(_systemEmail);
                message.Subject = "Your enquiry on the Janper website";
                message.IsBodyHtml = true;
                message.Body = mailBody;
                await _smtpClient.SendMailAsync(message);
            }
        }

        private async Task EmailToStaffAsync(Model_Contact model)
        {
            var mailBody = System.IO.File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["templateNotification"]));
            mailBody = mailBody.Replace("??FIRSTNAME??", model.Name);
            mailBody = mailBody.Replace("??EMAIL??", model.Email);
            mailBody = mailBody.Replace("??PHONE??", model.Phone);
            mailBody = mailBody.Replace("??COMMENTS??", model.AdditionalComments);


            using (var message = new MailMessage(_systemEmail, _receptionEmail))
            {
                message.Subject = "New enquiry from the Janper website";
                message.IsBodyHtml = true;
                message.Body = mailBody;

                await _smtpClient.SendMailAsync(message);
            }
        }
    }
}

