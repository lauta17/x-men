namespace Domain.Evaluators.Dna
{
    public abstract class Evaluator
    {
        private int _lettersNeeded => 4;
        private int _matchesNeeded => 3;
        private int _amountMatches = 0;

        //Evalua la secuencia de las letras de un string.
        protected bool Evaluate(string letters)
        {
            if (letters.Length < _lettersNeeded)
            {
                return false;
            }

            for (int col = 0; col < letters.Length - 1; col++)
            {
                var nextColumn = col + 1;

                _amountMatches = letters[col].Equals(letters[nextColumn]) 
                                    ? IncrementAmountMatches() 
                                    : 0;

                //Si encuentra secuencia de 4 letras corta con la iteracion.
                if (_amountMatches == _matchesNeeded)
                {
                    return true;
                }
            }

            return false;
        }

        private int IncrementAmountMatches()
        {
            return ++_amountMatches;
        }
    }
}
