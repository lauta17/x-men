namespace Domain.Entities
{
    public class DnaSummary
    {
        public long CountHumanDna { get; set; }
        public long CountMutantDna { get; set; }
        public decimal Ratio
        {
            get {
                return CountHumanDna > 0 
                        ? (decimal)CountMutantDna / CountHumanDna
                        : 0;
            }
        }
    }
}
