using Domain.Interfaces;

namespace Domain.Evaluators.Dna
{
    public class RowEvaluator : Evaluator, IDnaCondition
    {
        public int Contains(string[] dna)
        {
            var totalMatches = 0;

            for (int row = 0; row < dna.Length; row++)
            {
                var letters = dna[row];

                totalMatches += Evaluate(letters) ? 1 : 0;
            }

            return totalMatches;
        }
    }
}
