﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoExample.Modelo.MisColecciones
{

    [BsonIgnoreExtraElements]
    public class Animalito
    {
        [BsonId]
        public ObjectId _id;


        [BsonElement("nombre")]
        public string nombre { get; set; }
        [BsonElement("especie")]
        [Display(Name = "Especie")]
        public string  tipo { get; set; }
        [BsonElement("fecha_nacimiento")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime fecha_nacimiento { get; set; }
        [BsonElement("vacunas")]
        public Vacunas LasVacunas { get; set; }
        [BsonElement("propietario")]
        public Propietario dueno { get; set; }
        [BsonElement("comentarios")]
        public string[] LosComentarios { get; set; }
        [BsonIgnore] 
        public string Age { 
            get {
                    int diferenciaDeDias = (DateTime.Now - this.fecha_nacimiento).Days;
                    int edadEnMeses = diferenciaDeDias / 30;
                    int mesesRestantes = edadEnMeses % 12;
                    int edadEnAnos = edadEnMeses / 12;
                    string elResultado = string.Format("{0} años y {1} meses", edadEnAnos.ToString(), mesesRestantes.ToString());
                    return elResultado; 
                } 
            set { }
        }
        [BsonExtraElements] public BsonDocument Metadata { get; set; }
    }


    public class Vacunas
    {
        [BsonElement("fecha")]
        public DateTime Fecha { get; set; }
        [BsonElement("tipo")]
        public string Tipo { get; set; }
        [BsonElement("efectosSecundarios")]
        public string[] EfectosSecundarios { get; set; }
        [BsonExtraElements] public BsonDocument Metadata { get; set; }

    }

    public class Propietario
    {
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
        [BsonElement ("telefonos")]
        public string[] NumerosDeTelefono { get; set; }
        [BsonExtraElements] public BsonDocument Metadata { get; set; }

    }
}
