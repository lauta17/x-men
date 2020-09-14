using MongoDB.Bson;

namespace DB.Entities
{
    public class DnaData
    {
        public ObjectId Id { get; set; }
        public string[] Dna { get; set; }
        public bool IsMutant { get; set; }
    }
}
