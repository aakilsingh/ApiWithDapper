using ApiWithDapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;
using ApiWithDapper.Interfaces;
using ApiWithDapper.Services;

namespace ApiWithDapper.Controllers
{
    //commented out is the logic i previously had in this controller
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        //will take  clientserviceS, the wrapper class 
        
       
        private readonly IClientServices _clientServices;



        public ClientController(IClientServices clientServices)
        {
            
            

            _clientServices = clientServices;

        }

        //trying to use interfaces and seperate logic
        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            return _clientServices.GetAllClients();
            //return _clientService.GetClients();
        }

        [HttpPost]
        public ActionResult<Client> CreateClient(Client client)
        {
            //try catch on the most routed level
            try
            {
                var result = _clientServices.AddClient(client);
                return Ok(result);
                
            }        
            catch (Exception e)
            {
                //normally you would log the full error message 
                //and then just display and error 500 to the user
                var x = new ObjectResult(e.Message);
                x.StatusCode = 500;
               // return StatusCode(500);
                return x;
            }
            
        }

        [HttpDelete]
        public IActionResult DeleteClient(int ClientId)
        {
            try
            {
                var result = _clientServices.RemoveClient(ClientId);
                return Ok(result);
            }
            catch (Exception e)
            {
                var x = new ObjectResult(e.Message);
                x.StatusCode = 500;
                return x;
            }
            //whats the difference between this and return Ok(result)?
        }

        //request to update client username in client table
        [Route("UpdateClient/Username")]
        [HttpPatch]
        public ActionResult UpdateClientUsername(int clientId,string username)
        {
            try
            {
                var result = _clientServices.ChangeClientUsername(clientId, username);
                return Ok(result);
            }
            catch (Exception e)
            {

                var x = new ObjectResult(e.Message);
                x.StatusCode = 500;
                return x;
            }
            
        }

        [Route("UpdateClient/Password")]
        [HttpPatch]
        public ActionResult UpdateClientPassword(int clientId, string password)
        {
            try
            {
                var result = _clientServices.ChangeClientPassword(clientId, password);
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
