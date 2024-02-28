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
            var result = _clientServices.AddClientDetails(clientDetails);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult DeleteClientDetails(int ClientDetailsId)
        {
            var result = _clientServices.RemoveClientDetails(ClientDetailsId);
            return  Ok(result);
        }

        [Route("UpdateClientDetails/Address")]
        [HttpPatch]
        public ActionResult UpdateClientDetailsAddress(int clientDetailsId,string address)
        {
           var result= _clientServices.ChangeClientDetailsAddress(clientDetailsId,address);
            return Ok(result);
        }

        [Route("UpdateClientDetails/Cellphone")]
        [HttpPatch]
        public ActionResult UpdateClientDetailsCellphone(int clientDetailsId, string cellphone)
        {
            var result = _clientServices.ChangeClientDetailsCellphone(clientDetailsId,cellphone);   
            return Ok(result);
        }
    }
  
}
