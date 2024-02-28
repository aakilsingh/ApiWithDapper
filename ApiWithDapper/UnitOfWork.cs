using ApiWithDapper.Interfaces;

namespace ApiWithDapper
{
    public class UnitOfWork : IUnitOfWork
    {
        private IClientRepository _clientRepository;
        private IClientDetailsRepository _clientDetailsRepository;

        public UnitOfWork(IClientRepository clientRepository, IClientDetailsRepository clientDetailsRepository)
        {
            _clientRepository = clientRepository;
            _clientDetailsRepository = clientDetailsRepository;
        }

        public IClientRepository Clients 
        { 
            get 
            {  
                return _clientRepository; 
            } 
        }

        public IClientDetailsRepository ClientDetails 
        { 
            get 
            { return _clientDetailsRepository; 
            } 
        }
    }
}
