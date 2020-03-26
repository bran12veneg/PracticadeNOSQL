using MongoDB.Bson;
using MongoDB.Driver;
using MongoExample.Modelo.MisColecciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoExample.Negocio;

namespace MongoExample.Negocio.Repositorio.Actores
{
    public class Consultas
    {
        public Movie[] GetMovieList()
        {
            Movie sevenSamurai = new Movie()
            {
                Name = "Seven Samurai",
                Director = "Akira Kurosawa",
                Year = 1954,
                Actors = new Actor[]
                {
                    new Actor { Name = "Toshiro Mifune" },
                    new Actor { Name = "Takashi Shimura" },
                }
            };
            Movie theGodFather = new Movie()
            {
                Name = "The Godfather",
                Director = "Francis Ford Coppola",
                Year = 1972,
                Actors = new Actor[]
                {
                    new Actor { Name = "Marlon Brando" },
                    new Actor { Name = "Al Pacino" },
                },
                Metadata = new BsonDocument("href", "http://thegodfather.com")
            };
            return new Movie[] { sevenSamurai, theGodFather };
        }

        //public Movie[] GetMovieByName (IMongoCollection <Movie> laColeccion, string theName)
        //{
        //    var theMovies = GetMovieList();
        //    /* Filter to retrieve movies where the name equals to "The Godfather" */
        //    var expresssionFilter = Builders<Movie>.Filter.Eq(x => x.Name, "The Godfather");
        //    var result = theMovies.Find(expresssionFilter).ToList();
        //    return result;
        //}

        public void ObtenerColeccion (string dbName, string collName)
        {
            var laConexion = new Conexion();
            var db = laConexion.GetDatabaseReference("localhost", dbName); 
            var collection = db.GetCollection<Movie>(collName);
        }
    }
}
