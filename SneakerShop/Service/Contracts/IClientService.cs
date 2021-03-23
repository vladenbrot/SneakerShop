using SneakerShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Service.Contracts
{
    public interface IClientService
    {

        void Create(string firstName, string lastName, string telephone, string email, string gender);

        void Delete(int clientId);

        void Edit(int id, string firstName, string lastName, string telephone, string email, string gender);

        IEnumerable<Client> GetAll();

        Client GetById(int id);
    }
}
