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
    
    public partial class inf_inventario
    {
        public System.Guid id_inventario { get; set; }
        public Nullable<int> id_estatus { get; set; }
        public string id_codigo_inventario { get; set; }
        public Nullable<int> id_grado_escolar { get; set; }
        public string categoria { get; set; }
        public string desc_inventario { get; set; }
        public string caracteristica { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<int> cantidad_minima { get; set; }
        public Nullable<decimal> costo { get; set; }
        public Nullable<int> margen { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public System.Guid id_centro { get; set; }
    
        public virtual fact_grado_escolar fact_grado_escolar { get; set; }
        public virtual inf_centro inf_centro { get; set; }
    }
}
