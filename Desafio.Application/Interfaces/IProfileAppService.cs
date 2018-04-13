using Desafio.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Desafio.Application.Interfaces
{
    public interface IProfileAppService
    {
        void Create(ProfileViewModel model);

        void Update(ProfileViewModel model);

        void Delete(Guid id);

        IList<ProfileViewModel> GetAllProfileRoleById(Guid Id);
    }
}