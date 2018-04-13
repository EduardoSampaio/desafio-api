using System;
using System.Collections.Generic;

namespace Desafio.Domain.DomainEntities
{
    public class Profile
    {
        public Profile()
        {
            Id = Guid.NewGuid();
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<ProfileRole> ProfileRoles { get; set; }
    }
}