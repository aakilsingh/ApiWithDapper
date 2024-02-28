namespace ApiWithDapper.Interfaces
{
    public interface IUnitOfWork
    {
        public IClientRepository Clients { get; }
        public IClientDetailsRepository ClientDetails { get; }
    }
}
