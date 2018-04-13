using AutoMapper;
using Desafio.Application.Interfaces;
using Desafio.Application.ViewModels;
using Desafio.Domain.DomainEntities;
using Desafio.Domain.Interface;
using System;

namespace Desafio.Application.Services
{
    public class ProfileRoleAppService : IProfileRoleAppService
    {
        private readonly IProfileRoleRepository _repository;
        private readonly IMapper _mapper;

        public ProfileRoleAppService(IProfileRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(ProfileRoleViewModel model)
        {
            _repository.Save(_mapper.Map<ProfileRole>(model));
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}