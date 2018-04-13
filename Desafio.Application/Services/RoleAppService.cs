using AutoMapper;
using Desafio.Application.Interfaces;
using Desafio.Application.ViewModels;
using Desafio.Domain.DomainEntities;
using Desafio.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Application.Services
{
    public class RoleAppService : IRoleAppService
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;

        public RoleAppService(IRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(RoleViewModel model)
        {
            _repository.Save(_mapper.Map<Role>(model));
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public IList<RoleViewModel> GetAll()
        {
            return _mapper.Map<IList<RoleViewModel>>(_repository.FindAll());
        }

        public void Update(RoleViewModel model)
        {
            _repository.Update(_mapper.Map<Role>(model));
        }
    }
}