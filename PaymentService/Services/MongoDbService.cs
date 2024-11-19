using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using PaymentService.Models;

namespace PaymentService.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Payment> _paymentsCollection;

        public MongoDbService(IConfiguration configuration)
        {
            var connectionString = configuration["MongoDbSettings:ConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "MongoDB connection string is null or empty.");
            }

            var mongoClient = new MongoClient(connectionString);
            var databaseName = configuration["MongoDbSettings:DatabaseName"];
            if (string.IsNullOrEmpty(databaseName))
            {
                throw new ArgumentNullException(nameof(databaseName), "MongoDB database name is null or empty.");
            }

            var database = mongoClient.GetDatabase(databaseName);

            var collectionName = configuration["MongoDbSettings:PaymentsCollectionName"];
            if (string.IsNullOrEmpty(collectionName))
            {
                throw new ArgumentNullException(nameof(collectionName), "MongoDB collection name is null or empty.");
            }

            _paymentsCollection = database.GetCollection<Payment>(collectionName);
        }

        public async Task SavePaymentAsync(Payment payment)
        {
            await _paymentsCollection.InsertOneAsync(payment);
        }
    }
}
