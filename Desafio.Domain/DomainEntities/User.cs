using System;

namespace Desafio.Domain.DomainEntities
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual int Age { get; set; }
        public virtual string Nationality { get; set; }
        public virtual string Phone { get; set; }
        public virtual string CellPhone { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
        public virtual Guid CreatedBy { get; set; }
        public virtual DateTime? DeletedAt { get; set; }
        public virtual Guid DeletedBy { get; set; }
        public virtual Guid AddressId { get; set; }
        public virtual Guid ProfileId { get; set; }
        public virtual Address Address { get; set; }
        public virtual Profile Profile { get; set; }

    }
}