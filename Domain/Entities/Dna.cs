using System;
using System.Linq;

namespace Domain.Entities
{
    public abstract class Dna
    {
        public string[] Description { get; set; }

        public void IsValid()
        {
            if (!Description.ToList().All(row => row.Length == Description.Length))
            {
                throw new ArgumentException("DnaFormatIsInvalid");
            }
        }
    }
}
