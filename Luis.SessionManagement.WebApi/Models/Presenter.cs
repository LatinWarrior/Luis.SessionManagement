using System.Collections.Generic;

namespace Luis.SessionManagement.WebApi.Models
{
    public class Presenter : Person
    {
        public bool IsProctor { get; set; }
        public virtual List<SessionPresenter> SessionPresenters { get; set; }
    }
}