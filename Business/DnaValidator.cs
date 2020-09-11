using Application.Interfaces;

namespace Application
{
    public class DnaValidator : IDnaValidator
    {
        public bool IsValid(string [] dna)
        {
            return dna.Length < 4 ? false : true;
        }
    }
}
