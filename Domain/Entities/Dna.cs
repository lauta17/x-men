using System;
using System.Linq;

namespace Domain.Entities
{
    public abstract class Dna
    {
        private string AllowedLetters => "ATCG";
        public string[] Description { get; set; }

        protected virtual void IsValid()
        {
            if (!Description.ToList().All(row => row.Length == Description.Length))
            {
                throw new ArgumentException("DnaFormatIsInvalid");
            }

            if ((!Description.ToList()
                        .All(row => row
                            .All(rowElem => AllowedLetters.Contains(rowElem)))))
            {
                throw new ArgumentException("DnaNotContainInvalidLetters");
            }
        }
    }
}
