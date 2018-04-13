using Desafio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Application.Interfaces
{
    public interface IUserAppService
    {
        void Create(UserRegisterViewModel model);

        void Update(UserUpdateViewModel model);

        void Delete(Guid id);

        void ChangeStatus(Guid id,Guid deleteBy);

        IList<UserViewModel> GetAll();

        IList<UserViewModel> GetUserAndAddress(Guid id);

        IList<UserViewModel> GetAllUserProfile();

        UserViewModel FindById(Guid id);

        bool HasEmail(string email);

        bool HasLogin(string login);

        UserViewModel Authenticate(string login, string password);
        
    }
}