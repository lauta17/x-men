using Domain.Interfaces;

namespace Domain.Evaluators
{
    public class ColumnEvaluator : Evaluator, IDnaCondition
    {
        public int Contains(string[] dna)
        {
            var matches = 0;

            for (int i = 0; i < dna.Length; i++)
            {
                var invertedDna = string.Empty;

                for (int j = 0; j < dna.Length; j++)
                {
                    invertedDna += dna[j][i];
                }

                matches += Evaluate(invertedDna) ? 1 : 0;
            }

            return matches;
        }
    }
}
