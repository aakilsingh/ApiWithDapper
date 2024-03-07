using ApiWithDapper.Interfaces;
using ApiWithDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ApiWithDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientDetailsController : ControllerBase
    {
        
       // private readonly IClientDetailsService _clientDetailsService;
        private readonly IClientServices _clientServices;
        public ClientDetailsController(IClientServices clientServices) 
        {
            
            
            _clientServices = clientServices;
        }

        [HttpGet]
        public IEnumerable<ClientDetails> GetClientDetails()
        {
            return _clientServices.GetAllClientDetails();
        }

        [HttpPost]
        public ActionResult<ClientDetails> CreateClientDetails(ClientDetails clientDetails)
        {
            try
            {
                var result = _clientServices.AddClientDetails(clientDetails);
                return Ok(result);
            }
            catch (Exception e)
            {

                var x = new ObjectResult(e.Message);
                x.StatusCode = 500;
                return x;
            }
            
        }

        [HttpDelete]
        public ActionResult DeleteClientDetails(int ClientDetailsId)
        {
            try
            {
                var result = _clientServices.RemoveClientDetails(ClientDetailsId);
                return Ok(result);
            }
            catch (Exception e)
            {

                var x = new ObjectResult(e.Message);
                x.StatusCode = 500;
                return x;
            }
           
        }

        [Route("UpdateClientDetails/Address")]
        [HttpPatch]
        public ActionResult UpdateClientDetailsAddress(int clientDetailsId,string address)
        {
            try
            {
                var result = _clientServices.ChangeClientDetailsAddress(clientDetailsId, address);
                return Ok(result);
            }
            catch (Exception e)
            {

                var x = new ObjectResult(e.Message);
                x.StatusCode = 500;
                return x;
            }
           
        }

        [Route("UpdateClientDetails/Cellphone")]
        [HttpPatch]
        public ActionResult UpdateClientDetailsCellphone(int clientDetailsId, string cellphone)
        {
            try
            {
                var result = _clientServices.ChangeClientDetailsCellphone(clientDetailsId, cellphone);
                return Ok(result);
            }
            catch (Exception e)
            {

                var x = new ObjectResult(e.Message);
                x.StatusCode = 500;
                return x;
            }
            
        }
    }
  
}
