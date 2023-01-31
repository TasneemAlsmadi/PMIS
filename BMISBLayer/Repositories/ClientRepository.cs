using BMISBLayer.Entities;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMISBLayer.Repositories
{
    public class ClientRepository :IClientRepository
    {
        private readonly ApplicationDbContext context;
        public ClientRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<Client> GetAllClient()
        {
            return context.Clients.ToList();
        }
        public Client GetClient(int ClientId)
        {
            return context.Clients.SingleOrDefault(x => x.ClientId == ClientId);
        }
        public void DeleteClient(int ClientId)
        {
            var p = context.Clients.SingleOrDefault(x => x.ClientId == ClientId);
            context.Remove(p);
            context.SaveChanges();
        }

        public void EditClient(Client p)
        {
            context.Clients.Update(p);
            context.SaveChanges();
        }
        public void InsertClient(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }

    }
}
