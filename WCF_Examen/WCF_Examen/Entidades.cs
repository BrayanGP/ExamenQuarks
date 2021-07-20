using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_Examen
{
    public class Entidades
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public Nullable<int> codigoPostal { get; set; }
        [DataMember]
        public string colonia { get; set; }
        [DataMember]
        public string municipio { get; set; }
        [DataMember]
        public string ciudad { get; set; }
        [DataMember]
        public string estado { get; set; }
    }
}