using WebApp.Models.Entities;

namespace WebApp.ViewModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public static implicit operator UserEntity(RegisterViewModel model)
        {
            return new UserEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
            };
        }

        public static implicit operator AddressEntity(RegisterViewModel model)
        {
            return new AddressEntity
            {
                StreetName = model.StreetName,
                PostalCode = model.PostalCode,
                City = model.City,
            };
        }
    }
}
