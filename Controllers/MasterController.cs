using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace WEBSITE.Controllers
{
    public class MasterController : Controller
    {
        private IConfiguration Configuration;
        public MasterController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Service()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Contact(string name, string email, string subject, string message)
        {
            if(name != "" && name != null)
            {
                if (email != "" && email != null)
                {
                    if (subject != "" && subject != null)
                    {
                        if (message != "" && message != null)
                        {
                            StringBuilder sb = new StringBuilder();

                            sb.AppendLine("<html>");
                            sb.AppendLine("<body>");
                            sb.AppendLine(@"<table style='padding: 10px; font-family: Verdana; font-size:11px;
                        border-style:solid;border-width:1px;border-color:grey;'> ");

                            sb.AppendLine("<tr>");
                            sb.AppendLine("<td style='font-weight:bold;background-color:black;color:white;'>" + "User Name" + "</td>");
                            sb.AppendLine("<td style='font-weight:bold;background-color:black;color:white;'>" + "User MailId" + "</td>");
                            sb.AppendLine("</tr>");

                            sb.AppendLine("<tr>");
                            sb.AppendLine("<td style='text-align;left;'>" + name.ToString() + "</td>");
                            sb.AppendLine("<td style='text-align;left;'>" + email.ToString() + "</td>");
                            sb.AppendLine("</tr>");

                            sb.AppendLine("</table>");

                            sb.AppendLine("<br>");
                            sb.AppendLine("<tr>");
                            sb.AppendLine("<td style='text-align;left;'>" + message.ToString() + "</td>");
                            sb.AppendLine("</tr>");


                            sb.AppendLine("</body>");
                            sb.AppendLine("</html>");

                            string host = this.Configuration.GetValue<string>("Smtp:Server");
                            int port = this.Configuration.GetValue<int>("Smtp:Port");
                            string fromAddress = this.Configuration.GetValue<string>("Smtp:FromAddress");
                            string userName = this.Configuration.GetValue<string>("Smtp:UserName");
                            string password = this.Configuration.GetValue<string>("Smtp:Password");
                            string ToAddress = this.Configuration.GetValue<string>("Smtp:ToAddress");

                            using (MailMessage mm = new MailMessage())
                            {
                                mm.From = new MailAddress(fromAddress);
                                mm.To.Add(ToAddress);
                                mm.Subject = subject;
                                mm.Body = sb.ToString();
                                mm.IsBodyHtml = true;
                                using (SmtpClient smtp = new SmtpClient())
                                {
                                    smtp.Host = host;
                                    smtp.EnableSsl = true;
                                    NetworkCredential NetworkCred = new NetworkCredential(userName, password);
                                    smtp.UseDefaultCredentials = false;
                                    smtp.Credentials = NetworkCred;
                                    smtp.Port = port;
                                    smtp.Send(mm);
                                }
                            }
                        }
                        else
                        {
                            ViewBag.Message = string.Format("Message cannot be empty");

                        }
                    }
                    else
                    {
                        ViewBag.Message = string.Format("Subject cannot be empty");

                    }
                }
                else
                {
                    ViewBag.Message = string.Format("Email cannot be empty");
                    return View();
                }
            }

            else
            {
                ViewBag.Message = string.Format("Full Name cannot be empty");
                return View();
            }
            
            

            return View();
        }

    }


    //public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    //{
    //    MailMessage message = new MailMessage();
    //    message.Subject = subject;
    //    message.Body = htmlMessage;
    //    message.IsBodyHtml = true;
    //    message.To.Add(email);

    //    string host = _config.GetValue<string>("Smtp:Server", "defaultmailserver");
    //    int port = _config.GetValue<int>("Smtp:Port", 25);
    //    string fromAddress = _config.GetValue<string>("Smtp:FromAddress", "defaultfromaddress");

    //    message.From = new MailAddress(fromAddress);

    //    using (var smtpClient = new SmtpClient(host, port))
    //    {
    //        await smtpClient.SendMailAsync(message);
    //    }
    //}



}
