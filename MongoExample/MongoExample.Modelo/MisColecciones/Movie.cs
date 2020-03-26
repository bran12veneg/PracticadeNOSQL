using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoExample.Modelo.MisColecciones
{
    public class Movie
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public Actor[] Actors { get; set; }
        public BsonDocument Metadata { get; set; }
    }
}
