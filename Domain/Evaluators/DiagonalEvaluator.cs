using Domain.Interfaces;
using System;
using System.Linq;

namespace Domain.Evaluators
{
    public class DiagonalEvaluator : Evaluator, IDnaCondition
    {
        //ATGCGA
        //CAGTGC
        //TTATGT
        //AGAAGG
        //CCCCTA
        //TCACTG

        public int Contains(string[] dna)
        {
            //falta recorrer para la derecha y para abajo en la matriz

            var lettersToCompare = string.Empty;

            for (int i = 0; i < dna.Length; i++)
            {
                var letters = dna[i].ToCharArray();

                lettersToCompare += letters[i];
            }

            var totalMatches = Evaluate(lettersToCompare.ToCharArray()) ? 1 : 0;

            return totalMatches;
        }
    }
}
