using Domain.Interfaces;

namespace Domain.Evaluators.Dna
{
    public class AntiDiagonalEvaluator : Evaluator, IDnaCondition
    {
        public int GetCoincidences(string[] dna)
        {
            int maxLength = dna.Length;
            int totalMatches = 0;

            for (int i = maxLength - 1; i >= 0; i--)
            {
                var letters = GetInvertedDiagonalToLeft(dna, row: 0, column: i);

                totalMatches += Evaluate(letters) ? 1 : 0;
            }

            //Valido las diagonales invertidas moviendome en X
            for (int i = 1; i < maxLength; i++)
            {
                var letters = GetInvertedDiagonalToRight(dna, row: i, column: 5);

                totalMatches += Evaluate(letters) ? 1 : 0;
            }

            return totalMatches;
        }

        #region Private Methods

        private string GetInvertedDiagonalToLeft(string[] dna, int row, int column)
        {
            const int firstColumn = 0;
            var letters = string.Empty;

            while (column >= firstColumn)
            {
                letters += dna[row][column];

                row++;
                column--;
            }

            return letters;
        }

        private string GetInvertedDiagonalToRight(string[] dna, int row, int column)
        {
            var letters = string.Empty;
            const int firstColumn = 0;

            while (column >= firstColumn && row < dna.Length)
            {
                letters += dna[row][column];

                row++;
                column--;
            }

            return letters;
        }

        #endregion
    }
}
