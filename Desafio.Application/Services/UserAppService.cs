using AutoMapper;
using Desafio.Application.Interfaces;
using Desafio.Application.ViewModels;
using Desafio.Domain.DomainEntities;
using Desafio.Domain.Repository;
using Desafio.Infra.CrossCutting.Security;
using System;
using System.Collections.Generic;

namespace Desafio.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserAppService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserViewModel Authenticate(string login, string password)
        {
            return _mapper.Map<UserViewModel>(_repository.Authenticate(login, password));
        }

        public void ChangeStatus(Guid id, Guid deleteBy)
        {
            var user = _repository.FindById(id);
            user.IsActive = !user.IsActive;
            user.DeletedAt = DateTime.Now;
            user.DeletedBy = deleteBy;
            _repository.Update(user);
        }

        public void Create(UserRegisterViewModel model)
        {
            model.Password = Md5Cryptography.GetMd5Hash(model.Password);
            model.CreatedAt = DateTime.Now;
            model.IsActive = true;
            _repository.Save(_mapper.Map<User>(model));
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public UserViewModel FindById(Guid id)
        {
            return _mapper.Map<UserViewModel>(_repository.FindById(id));
        }

        public IList<UserViewModel> GetAll()
        {
            return _mapper.Map<IList<UserViewModel>>(_repository.FindAll());
        }

        public IList<UserViewModel> GetUserAndAddress(Guid id)
        {
            return _mapper.Map<IList<UserViewModel>>(_repository.FindUserAddressById(id));
        }

        public bool HasEmail(string email)
        {
            return _repository.HasEmail(email);
        }

        public bool HasLogin(string login)
        {
            return _repository.HasLogin(login);
        }

        public void Update(UserUpdateViewModel model)
        {
            var user = _repository.FindById(model.Id);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Cpf = model.Cpf;
            user.Age = model.Age;
            user.Nationality = model.Nationality;
            user.CellPhone = model.CellPhone;
            user.Phone = model.Phone;
            user.ProfileId = model.ProfileId;
            _repository.Update(user);
        }

   
        public IList<UserViewModel> GetAllUserProfile()
        {
            return _mapper.Map<IList<UserViewModel>>(_repository.FindAllUserProfile());
        }
    }
}
