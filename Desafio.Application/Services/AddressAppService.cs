using AutoMapper;
using Desafio.Application.Interfaces;
using Desafio.Application.ViewModels;
using Desafio.Domain.DomainEntities;
using Desafio.Domain.Interface;
using System;
using System.Collections.Generic;

namespace Desafio.Application.Services
{
    public class AddressAppService : IAddressAppService
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public AddressAppService(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(AddressRegisterViewModel model)
        {
            _repository.Save(_mapper.Map<Address>(model));
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public IList<AddressViewModel> GetAll()
        {
            return _mapper.Map<IList<AddressViewModel>>(_repository.FindAll());
        }

        public void Update(AddressViewModel model)
        {
            _repository.Update(_mapper.Map<Address>(model));
        }

    }
}