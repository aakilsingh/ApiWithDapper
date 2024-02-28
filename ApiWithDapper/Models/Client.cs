using System.ComponentModel.DataAnnotations;

namespace ApiWithDapper.Models
{
    public class Client
    {
        //see whether you have to define key, or required
        
        public int ClientId { get; set; }
       
        public string Username { get; set; }
       
        public string Password { get; set; }
    }
}
