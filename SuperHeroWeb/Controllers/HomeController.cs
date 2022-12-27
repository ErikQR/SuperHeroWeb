﻿using SuperHeroWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
