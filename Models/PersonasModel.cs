using System.ComponentModel.DataAnnotations;


namespace t.Models
{    
	public class Personas
	{
		[ScaffoldColumn(false)]
        [KeyAttribute]
		public int? IdPersona {get;set;}
		[Required]
		[Display(Name= "Nombre Completo")]
		public string Nombre {get;set;}
        [Required]
		[DataType(DataType.PhoneNumber)]
		public string Telefono {get;set;}    
        
        public int IdDep { get; set; }
        public  DepartamentoModel Departamento {get;set;}
	 }
}

