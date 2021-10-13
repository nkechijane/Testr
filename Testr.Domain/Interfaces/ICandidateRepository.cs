using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Domain.Entities;
using Testr.Domain.Interfaces.Base;

namespace Testr.Domain.Interfaces
{
    public interface ICandidateRepository : IRepository<Candidate>
    {
        public Task AddAsync(CandidateRegistrationDTO candidateInfo, ApplicationUser userInfo);
        public Task UpdateAsync(CandidateUpdateProfileDTO candidateProfileUpdate, long id);
    }
}
