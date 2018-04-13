using System;

namespace Desafio.Application.ViewModels
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}