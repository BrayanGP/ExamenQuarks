using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Examen_WCF
{
    public class Entidades
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string codigoPostal { get; set; }
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