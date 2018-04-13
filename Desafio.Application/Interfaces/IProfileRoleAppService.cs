using Desafio.Application.ViewModels;
using System;

namespace Desafio.Application.Interfaces
{
    public interface IProfileRoleAppService
    {
        void Create(ProfileRoleViewModel model);

        void Delete(Guid id);
    }
}