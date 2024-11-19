using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PaymentService.Models
{
    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid PaymentId { get; set; }

        [BsonElement("BillId")]
        public string BillId { get; set; }

        [BsonElement("UserId")]
        public string UserId { get; set; }

        [BsonElement("Amount")]
        public decimal Amount { get; set; }

        [BsonElement("PaymentDate")]
        public DateTime PaymentDate { get; set; }

        [BsonElement("CardDetails")]
        public CardDetails CardDetails { get; set; }

        [BsonElement("IsSuccessful")]
        public bool IsSuccessful { get; set; }
    }
}
