using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JanperWebsite.Models;
using System.Web.Script.Serialization;
using JanperWebsite.PhysicalAccessPaths;
using System.Xml.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace JanperWebsite.Controllers
{
    public class TradeAreaController : Controller
    {
        // GET: TradeView
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TradeArea()
        {
            return View(new Model_TradeContact());
        }

        [HttpPost]
        public ActionResult SendRequest(Model_TradeContact formData)
        {
            if(IsHuman())
            {
                SendEmail(formData);
                ModelState.Clear();
                return View("TradeArea", formData);
            }
            else
            {
                ModelState.Clear();
                return View("TradeArea", formData);
            }

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


        private void SendEmail(Model_TradeContact formData)
        {
            if (ModelState.IsValid /*&& model.TermsAndConditions*/)
            {
                var SupaMattList = new List<string>();
                var TextureSamples = new List<string>();
                var WoodgrainsList = new List<string>();
                var SatinList = new List<string>();
                var GlossPremiumSamples = new List<string>();

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<String> sampleList = (List<string>)serializer.Deserialize(formData.samples, typeof(List<string>));

                string samples = "";


                foreach (string list in sampleList)
                {
                    if (list != "")
                    {
                        samples = (samples + list);
                    }
                }

                string infoMail = ConfigurationManager.AppSettings["infoMail"].ToString();
                string emailTemplateConfirmation = ConfigurationManager.AppSettings["SampleRequestConfirmation"].ToString();
                string emailTemplateNotification = ConfigurationManager.AppSettings["SampleRequestNotification"].ToString();
                string mailBody = string.Empty;

                string Name = formData.CustomerName;
                string EmailAddress = formData.Email + " ";
                string Address = formData.Address + " ";
                string Suburb = formData.Suburb + " ";
                string State = formData.State + " ";
                string PostCode = formData.pCode + " ";

                try
                {
                    //Email to customer
                    mailBody = System.IO.File.ReadAllText(Server.MapPath(emailTemplateConfirmation));
                    mailBody = mailBody.Replace("??FIRSTNAME??", Name);

                    using (MailMessage mailObjConfirmation = new MailMessage())
                    {
                        mailObjConfirmation.From = new MailAddress(infoMail);
                        mailObjConfirmation.To.Add(new MailAddress(EmailAddress));
                        mailObjConfirmation.Subject = "Your sample request on the Janper website";
                        mailObjConfirmation.IsBodyHtml = true;
                        mailObjConfirmation.Body = mailBody;
                        mailObjConfirmation.Sender = new MailAddress(infoMail);
                        SmtpClient SMTPServerConfirmation = new SmtpClient();
                        SMTPServerConfirmation.Host = ConfigurationManager.AppSettings["hostName"].ToString();
                        //SMTPServerConfirmation.Credentials = new NetworkCredential("leasep-2", "ujemib00");
                        SMTPServerConfirmation.Send(mailObjConfirmation);
                    }
                    //email to staff
                    mailBody = System.IO.File.ReadAllText(Server.MapPath(emailTemplateNotification));
                    mailBody = mailBody.Replace("??FIRSTNAME??", Name);
                    mailBody = mailBody.Replace("??EMAIL??", EmailAddress);
                    mailBody = mailBody.Replace("??ADDRESS??", (Address + Suburb + PostCode + State));
                    mailBody = mailBody.Replace("??COMMENTS??", samples);



                    using (MailMessage mailObjConfirmation = new MailMessage())
                    {
                        mailObjConfirmation.From = new MailAddress(infoMail);
                        mailObjConfirmation.To.Add(new MailAddress(infoMail));
                        mailObjConfirmation.Subject = "New sample request from the Janper website";
                        mailObjConfirmation.IsBodyHtml = true;
                        mailObjConfirmation.Body = mailBody;

                        SmtpClient SMTPServerConfirmation = new SmtpClient();
                        SMTPServerConfirmation.Host = ConfigurationManager.AppSettings["hostName"].ToString();
                        SMTPServerConfirmation.Send(mailObjConfirmation);
                        formData.Successful = true;
                    }
                }
                catch (Exception ex)
                {
                    string errorResponse = ex.Message.ToString();
                }
            }
        }
    }
}