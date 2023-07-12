//using System;
//using System.Data;
//using System.Configuration;
//using System.Linq;
//using System.Web;
//using System.Xml.Linq;
//using DnsClient;

//namespace WEBSITE.Controllers
//{
//    public class SendMail
//    {
//        public string FromName { get; set; }
//        public string FromEmail { get; set; }
//        public string ReplyToEmail { get; set; }
//        public string ReplyToName { get; set; }

//        public string Subject { get; set; }
//        public string[] FileName { get; set; }
//        public string Body { get; set; }

//        public string ToName { get; set; }
//        public string CcName { get; set; }
//        public string BccName { get; set; }

//        public string ToEmail { get; set; }
//        public string CcEmail { get; set; }
//        public string BccEmail { get; set; }
//        public bool HtmlFormat { get; set; }
//        public bool IsFileMemoryStream { get; set; }



//        public SendMail()
//        {
           
//        }

//        public string send(string Company = "")
//        {
//            //Logging.logData mylog = new Logging.logData();

//            try
//            {
//                string smtpServer = ConfigurationManager.AppSettings["smtpServer"];
//                string mUser = _config.GetValue<string>("Smtp:Server", "defaultmailserver");
//                string mPassword = ConfigurationManager.AppSettings["defaultMailPass"];
//                string portNo = ConfigurationManager.AppSettings["smtpPort"];
//                string isSSL = ConfigurationManager.AppSettings["defaultMailSSL"];

//                if (FromEmail == null) FromEmail = ConfigurationManager.AppSettings["defaultMail"];
//                if (portNo == "")
//                    portNo = "25";

//                bool SSLEnabled = false;
//                bool.TryParse(isSSL, out SSLEnabled);

//                //single dimension array
//                ToName = "";
//                CcName = "";
//                BccName = "";

               

//                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(smtpServer);
//                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

//                msg.IsBodyHtml = HtmlFormat;
//                msg.Subject = Subject;
//                msg.Body = Body;

//                if (FileName != null)
//                {
//                    foreach (string str in FileName)
//                    {
                        
//                        if (str.ToString() != "")
//                        {
//                            Console.WriteLine("File attached - " + str);
//                            msg.Attachments.Add(new System.Net.Mail.Attachment(str.ToString()));
//                        }
//                    }
//                }
                
//                msg.From = new System.Net.Mail.MailAddress(FromEmail, FromName);

//                #region ToMails
//                if (ToEmail != "" && !string.IsNullOrEmpty(ToEmail))
//                {
//                    string[] recipientsTo = ToEmail.Split(',');
//                    if (recipientsTo.Length > 0)
//                    {
//                        for (int i = 0; i <= recipientsTo.Length - 1; i++)
//                        {
//                            if (recipientsTo[i].ToString().Length > 0)
//                                msg.To.Add(new System.Net.Mail.MailAddress(recipientsTo[i].ToString(), ToName));
//                        }
//                    }
//                    else
//                    {
//                        msg.To.Add(new System.Net.Mail.MailAddress(ToEmail, ToName));
//                    }
//                }
//                #endregion

//                #region CcMails
//                if (CcEmail != "" && !string.IsNullOrEmpty(CcEmail))
//                {
//                    string[] recipientsCc = CcEmail.Split(',');
//                    if (recipientsCc.Length > 0)
//                    {
//                        for (int i = 0; i <= recipientsCc.Length - 1; i++)
//                            msg.CC.Add(new System.Net.Mail.MailAddress(recipientsCc[i].ToString(), ToName));
//                    }
//                    else
//                    {
//                        msg.CC.Add(new System.Net.Mail.MailAddress(CcEmail, CcName));
//                    }
//                }
//                #endregion

//                #region BccMails
//                if (BccEmail != "" && !string.IsNullOrEmpty(BccEmail))
//                {
//                    string[] recipientsBcc = BccEmail.Split(',');
//                    if (recipientsBcc.Length > 0)
//                    {
//                        for (int i = 0; i <= recipientsBcc.Length - 1; i++)
//                            msg.Bcc.Add(new System.Net.Mail.MailAddress(recipientsBcc[i].ToString(), ToName));
//                    }
//                    else
//                    {
//                        msg.Bcc.Add(new System.Net.Mail.MailAddress(BccEmail, BccName));
//                    }
//                }
//                #endregion

//                System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(mUser, mPassword);
//                smtp.Port = int.Parse(portNo);
//                smtp.Credentials = basicAuthenticationInfo;
//                smtp.EnableSsl = SSLEnabled;
//                smtp.Send(msg);
//                msg = null;
//                smtp = null;
//                return "Mail sent.";
//            }
//            catch (Exception ex)
//            {
//                //mylog.LogTxt("", "sendMail", "", ex, "ReportConsole", "SYSTEM");
//                return ex.ToString();
//            }
//        }

//    }
//}


