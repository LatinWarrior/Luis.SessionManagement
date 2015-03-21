using System.ComponentModel.DataAnnotations;

namespace Luis.SessionManagement.WebApi.Models
{
    public class SessionLevel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}