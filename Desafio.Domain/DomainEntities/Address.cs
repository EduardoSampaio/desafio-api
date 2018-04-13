using System;
using System.Collections.Generic;

namespace Desafio.Domain.DomainEntities
{
    public class Address 
    {
        public Address()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; set; }
        public virtual int Number { get;  set; }
        public virtual string Complement { get;  set; }
        public virtual string Neighborhood { get;  set; }
        public virtual string City { get;  set; }
        public virtual string State { get;  set; }
        public virtual string ZipCode { get;  set; }
        public virtual ICollection<User> Users { get;  set; }
    }
}