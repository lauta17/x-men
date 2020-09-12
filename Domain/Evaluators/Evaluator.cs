namespace Domain.Evaluators
{
    public abstract class Evaluator
    {
        private int _lettersNeeded => 4;
        private int _matchesNeeded => 3;
        private int _amountMatches = 0;

        //Evalua la secuencia de las letras de un array.
        protected bool Evaluate(string letters)
        {
            if (letters.Length < _lettersNeeded)
            {
                return false;
            }

            for (int i = 0; i < letters.Length - 1; i++)
            {
                var nextColumn = i + 1;

                _amountMatches = letters[i].Equals(letters[nextColumn]) 
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
