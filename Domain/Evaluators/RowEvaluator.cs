using Domain.Interfaces;
using System;

namespace Domain.Evaluators
{
    public class RowEvaluator : Evaluator, IDnaCondition
    {
        //ATGCGA
        //CAGTGC
        //TTATGT
        //AGAAGG
        //CCCCTA
        //TCACTG

        public int Contains(string[] dna)
        {
            var totalMatches = 0;

            for (int i = 0; i < dna.Length; i++)
            {
                var letters = dna[i].ToCharArray();

                totalMatches += Evaluate(letters) ? 1 : 0;
            }

            return totalMatches;
        }

        private bool Compare(char a, char b)
        {
            return a == b;
        }
    }
}
