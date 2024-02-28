using ApiWithDapper.Models;

namespace ApiWithDapper.Interfaces
{
    public interface IClientServices
    {
        public IEnumerable<Client> GetAllClients();

        public string AddClient(Client client);
        public string RemoveClient(int ClientId);
        public string ChangeClientUsername(int clientId, string username);
        public string ChangeClientPassword(int clientId, string password);
        public IEnumerable<ClientDetails> GetAllClientDetails();
        public string AddClientDetails(ClientDetails clientDetails);
        public string RemoveClientDetails(int ClientDetailsId);
        public string ChangeClientDetailsAddress(int clientDetailsId, string address);
        public string ChangeClientDetailsCellphone(int clientDetailsId, string cellphone);
    }
}
