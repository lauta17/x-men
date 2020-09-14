using Domain.Interfaces;

namespace Domain.Evaluators.Dna
{
    public class RowEvaluator : Evaluator, IDnaCondition
    {
        public int Contains(string[] dna)
        {
            var totalMatches = 0;
            var maxLength = dna.Length;

            for (int row = 0; row < maxLength; row++)
            {
                var letters = dna[row];

                totalMatches += Evaluate(letters) ? 1 : 0;
            }

            return totalMatches;
        }
    }
}
