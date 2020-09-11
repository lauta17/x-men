using Domain.Interfaces;
using System;

namespace Domain.Evaluators
{
    public class ColumnEvaluator : Evaluator, IDnaCondition
    {
        public int Contains(string[] dna)
        {
            //ATGCGA
            //CAGTGC
            //TTATGT
            //AGAAGG
            //CCCCTA
            //TCACTG
            var matches = 0;
            var invertedDna = new string[dna.Length];

            for (int i = 0; i < dna.Length; i++)
            {
                var letters = dna[i].ToCharArray();
                for (int j = 0; j < letters.Length; j++)
                {
                    invertedDna[j] += letters[j];
                }
            }

            for (int i = 0; i < invertedDna.Length ; i++)
            {
                matches += Evaluate(invertedDna[i].ToCharArray());
            }

            return matches;
        }
    }
}
