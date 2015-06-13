using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsSolver.Distance
{
    [DataContract]
    public class GoogleDistanseMatrixResponse
    {

        [DataMember(Name = "destination_addresses")]
        public string[] Destination_Addresses { get; set; }

        [DataMember(Name = "origin_addresses")]
        public string[] Origin_Addresses { get; set; }

        [DataMember(Name = "rows")]
        public Row[] Rows { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }
    }

    [DataContract]
    public class SingleElement
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "value")]
        public int Value { get; set; }
    }

    [DataContract]
    public class Row
    {
        [DataMember(Name = "elements")]
        public Element[] Elements { get; set; }
    }

    [DataContract]
    public class Element
    {
        [DataMember(Name = "distance")]
        public SingleElement Distance { get; set; }

        [DataMember(Name = "duration")]
        public SingleElement Duration { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }
    }
}
