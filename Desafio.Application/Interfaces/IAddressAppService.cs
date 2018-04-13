using Desafio.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Desafio.Application.Interfaces
{
    public interface IAddressAppService
    {
        void Create(AddressRegisterViewModel model);

        void Update(AddressViewModel model);

        void Delete(Guid id);

        IList<AddressViewModel> GetAll();
    }
}