using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Models.ClientViewModels
{
    public class ClientViewModel
    {
        public ClientViewModel (int id, string firstName, string lastName, string telephone, string email, string gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Telephone = telephone;
            Email = email;
            Gender = gender;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}
