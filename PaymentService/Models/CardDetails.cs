using MongoDB.Bson.Serialization.Attributes;

namespace PaymentService.Models
{
    public class CardDetails
    {
        [BsonElement("CardNumber")]
        public string CardNumber { get; set; }

        [BsonElement("CardHolder")]
        public string CardHolder { get; set; }

        [BsonElement("ExpiryDate")]
        public string ExpiryDate { get; set; }
    }
}
