namespace Services.Dtos
{
    public class DnaSummaryResponse
    {
        public long count_mutant_dna { get; set; }
        public long count_human_dna { get; set;  }
        public decimal ratio { get; set; }
}
}
