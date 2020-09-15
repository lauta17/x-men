using Domain.Interfaces;
using System;

namespace Domain.Evaluators.Dna
{
    public class DiagonalEvaluator : Evaluator, IDnaCondition
    {
        public int GetCoincidences(string[] dna)
        {
            int maxLength = dna.Length;
            int totalMatches = 0;

            //Valido las diagonales moviendome en Y
            for (int row = 0; row < maxLength; row++)
            {
                var letters = GetDiagonalLettersToLeft(dna, row, column:0);

                totalMatches += Evaluate(letters) ? 1 : 0;
            }

            //Valido las diagonales moviendome en X
            for (int column = 1; column < maxLength; column++)
            {
                var letters = GetDiagonalLettersToRight(dna, row:0, column);

                totalMatches += Evaluate(letters) ? 1 : 0;
            }

            return totalMatches;
        }

        #region Private Methods

        private string GetDiagonalLettersToLeft(string[] dna, int row, int column)
        {
            var letters = string.Empty;

            while (row < dna.Length)
            {
                letters += dna[row][column];

                row++;
                column++;
            }

            return letters;
        }

        private string GetDiagonalLettersToRight(string[] dna, int row, int column)
        {
            var letters = string.Empty;

            while (column < dna.Length)
            {
                letters += dna[row][column];

                row++;
                column++;
            }

            return letters;
        }

        #endregion
    }
}
