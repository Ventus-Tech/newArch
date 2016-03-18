using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace t.Models
{
    public class DepartamentoModel
    {
        [Required]
        [KeyAttribute]
        public int IdDep { get; set; }
        [Required]
        public string Descripcion { get; set; }
        
        public virtual ICollection<Personas> Personas{get;set;}
    }
}