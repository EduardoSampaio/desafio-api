using System;

namespace Desafio.Application.ViewModels
{
    public class UserRegisterViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public Guid ProfileId { get; set; }
        public  bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
    }

    public class UserUpdateViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }   
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public Guid ProfileId { get; set; }
    }

    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public Guid ProfileId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public AddressViewModel Address { get; set; }
        public ProfileViewModel Profile { get; set; }
    }
}