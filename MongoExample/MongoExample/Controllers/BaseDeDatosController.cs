using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoExample.Controllers
{
    public class BaseDeDatosController : Controller
    {
        // GET: BaseDeDatos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear (MongoExample.Modelo.ConexionConBaseDeDatos model)
        {
            CrearBaseDeDatosEnMongo(model.Host, model.Nombre, model.Coleccion);
            return View("Index");
        }

        private IMongoDatabase CrearBaseDeDatosEnMongo (string hostName, string databaseName, string collectionName)
        {
            var laConexion = new MongoExample.Negocio.Conexion();
            var elResultado = laConexion.CreateDatabase(hostName, databaseName, collectionName);
            return elResultado;
        }
    }
}