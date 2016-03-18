using Microsoft.AspNet.Mvc;
using t.Models;
using System.Linq;

namespace t.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Personas();
            return View(model);
        }


        [HttpPost]
        public IActionResult Index(Personas model)
        {

            if (ModelState.IsValid)
            {
                var context = new AppicaContext();
                context.Personas.Add(model);
                context.SaveChanges();
            }
            return Redirect("~/Home/Lista");
        }

        public IActionResult Lista()
        {
            var lista = new AppicaContext().Personas.ToList();
            return View(lista);
        }

        public IActionResult Editar(int id)
        {
            var Persona = new AppicaContext().Personas.FirstOrDefault(f => f.IdPersona == id);
            return View(Persona);
        }
        [HttpPost]
        public IActionResult Editar(Personas persona)
        {
            if (ModelState.IsValid) 
                using (var context = new AppicaContext()) 
                    context.Personas.Update(persona).Context.SaveChanges(); 
            return Redirect("~/Home/Lista");
        }

        public IActionResult Borrar(int id)
        {
            using (var context = new AppicaContext())
                context.Personas.Remove(context.Personas.FirstOrDefault(f => f.IdPersona == id))
                .Context.SaveChanges(); 
            return Redirect("~/Home/Lista");
        }
        #region AngularViews
         public IActionResult aLista() =>View();
         public IActionResult aNuevo() =>View(new Personas());
         public IActionResult aEdita(int id) =>View(new AppicaContext().Personas.FirstOrDefault(f => f.IdPersona==id));
         
            
        #endregion
    }
}
