﻿using Domain.Interfaces;

namespace Domain.Evaluators.Dna
{
    public class DiagonalEvaluator : Evaluator, IDnaCondition
    {
        public int Contains(string[] dna)
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
            for (int col = 1; col < maxLength; col++)
            {
                var letters = GetDiagonalLettersToRight(dna, row:0, col);

                totalMatches += Evaluate(letters) ? 1 : 0;
            }

            return totalMatches;
        }

        //A T G C G A
        //C A G T G C
        //T T A T G T
        //A G A A G G
        //C C C C T A
        //T C A C T G

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