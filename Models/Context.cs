using Microsoft.Data.Entity; 

namespace t.Models
{
    public class  AppicaContext:  DbContext
    {
    //  public AppicaContext(DbContextOptions<AppicaContext> options) : base(options)
    // {}
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($@"Data Source=t.db");
    }
    
     public   DbSet<Personas> Personas{get;set;} 
     public   DbSet<DepartamentoModel> Departamentos{get;set;} 
    }  
}
