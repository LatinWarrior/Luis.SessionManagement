using System.Runtime.Serialization;

namespace Luis.SessionManagement.WebApi.Contracts
{
    [DataContract]
    public class Address
    {
        [DataMember(EmitDefaultValue = false)]
        public int Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string StreetName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Province { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string City { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string State { get; set; }
    }
}