using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Superheroes.Data;
using Superheroes.Models;

namespace Superheroes.Controllers
{
    public class SuperheroController : Controller
    {
        public ApplicationDbContext db;

        public SuperheroController(DbContextOptions<ApplicationDbContext> options)
        {
            db = new ApplicationDbContext(options);
        }

        // GET: SuperheroController
        public ActionResult Index()
        {
            return View(db.Superhero.ToList());
        }

        // GET: SuperheroController/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Superhero.Single(s => s.Id == id));
        }

        // GET: SuperheroController/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        // POST: SuperheroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                db.Superhero.Add(superhero);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Superhero.Single(s => s.Id == id));
        }

        // POST: SuperheroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Superhero superhero = db.Superhero.Single(s => s.Id == id);
                superhero.Name = collection["Name"];
                superhero.AlterEgo = collection["AlterEgo"];
                superhero.PrimaryAbility = collection["PrimaryAbility"];
                superhero.SecondaryAbility = collection["SecondaryAbility"];
                superhero.Catchphrase = collection["Catchphrase"];
                
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Superhero.Single(s => s.Id == id));
        }

        // POST: SuperheroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                db.Superhero.Remove(db.Superhero.Single(s => s.Id == id));
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
