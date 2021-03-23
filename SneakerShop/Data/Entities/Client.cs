using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Data.Entities
{
    public class Client : IdentityUser<int>
    {
        public Client(string firstName, string lastName, string telephone, string email, string gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Telephone = telephone;
            Email = email;
            Gender = gender;
        }

        public Client()
        {

        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public ICollection<ClientOrders> ClientsOrders { get; set; }
    }
}
