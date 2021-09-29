﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Testr.API.Controllers
{
    [Route("api/email")]
    [ApiController]    
    public class EmailController : ControllerBase
    {
        [HttpPost]
        [Route("send-email")]
        public async Task SendEmail([FromBody] JObject objData)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(objData["toname"].ToString() + " <" + objData["toemail"].ToString() + ">"));
            message.From = new MailAddress("Amit Mohanty <amitmohanty@email.com>");
            message.Bcc.Add(new MailAddress("Amit Mohanty <amitmohanty@email.com>"));
            message.Subject = objData["subject"].ToString();
            message.Body = createEmailBody(objData["toname"].ToString(), objData["message"].ToString());
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                await smtp.SendMailAsync(message);
                await Task.FromResult(0);
            }
        }

        private string createEmailBody(string userName, string message)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("/htmlTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{message}", message);
            return body;
        }
    }
}
