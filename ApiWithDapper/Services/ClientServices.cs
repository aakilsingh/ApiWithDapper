using ApiWithDapper.Interfaces;
using ApiWithDapper.Models;

namespace ApiWithDapper.Services
{
    public class ClientServices : IClientServices
    {
        private IUnitOfWork _uow;

        public ClientServices(IUnitOfWork uow) 
        { 
            _uow = uow;
        }

       // public ClientServices() { }
        
        public IEnumerable<Client> GetAllClients()
        {
            return _uow.Clients.GetClients();
        }

        public string AddClient(Client client)
        {
            return _uow.Clients.CreateClient(client);
        }

        public string RemoveClient(int ClientId)
        {
            return _uow.Clients.DeleteClient(ClientId);
        }

        public string ChangeClientUsername(int clientId, string username)
        {
            return _uow.Clients.UpdateClientUsername(clientId, username);
        }

        public string ChangeClientPassword(int clientId, string password)
        {
            return _uow.Clients.UpdateClientPassword(clientId, password);
        }

        public IEnumerable<ClientDetails> GetAllClientDetails()
        {
            return _uow.ClientDetails.GetClientDetails();
        }

        public string AddClientDetails(ClientDetails clientDetails)
        {
            return _uow.ClientDetails.CreateClientDetails(clientDetails);
        }

        public string RemoveClientDetails(int ClientDetailsId)
        {
           return _uow.ClientDetails.DeleteClientDetails(ClientDetailsId);
        }

        public string ChangeClientDetailsAddress(int clientDetailsId, string address)
        {
            return _uow.ClientDetails.UpdateClientDetailsAddress(clientDetailsId, address);
        }

        public string ChangeClientDetailsCellphone(int clientDetailsId, string cellphone)
        {
            return _uow.ClientDetails.UpdateClientDetailsCellphone(clientDetailsId, cellphone);
        }

        public string RegisterClient(Client Client, ClientDetails ClientDetails)
        {
            //How to insert into 2 tables?
            //Will need to insert Client.ClientId in my ClientDetails db
          var result=  _uow.Clients.CreateClient(Client);
           result+= _uow.ClientDetails.CreateClientDetails(ClientDetails);
            return result;
            
        }
    }
}
