using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testr.Domain.Base;
using Testr.Domain.Entities;

namespace Testr.Domain.DTOs
{
    public class CandidateUpdateProfileDTO : CandidateBase
    {
        public DateTime LastModified { get; set; }
    }
}
