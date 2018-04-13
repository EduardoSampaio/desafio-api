using Desafio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Application.Interfaces
{
    public interface IRoleAppService
    {
        void Create(RoleViewModel model);

        void Update(RoleViewModel model);

        void Delete(Guid id);

        IList<RoleViewModel> GetAll();
     }
}