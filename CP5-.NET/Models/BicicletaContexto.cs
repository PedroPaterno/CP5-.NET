using CrudMongoDB.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMongoDB.Models {
    public class BicicletaContexto {
        private readonly IMongoDatabase _mongoDatabase;

        public BicicletaContexto(IOptions<ConfigDB> opcoes) {
            MongoClient mongoClient = new MongoClient(opcoes.Value.ConnectionString);

            if (mongoClient != null) {
                _mongoDatabase = mongoClient.GetDatabase(opcoes.Value.Database);
            }
        }

        public IMongoCollection<Bicicleta> Bicicletas {
            get {
                return _mongoDatabase.GetCollection<Bicicleta>("Bicicletas");
            }
        }
    }
}
