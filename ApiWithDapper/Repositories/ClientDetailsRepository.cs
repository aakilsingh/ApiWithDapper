using ApiWithDapper.Interfaces;
using ApiWithDapper.Models;
using Dapper;
using System.Data;

namespace ApiWithDapper.Repositories
{
    public class ClientDetailsRepository : IClientDetailsRepository
    {
        private readonly IDbConnection _dbConnection;

        public ClientDetailsRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //all logic here

        //done
        public IEnumerable<ClientDetails> GetClientDetails()
        {
            //stored procedure created
            return _dbConnection.Query<ClientDetails>("GetAllClientDetails", commandType: CommandType.StoredProcedure);
        }

        //done
        public string CreateClientDetails(ClientDetails clientDetails)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("FirstName", clientDetails.FirstName);
            dynamicParameters.Add("LastName", clientDetails.LastName);
            dynamicParameters.Add("Address", clientDetails.Address);
            dynamicParameters.Add("Cellphone", clientDetails.Cellphone);
            dynamicParameters.Add("ClientId", clientDetails.ClientId);

            var result = _dbConnection.Execute("InsertClientDetails", dynamicParameters, commandType: CommandType.StoredProcedure);
            //SET NOCOUNT OFF;
            if (result > 0)
            {
                return "Client details created successfully";
            }
            else
            {
                throw new Exception("An error has occured"); 
            }
        }

        //done
        public string DeleteClientDetails(int ClientDetailsId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("ClientDetailsId", ClientDetailsId);
            var result = _dbConnection.Execute("DeleteClientDetails", dynamicParameters, commandType: CommandType.StoredProcedure);
            //SET NOCOUNT OFF;
            if (result > 0)
            {
                return "Client details successfully deleted";
            }
            else
            {
                throw new Exception("An error has occurred");
            }
        }


        //done
        public string UpdateClientDetailsAddress(int clientDetailsId, string address)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("ClientDetailsId", clientDetailsId);
            dynamicParameters.Add("Address", address);
            var result = _dbConnection.Execute("UpdateClientDetailsAddress", dynamicParameters, commandType: CommandType.StoredProcedure);
            //SET NOCOUNT OFF; 
            if (result > 0)
            {
                return "Client address updated successfully";
            }
            else
            {
                throw new Exception("An error has occurred");
            }


        }

        public string UpdateClientDetailsCellphone(int clientDetailsId, string cellphone)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("ClientDetailsId", clientDetailsId);
            dynamicParameters.Add("Cellphone", cellphone);
            var result = _dbConnection.Execute("UpdateClientDetailsCellphone", dynamicParameters, commandType: CommandType.StoredProcedure);
            //SET NOCOUNT OFF;
            if (result > 0)
            {
                return "Client cellphone number successfully updated";
            }
            else
            {
                throw new Exception("An error has occurred");
            }
        }
    }
}
