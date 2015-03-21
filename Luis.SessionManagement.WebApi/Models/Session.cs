using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Luis.SessionManagement.WebApi.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public bool Approved { get; set; }

        // Foreign Key
        [Required]
        public int SessionLevelId { get; set; }

        public string Description { get; set; }

        // Navigation property
        public virtual SessionLevel SessionLevel { get; set; }

        public virtual List<SessionPresenter> SessionPresenters { get; set; }

        // Navigation property
        public virtual SessionCategory SessionCategory { get; set; }

        // Foreign Key
        [Required]
        public int SessionCategoryId { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool HasProctors { get; set; }
        public DateTime SessionDateTime { get; set; }
    }
}