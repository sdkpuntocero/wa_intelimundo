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
    
    public partial class inf_respuestas_test
    {
        public int id_respuestas_test { get; set; }
        public string desc_respuestas_test { get; set; }
        public Nullable<bool> valor_respuesta_test { get; set; }
        public int id_pregunta { get; set; }
    
        public virtual inf_preguntas_test inf_preguntas_test { get; set; }
    }
}
