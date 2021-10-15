using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Week4.EsFinale.Core.Models
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
