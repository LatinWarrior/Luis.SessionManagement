using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Luis.SessionManagement.WebApi.Contracts
{
    [DataContract]
    public class Presenter
    {
        [DataMember(EmitDefaultValue = false)]
        public int Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string FirstName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string LastName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int AddressId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool IsProctor { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<int> SessionIds { get; set; }
    }
}