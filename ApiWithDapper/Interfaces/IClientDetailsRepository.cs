using ApiWithDapper.Models;

namespace ApiWithDapper.Interfaces
{
    public interface IClientDetailsRepository
    {
        public IEnumerable<ClientDetails> GetClientDetails();

        public string CreateClientDetails(ClientDetails clientDetails);

        public string DeleteClientDetails(int ClientDetailsId);

        public string UpdateClientDetailsAddress(int clientId, string address);

        public string UpdateClientDetailsCellphone(int clientId, string cellphone);
    }
}
