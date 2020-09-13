namespace Domain.Entities
{
    public class HumanDna : Dna
    {
        public bool IsMutant { get; set; }

        public HumanDna(string[] dna)
        {
            Description = dna;

            base.IsValid();
        }
    }
}
