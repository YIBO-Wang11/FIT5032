﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Fit_5032_ass.Controllers
{
    public class MailsendingController : Controller
    {
        // GET: SendMailer
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(Fit_5032_ass.Models.Mail objModelMail, HttpPostedFileBase fileUploader)
        {
            if (ModelState.IsValid)
            {
                string from = "1245459735@qq.com";
                using (MailMessage mail = new MailMessage(from, objModelMail.To))
                {
                    mail.Subject = objModelMail.Subject;
                    mail.Body = objModelMail.Body;
                    if (fileUploader != null)
                    {
                        string fileName = Path.GetFileName(fileUploader.FileName);
                        mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                    }
                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.qq.com";
                    smtp.EnableSsl = true;

                    NetworkCredential networkCredential = new NetworkCredential(from, "urpqovfnpvebjchj");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 25;
                    smtp.Send(mail);
                    ViewBag.Message = "Sent";
                    return View("Index", objModelMail);
                }
            }
            else
            {
                return View();
            }
        }
    }
}