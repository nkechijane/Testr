﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testr.Infrastructure.EmailModel
{
    public class MailRequest
    {
        public string ToEmail { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string CcEmail { get; set; }

        public string BccEmail { get; set; }

        public List<IFormFile> Attachments { get; set; }
    }
}
