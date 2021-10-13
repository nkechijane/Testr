using System;
using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Domain.Entities;
using Testr.Domain.Interfaces;
using Testr.Infrastructure.Authentication;

namespace Testr.Infrastructure.Repositories
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        private readonly AppDbContext _context;

        public CandidateRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task AddAsync(CandidateRegistrationDTO candidateInfo, ApplicationUser userInfo)
        {
            Candidate candidateData = new Candidate()
            {
                FirstName = candidateInfo.FirstName,
                AcademicQualification = candidateInfo.AcademicQualification,
                CountryOfOrigin = candidateInfo.CountryOfOrigin,
                DateOfBirth = candidateInfo.DateOfBirth,
                DateRegistered = DateTime.Now,
                EmailAddress = candidateInfo.EmailAddress,
                Gender = candidateInfo.Gender,
                GitHubUrl = candidateInfo.GitHubUrl,
                IsActive = true,
                LastName = candidateInfo.LastName,
                LinkedInUrl = candidateInfo.LinkedInUrl,
                MiddleName = candidateInfo.MiddleName,
                NYSCCompleted = candidateInfo.NYSCCompleted,
                PhoneNumber1 = candidateInfo.PhoneNumber1,
                PhoneNumber2 = candidateInfo.PhoneNumber2,
                PhotoUrl = candidateInfo.PhotoUrl,
                ResidentialAddress = candidateInfo.ResidentialAddress,
                ResumeUrl = candidateInfo.ResumeUrl,
                StateOfOrigin = candidateInfo.StateOfOrigin,
                User = userInfo
            };

            await _context.Candidates.AddAsync(candidateData);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CandidateUpdateProfileDTO candidateProfileUpdate, long id)
        {
            var candidateUpdate = await _context.Candidates.FindAsync(id);
        
            candidateUpdate.FirstName = candidateProfileUpdate.FirstName;
            candidateUpdate.LastName = candidateProfileUpdate.LastName;
            candidateUpdate.MiddleName = candidateProfileUpdate.MiddleName;
            candidateUpdate.EmailAddress = candidateProfileUpdate.EmailAddress;
            candidateUpdate.DateOfBirth = candidateProfileUpdate.DateOfBirth;
            candidateUpdate.PhoneNumber1 = candidateProfileUpdate.PhoneNumber1;
            candidateUpdate.PhoneNumber2 = candidateProfileUpdate.PhoneNumber2;
            candidateUpdate.ResidentialAddress = candidateProfileUpdate.ResidentialAddress;
            candidateUpdate.StateOfOrigin = candidateProfileUpdate.StateOfOrigin;
            candidateUpdate.Gender = candidateProfileUpdate.Gender;
            candidateUpdate.CountryOfOrigin = candidateProfileUpdate.CountryOfOrigin;
            candidateUpdate.PhotoUrl = candidateProfileUpdate.PhotoUrl;
            candidateUpdate.AcademicQualification = candidateProfileUpdate.AcademicQualification;
            candidateUpdate.NYSCCompleted = candidateProfileUpdate.NYSCCompleted;
            candidateUpdate.LinkedInUrl = candidateProfileUpdate.LinkedInUrl;
            candidateUpdate.ResumeUrl = candidateProfileUpdate.ResumeUrl;
            candidateUpdate.GitHubUrl = candidateProfileUpdate.GitHubUrl;
            candidateUpdate.LastModified = DateTime.Now;

            _context.Candidates.Update(candidateUpdate);
            await _context.SaveChangesAsync();
        }

    
    }
}
