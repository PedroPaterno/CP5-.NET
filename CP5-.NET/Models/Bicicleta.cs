using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMongoDB.Models {
    public class Bicicleta {
        [BsonElement("_id")]
        public Guid BicicletaId { get; set; }

        public string Fabricante { get; set; }

        public string Nome { get; set; }

        public string Tipo { get; set; }
    }
}
