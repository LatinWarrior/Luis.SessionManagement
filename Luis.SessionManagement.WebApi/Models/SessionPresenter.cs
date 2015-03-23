using System;
using System.ComponentModel.DataAnnotations;

namespace Luis.SessionManagement.WebApi.Models
{
    public class SessionPresenter
    {
        [Key]
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int PresenterId { get; set; }

        // Navigation property
        public virtual Session Session { get; set; }
        // Navigation property
        public virtual Presenter Presenter { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}