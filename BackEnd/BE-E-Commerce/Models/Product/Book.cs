using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BE_E_Commerce.Models;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public Partner Partner { get; set; }
    public int Page { get; set; }
    public float Size { get; set; }
    public string Author { get; set; }
    public string Color { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
} 