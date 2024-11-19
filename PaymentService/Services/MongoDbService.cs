using MongoDB.Driver;
using PaymentService.Models;

namespace PaymentService.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Payment> _paymentsCollection;

        public MongoDbService(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDbSettings:mongodb+srv://0gizemgunes:XqQFObRPmJxE0uOg@paymentserviceforinvoic.oxd2e.mongodb.net/?retryWrites=true&w=majority&appName=PaymentServiceForInvoiceSystem"));
            var database = mongoClient.GetDatabase(configuration["MongoDbSettings:PaymentServiceForInvoiceSystem"]);
            _paymentsCollection = database.GetCollection<Payment>(configuration["MongoDbSettings:Payments"]);
        }

        public async Task SavePaymentAsync(Payment payment)
        {
            await _paymentsCollection.InsertOneAsync(payment);
        }
    }
}
