using System;

namespace Desafio.Domain.DomainEntities
{
    public class ProfileRole
    {
        public ProfileRole()
        {
            Id = Guid.NewGuid();
        }
        public virtual Guid Id { get; set; }
        public virtual Guid ProfileId { get; set; }
        public virtual Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Profile Profile { get; set; }
    }
}