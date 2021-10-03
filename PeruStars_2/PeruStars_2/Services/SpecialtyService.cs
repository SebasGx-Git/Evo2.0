﻿using PeruStars_2.Domain.Models;
using PeruStars_2.Domain.Persistence.Repositories;
using PeruStars_2.Domain.Services;
using PeruStars_2.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeruStars_2.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IInterestRepository _interestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SpecialtyService(ISpecialtyRepository specialtyRepository, IUnitOfWork unitOfWork, IInterestRepository interestRepository)
        {
            _specialtyRepository = specialtyRepository;
            _unitOfWork = unitOfWork;
            _interestRepository = interestRepository;
        }

        public async Task<SpecialtyResponse> GetByIdAsync(long specialtyId)
        {
            var existingSpecialty = await _specialtyRepository.FindById(specialtyId);
            if (existingSpecialty == null)
                return new SpecialtyResponse("Specialty not found");
            return new SpecialtyResponse(existingSpecialty);
        }

        public async Task<IEnumerable<Specialty>> ListAsync()
        {
            return await _specialtyRepository.ListAsync();
        }

        public async Task<IEnumerable<Specialty>> ListByHobbyistIdAsync(int hobbyistId)
        {
            var interests = await _interestRepository.ListByHobbyistIdAsync(hobbyistId);
            var specialties = interests.Select(i => i.Specialty).ToList();
            return specialties;
        }
    }
}