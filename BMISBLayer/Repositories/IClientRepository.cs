using BMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMISBLayer.Repositories
{
    public interface IClientRepository
    {
        List<Client> GetAllClient();
        Client GetClient(int ClientId);
        void DeleteClient(int ClientId);
        void EditClient(Client p);
        void InsertClient(Client client);
    }
}
