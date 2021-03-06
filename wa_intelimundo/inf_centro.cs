//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wa_intelimundo
{
    using System;
    using System.Collections.Generic;
    
    public partial class inf_centro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inf_centro()
        {
            this.inf_alumnos = new HashSet<inf_alumnos>();
            this.inf_centro_dep = new HashSet<inf_centro_dep>();
            this.inf_examenes = new HashSet<inf_examenes>();
            this.inf_inventario = new HashSet<inf_inventario>();
            this.inf_proveedor = new HashSet<inf_proveedor>();
            this.inf_usuarios = new HashSet<inf_usuarios>();
            this.inf_ventas = new HashSet<inf_ventas>();
        }
    
        public System.Guid id_centro { get; set; }
        public string id_codigo_centro { get; set; }
        public Nullable<int> id_tipo_centro { get; set; }
        public Nullable<int> id_estatus { get; set; }
        public int id_licencia { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string callenum { get; set; }
        public Nullable<int> id_codigo { get; set; }
        public Nullable<System.Guid> id_empresa { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public Nullable<int> dia_corte { get; set; }
    
        public virtual fact_estatus fact_estatus { get; set; }
        public virtual fact_licencias fact_licencias { get; set; }
        public virtual fact_tipo_centro fact_tipo_centro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inf_alumnos> inf_alumnos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inf_centro_dep> inf_centro_dep { get; set; }
        public virtual inf_empresa inf_empresa { get; set; }
        public virtual inf_sepomex inf_sepomex { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inf_examenes> inf_examenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inf_inventario> inf_inventario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inf_proveedor> inf_proveedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inf_usuarios> inf_usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inf_ventas> inf_ventas { get; set; }
    }
}
