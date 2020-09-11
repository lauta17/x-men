using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Builders
{
    public class DnaBuilder : IDnaBuilder
    {
        public DnaBuilder(string[] dna)
        {
            if (!IsValid(dna))
            {
                throw new ArgumentException("DnaStructureIsNotValid");
            }
        }

        private bool IsValid(string[] dna)
        {
            return dna.Length < 4 ? false : true;
        }
    }
}
