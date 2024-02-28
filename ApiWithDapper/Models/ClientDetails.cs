using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWithDapper.Models
{
    public class ClientDetails
    {
        //can delete attributes
        [Key]
        public int ClientDetailsId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Cellphone { get; set; }

        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
    }
}
