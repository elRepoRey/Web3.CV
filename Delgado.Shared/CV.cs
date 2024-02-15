using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;


namespace Delgado.Shared
{
    public class CV
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Name")]
        public string? Name { get; set; }
        [BsonElement("Email")]
        public string? Email { get; set; }
        [BsonElement("PhoneNumber")]
        public string? PhoneNumber { get; set; }        
        public string? LinkedIn { get; set; }
        public string? GitHub { get; set; }
        public string? Summary { get; set; }
        public Skills[]? Skills { get; set; }
        public Experience[]? Experience { get; set; }
        public Education[]? Education { get; set; }
        public Project[]? Project { get; set; }
       
    }

    public class Experience
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string? Title { get; set; }
        public string? Company { get; set; }
        public string? Location { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string[]? Description { get; set; }
    }

    public class Education
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Degree { get; set; }
        public string School { get; set; }
        public string Location { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class Skills
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string[] Keywords { get; set; }
    }

    public class Project
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Technologies { get; set; }
        public string[] Features { get; set; }
    }
      
}
