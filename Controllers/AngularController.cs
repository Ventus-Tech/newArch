using Microsoft.AspNet.Mvc;
using t.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace t.Controllers
{

    public class AngularController : Controller
    {
        public Personas Grabar([FromBodyAttribute]Personas model)
        {
            try
            {

                //return  Json(model);
                if (ModelState.IsValid)
                {
                    new AppicaContext().Personas.Update(model).
                    Context.SaveChangesAsync();
                    return model;
                }
                else
                    return null; 
            }
            catch (System.Exception ex)
            {
                  throw ex.InnerException;
            }
        }

        public IEnumerable<Personas> List(Personas model) => new AppicaContext().Personas.ToList();
        public IEnumerable<DepartamentoModel> DeposList(Personas model) => new AppicaContext().Departamentos.ToList();


        public async Task<object> Borro([FromBodyAttribute]int id)
        {
            return id;
        }
        public async Task<object> Borrar([FromBodyAttribute] int id)
        {
            try
            {
                return await new AppicaContext()
            .Personas
            .Remove(new AppicaContext()
                       .Personas
                       .FirstOrDefault(f => f.IdPersona == id))
            .Context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }


        }






    }
}