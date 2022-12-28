using SuperHeroWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace SuperHeroWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            DataBase db = new DataBase();
            List<Heroe> losHeroes = db.obtenerHeroes();


            return View(losHeroes);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            DataBase db = new DataBase();
            Heroe h = db.buscarHeroeId(id);
            if (h != null)
            {
                return View(h);
            }
            else
            {
                return Content("<h1> No existe </h1>");
            }
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                DataBase db = new DataBase();
              
                Heroe h = new Heroe();
                // TODO: Add insert logic here
                //sacar info de collection
                h.Id = collection["Id"].ToString().AsInt();
                h.Nombre = collection["Nombre"].ToString();
                h.Superpoder = collection["Superpoder"].ToString();
                h.Nivel = collection["Nivel"].ToString().AsInt();
                h.Retirado = collection["Retirado"].ToString().AsBool();
                h.Correo = collection["Correo"].ToString();
                h.FechaNac = collection["FechaNac"].ToString().AsDateTime();
                h.Altura = collection["Altura"].ToString().AsFloat();
                h.Peso = collection["Peso"].ToString().AsFloat();
                // TODO: buscar si el id del heroe almacenado en el formcollection es igual a uno existente
                Heroe h2 = db.buscarHeroeId(h.Id);
                if (h2 == null)
                {
                    db.agregarHeroe(h);
                    TempData["Success"] = "Usuario registrado";
                }
                else {
                    return Content("<h1> El identificador ingresado ya existe </h1>");
                }
                // en caso positivo guardar

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            DataBase db = new DataBase();
            Heroe h = db.buscarHeroeId(id);
            return View(h);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                DataBase db = new DataBase();
                Heroe h = new Heroe();
                Heroe h2 = db.buscarHeroeId(id);

                h.Id = id;
                h.Nombre = collection["Nombre"].ToString();
                h.Superpoder = collection["Superpoder"].ToString();
                h.Nivel = collection["Nivel"].ToString().AsInt();
                h.Retirado = collection["Retirado"].ToString().AsBool();
                h.Correo = collection["Correo"].ToString();
                h.FechaNac = collection["FechaNac"].ToString().AsDateTime();
                h.Altura = collection["Altura"].ToString().AsFloat();
                h.Peso = collection["Peso"].ToString().AsFloat();

                

                if (h2.Id == h.Id)
                {
                    db.editarHeroe(h);
                    TempData["Success"] = "Usuario Editado con exito";
                }
                else
                {
                    return Content("<h1> El identificador ingresado ya existe </h1>");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            DataBase db = new DataBase();
            Heroe h = db.buscarHeroeId(id);
            return View(h);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                DataBase db = new DataBase();
                db.eliminarHeroe(id);
                TempData["Success"] = "Usuario Eliminado con Exito";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
