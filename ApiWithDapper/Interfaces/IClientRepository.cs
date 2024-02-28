using ApiWithDapper.Models;

namespace ApiWithDapper.Interfaces
{
    public interface IClientRepository
    {
        public IEnumerable<Client> GetClients();


        public string CreateClient(Client client);


        public string DeleteClient(int ClientId);


        public string UpdateClientUsername(int clientId, string username);


        public string UpdateClientPassword(int clientId, string password);
    }
}
