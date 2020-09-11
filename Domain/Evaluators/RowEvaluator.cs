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

                totalMatches += Evaluate(letters);
            }

            return totalMatches;

            //var totalMatches = 0;

            //for (int i = 0; i < dna.Length; i++)
            //{
            //    int amountMatches = 0;
            //    var letters = dna[i].ToCharArray();

            //    for (int j = 0; j < letters.Length - 1; j++)
            //    {
            //        if (letters[j].Equals(letters[j + 1]))
            //        {
            //            amountMatches += 1;
            //        }
            //        else
            //        {
            //            //Si encuentra 4 coincidencias corta la iteración para que no siga.
            //            if (amountMatches == 3) 
            //            {
            //                totalMatches += 1;
            //                break;
            //            }   

            //            amountMatches = 0;
            //        }
            //    }
            //}

            //return totalMatches;
        }

        private bool Compare(char a, char b)
        {
            return a == b;
        }
    }
}
