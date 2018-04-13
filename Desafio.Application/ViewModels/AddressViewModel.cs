using System;

namespace Desafio.Application.ViewModels
{
    public class AddressRegisterViewModel
    {   
        public virtual int Number { get; set; }
        public virtual string Complement { get; set; }
        public virtual string Neighborhood { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }
    }

    public class AddressViewModel
    {
        public Guid Id { get; set; }
        public virtual int Number { get; set; }
        public virtual string Complement { get; set; }
        public virtual string Neighborhood { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }
    }
}