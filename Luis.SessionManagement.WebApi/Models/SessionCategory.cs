using System.ComponentModel.DataAnnotations;

namespace Luis.SessionManagement.WebApi.Models
{
    public class SessionCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}