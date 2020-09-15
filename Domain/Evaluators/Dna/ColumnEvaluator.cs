using Domain.Interfaces;

namespace Domain.Evaluators.Dna
{
    public class ColumnEvaluator : Evaluator, IDnaCondition
    {
        public int GetCoincidences(string[] dna)
        {
            var matches = 0;
            var maxLength = dna.Length;

            for (int col = 0; col < maxLength; col++)
            {
                var invertedDna = string.Empty;

                for (int row = 0; row < dna.Length; row++)
                {
                    invertedDna += dna[row][col];
                }

                matches += Evaluate(invertedDna) ? 1 : 0;
            }

            return matches;
        }
    }
}
