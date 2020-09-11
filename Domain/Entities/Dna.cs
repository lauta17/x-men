namespace Domain.Entities
{
    public class Dna
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsMutant { get; set; }

        public Dna(string[] dna)
        {

        }
    }
}
