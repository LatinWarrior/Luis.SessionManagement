using System;
using System.ComponentModel.DataAnnotations;

namespace Luis.SessionManagement.WebApi.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}