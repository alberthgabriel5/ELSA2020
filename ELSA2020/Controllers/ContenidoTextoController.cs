using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ELSA2020;

namespace ELSA2020.Controllers
{
    public class ContenidoTextoController : Controller
    {
        private entityFramework db = new entityFramework();

        // GET: ContenidoTexto
        public ActionResult Index()
        {
            var contenidoTexto = db.ContenidoTexto.Include(c => c.hotel).Include(c => c.Pagina);
            return View(contenidoTexto.Where(l => l.idPagina == 4).ToList());
        }

        // GET: ContenidoTexto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContenidoTexto contenidoTexto = db.ContenidoTexto.Find(id);
            if (contenidoTexto == null)
            {
                return HttpNotFound();
            }
            return View(contenidoTexto);
        }

        
        // GET: ContenidoTexto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContenidoTexto contenidoTexto = db.ContenidoTexto.Find(id);
            if (contenidoTexto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idHotel = new SelectList(db.hotel, "id", "nombre", contenidoTexto.idHotel);
            ViewBag.idPagina = new SelectList(db.Pagina, "id", "nombre", contenidoTexto.idPagina);
            return View(contenidoTexto);
        }

        // POST: ContenidoTexto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombreUnico,valorTexto,fechaCreacion,fechaActualizacion,idioma,idHotel,idPagina")] ContenidoTexto contenidoTexto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contenidoTexto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idHotel = new SelectList(db.hotel, "id", "nombre", contenidoTexto.idHotel);
            ViewBag.idPagina = new SelectList(db.Pagina, "id", "nombre", contenidoTexto.idPagina);
            return View(contenidoTexto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
