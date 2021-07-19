using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using trabajoenclase.Models;

namespace trabajoenclase.Controllers
{
    public class DpersonasController : Controller
    {
        // GET: DpersonasController
        public ActionResult Index()
        {
            List<Dpersona> ltsdpers = new List<Dpersona>();
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Listadpersona")))
            {
                Dpersona dpersona = new Dpersona();
                dpersona.cedula = "1753954187";
                dpersona.nombre = "Xavier";
                dpersona.apellido = "Quilo";
                dpersona.edad = "19";
                dpersona.genero = "masculino";
                dpersona.direccion = "Quito";
                for (int x = 0; x < 6; x++) 
                {
                    ltsdpers.Add(dpersona);
                }
            }
            else
            {
                ltsdpers = JsonConvert.DeserializeObject<List<Dpersona>>(HttpContext.Session.GetString("Listadpersona"));
            }
            HttpContext.Session.SetString("Listadpersona", JsonConvert.SerializeObject(ltsdpers));

            return View(ltsdpers);
        }

        // GET: DpersonasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DpersonasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DpersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dpersona persona)
        {
            try
            {
                List<Dpersona> dpers = new List<Dpersona>();
                dpers = JsonConvert.DeserializeObject<List<Dpersona>>(HttpContext.Session.GetString("Listadpersona"));
                dpers.Add(persona);
                HttpContext.Session.SetString("Listadpersona", JsonConvert.SerializeObject(dpers));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DpersonasController/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: DpersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DpersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DpersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
