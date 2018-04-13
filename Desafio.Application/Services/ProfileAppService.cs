using AutoMapper;
using Desafio.Application.Interfaces;
using Desafio.Application.ViewModels;
using Desafio.Domain.Interface;
using System;
using System.Collections.Generic;

namespace Desafio.Application.Services
{
    public class ProfileAppService : IProfileAppService
    {
        private readonly IProfileRepository _repository;
        private readonly IMapper _mapper;

        public ProfileAppService(IProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(ProfileViewModel model)
        {
            _repository.Save(_mapper.Map<Domain.DomainEntities.Profile>(model));
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public IList<ProfileViewModel> GetAllProfileRoleById(Guid id)
        {
            //return _mapper.Map<IList<ProfileViewModel>>(_repository.FindProfileRoleById(id));
            return null;    
        }

        public void Update(ProfileViewModel model)
        {
            _repository.Update(_mapper.Map<Domain.DomainEntities.Profile>(model));
        }
    }
}