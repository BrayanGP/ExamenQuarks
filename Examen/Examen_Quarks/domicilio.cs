//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Examen_Quarks
{
    using System;
    using System.Collections.Generic;
    
    public partial class domicilio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public domicilio()
        {
            this.cliente = new HashSet<cliente>();
        }
    
        public int id { get; set; }
        public string calle { get; set; }
        public string numeroExterior { get; set; }
        public string numeroInterior { get; set; }
        public string codigoPostal { get; set; }
        public string colonia { get; set; }
        public string municipio { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente> cliente { get; set; }
    }
}