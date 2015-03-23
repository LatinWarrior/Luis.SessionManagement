using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Luis.SessionManagement.WebApi.Contracts
{
    [DataContract]
    public class Session
    {
        [DataMember(EmitDefaultValue = false)]
        public int Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Title { get; set; }

        [DataMember(EmitDefaultValue = true)]
        public bool Approved { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string SessionLevelName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<PresenterInfo> PresenterInfoList { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string SessionCategoryName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool HasProctors { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime SessionDateTime { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int SessionCategoryId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int SessionLevelId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<SessionPresenter> SessionPresenters { get; set; }
    }
}