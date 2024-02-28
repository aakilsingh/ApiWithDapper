using ApiWithDapper.Interfaces;
using ApiWithDapper.Models;
using Dapper;
using System.Data;

namespace ApiWithDapper.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnection _dbConnection;

        public ClientRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Client> GetClients()
        {

            //sql injection. use stored procedures. 
            //executing stored procedure with Dapper
            return _dbConnection.Query<Client>("GetAllClients", CommandType.StoredProcedure);

        }
        //return a successful or fail response message, dont return actionresult in your service
        public string CreateClient(Client client)
        {
            if (client is null)
                throw new Exception("Something went wrong");

            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("Username", client.Username);
            dynamicParameters.Add("Password", client.Password);
            var result = _dbConnection.Execute("InsertClient", dynamicParameters, commandType: CommandType.StoredProcedure);

            if (result < 0)
            {
                return "Client Successfully created";
            }
            else
            {
                return "An error occurred";

            }

        }

        public string DeleteClient(int ClientId)
        {
            if (ClientId == 0)
                throw new Exception("Something went wrong exception delete client");
            DynamicParameters dynamicParameters = new DynamicParameters();//use this for parameters
            dynamicParameters.Add("ClientId", ClientId);//
            var result = _dbConnection.Execute("DeleteClient", dynamicParameters, commandType: CommandType.StoredProcedure);

            if (result < 0)
            {
                return "Client successfully deleted";
            }
            else
            {
                return "An error has occurred";
            }


        }

        public string UpdateClientUsername(int clientId, string username)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("ClientId", clientId);
            dynamicParameters.Add("Username", username);
            var result = _dbConnection.Execute("UpdateClientUsername", dynamicParameters, commandType: CommandType.StoredProcedure);
            if (result < 0)
            {
                return "Client username successfully updated";
            }
            else
            {
                return "An error occurred";
            }

        }
        //change return type to string
        public string UpdateClientPassword(int clientId, string password)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("ClientId", clientId);
            dynamicParameters.Add("Password", password);
            var result = _dbConnection.Execute("UpdateClientPassword", dynamicParameters, commandType: CommandType.StoredProcedure);
            if (result < 0)
            {
                return "Client password successfully updated";
            }
            else
            {
                return "An error occurred";
            }

        }
    }
}
