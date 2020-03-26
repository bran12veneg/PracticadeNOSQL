using MongoDB.Bson;
using MongoDB.Driver;
using MongoExample.Modelo.MisColecciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoExample.Negocio.Repositorio
{

    /*
     * {"_id":"5e2a5a1f710da62180ef3d70","nombre":"firulais 2","fecha_nacimiento":"2008-03-09","especie":"perro","propietario":{"email":"hecferme@gmail.com","nombre":"hector","telefonos":["21241234333","235233214","123453423"]},"vacunas":[{"fecha":"2020-01-01","tipo":"zarna"},{"fecha":"2020-01-20","tipo":"rabia","efectosSecundarios":["sueño","falta de apetito"]}]}
     * 
     * {"_id":"5e2a5698f67d8a2180402b25","nombre":"firulais","especie":"perro","fecha_nacimiento":"2020-01-01T06:00:00.000Z","propietario":{"email":"hecferme@gmail.com","nombre":"hector","telefonos":["21241234","235233214","123453423"]}}
     * 
     * 
     * 
     * */

    public class Animalitos
    {
        private const string _collName = "animalitos";
        private const string _dbName = "prueba";

        private IMongoCollection<Animalito> ObtenerColeccionDeAnimalitos()
        {
            var laConexion = new Conexion();
            var db = laConexion.GetDatabaseReference("mongodb://bran:123@cluster0-shard-00-00-rirzj.azure.mongodb.net:27017,cluster0-shard-00-01-rirzj.azure.mongodb.net:27017,cluster0-shard-00-02-rirzj.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority", _dbName);
            var collection = db.GetCollection<Animalito>(_collName);
            return collection;
        }

        public IList<Animalito> ListarTodos
            (string nombreDelHost, string dbName)
        {
            var elCliente = new Conexion();
            var laBaseDeDatos = elCliente.GetDatabaseReference("mongodb://bran:123@cluster0-shard-00-00-rirzj.azure.mongodb.net:27017,cluster0-shard-00-01-rirzj.azure.mongodb.net:27017,cluster0-shard-00-02-rirzj.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority", dbName);
            var laColeccion = laBaseDeDatos.GetCollection<Animalito>("animalitos");
            var filter = new BsonDocument();
            var elResultado = laColeccion.Find<Animalito>(filter).ToList();
            //IList<Animalito> laLista = new List<Animalito>();
            return elResultado;
        }

        public IList<Animalito> ListarAnimalitosPorNombre(string elNombre)
        {
            var losAnimalitos = ObtenerColeccionDeAnimalitos();
            /* Filter to retrieve movies where the name equals to "elNombre" */
            var expresssionFilter = Builders<Animalito>.Filter.Eq(x => x.nombre, elNombre);
            var result = losAnimalitos.Find(expresssionFilter).ToList();
            return result;
        }

        public IList<Animalito> ListarAnimalitosPorNombreDelDueno(string elNombreDelDueno)
        {
            var losAnimalitos = ObtenerColeccionDeAnimalitos();
            /* Filter to retrieve movies where the name equals to "elNombre" */
            var expresssionFilter = Builders<Animalito>.Filter.Eq(x => x.dueno.Nombre, elNombreDelDueno);
            var result = losAnimalitos.Find(expresssionFilter).ToList();
            return result;
        }

        public IList<Animalito> ListarAnimalitosPorTelefonoDelDueno(string elTelefonoDelDueno)
        {
            var losAnimalitos = ObtenerColeccionDeAnimalitos();
            /* Filter to retrieve movies where the name equals to "elNombre" */
            var expresssionFilter = Builders<Animalito>.Filter.In("dueno.telefonos", new[] { (BsonValue)elTelefonoDelDueno });
                //x => x.dueno.NumerosDeTelefono, elTelefonoDelDueno);
            var result = losAnimalitos.Find(expresssionFilter).ToList();
            return result;
        }

        public Animalito ObtenerAnimalitoPorId (ObjectId idDelAnimalito)
        {
            var losAnimalitos = ObtenerColeccionDeAnimalitos();
            /* Filter to retrieve movies where the name equals to "elNombre" */
            var expresssionFilter = Builders<Animalito>.Filter.Eq(x => x._id, idDelAnimalito);
            var elAnimalito = losAnimalitos.Find(expresssionFilter).ToList().FirstOrDefault();
            return elAnimalito;
        }

        public Propietario ObtenerPropietarioDeAnimalito (ObjectId idDelAnimalito)
        {
            var elPropietarioDelAnimalito = ObtenerAnimalitoPorId(idDelAnimalito).dueno;
            return elPropietarioDelAnimalito;
        }

        public Vacunas vacunas(ObjectId idDelAnimalito)
        {
            var comentarios = ObtenerAnimalitoPorId(idDelAnimalito).LasVacunas;
            return comentarios;
        }

        

    }
}
