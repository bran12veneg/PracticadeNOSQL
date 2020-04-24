using MongoDB.Bson;
using MongoDB.Driver;
using MongoExample.Modelo;
using MongoExample.Modelo.MisColecciones;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoExample.Controllers
{
    public class AnimalitosController : Controller
    {
        // GET: Animalitos
        public ActionResult Index()
        {
            var elRepositorio = new MongoExample.Negocio.Repositorio.Animalitos();
            var laListaDeAnimalitos = elRepositorio.ListarTodos("mongodb+srv://bran:123@cluster0-rirzj.azure.mongodb.net/test?retryWrites=true&w=majority", "prueba");
            return View(laListaDeAnimalitos);
        }

        public ActionResult DuenoDetails (string id)
        {
            var elIdOriginal = new ObjectId(id);
            ViewBag.ElAnimalitoConsultado = id;
            var elRepositorio = new MongoExample.Negocio.Repositorio.Animalitos();
            var elPropietario = elRepositorio.ObtenerPropietarioDeAnimalito(elIdOriginal);
            if (elPropietario == null)
                elPropietario = new Modelo.MisColecciones.Propietario();
            return View(elPropietario);
        }

        public ActionResult VacunasDetails(string id)
        {
            var elIdOriginal = new ObjectId(id);
            ViewBag.ElAnimalitoConsultado = id;
            var elRepositorio = new MongoExample.Negocio.Repositorio.Animalitos();
            var vacunas = elRepositorio.vacunas(elIdOriginal);
            if (vacunas == null)
                vacunas = new Modelo.MisColecciones.Vacunas();
            return View(vacunas);
        }

        public ActionResult efectos(string id)
        {
            var elIdOriginal = new ObjectId(id);

            ViewBag.ElAnimalitoConsultado = id;
            var elRepositorio = new MongoExample.Negocio.Repositorio.Animalitos();
            string[] efectos = elRepositorio.vacunas(elIdOriginal).EfectosSecundarios;
            ViewBag.EfectosSecundarios = efectos;
            return View();
        }

   

        // GET: Animalitos/Details/5
        public ActionResult Details(string id)
        {
            var elIdOriginal = new ObjectId(id);
            ViewBag.ElAnimalitoConsultado = id;
            var elRepositorio = new MongoExample.Negocio.Repositorio.Animalitos();
            var elAnimalito = elRepositorio.ObtenerAnimalitoPorId(elIdOriginal);
            return View(elAnimalito);
        }


        // GET: Animalitos/Details/5
        public ActionResult DetailsAnimal(string nombre)
        {
            ViewBag.ElAnimalitoConsultado = nombre;
            var elRepositorio = new MongoExample.Negocio.Repositorio.Animalitos();
            var elAnimalito = elRepositorio.ListarAnimalitosPorNombre(nombre);
            return View(elAnimalito);
        }

        // GET: Animalitos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animalitos/Create
        [HttpPost]
        public ActionResult Create(Animalito animalito)
        {
            if (ModelState.IsValid)
            {
                var hostname = "mongodb+srv://bran:123@cluster0-rirzj.azure.mongodb.net/test?retryWrites=true&w=majority";
                var Client = new MongoClient(hostname);
                var DB = Client.GetDatabase("prueba");
                var collection = DB.GetCollection<Animalito>("animalitos");
                collection.InsertOneAsync(animalito);
                return RedirectToAction("Index");

            }
            return View();
        }

        // GET: Animalitos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Animalitos/Edit/5
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

        // GET: Animalitos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Animalitos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
