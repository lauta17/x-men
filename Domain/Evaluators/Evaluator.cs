namespace Domain.Evaluators
{
    public abstract class Evaluator
    {
        private int _matchesNeeded => 3;
        private int _amountMatches = 0;

        protected bool Evaluate(char[] letters)
        {
            for (int i = 0; i < letters.Length - 1; i++)
            {
                var nextColumn = i + 1;

                _amountMatches = letters[i].Equals(letters[nextColumn]) 
                    ? IncrementAmountMatches() 
                    : 0;

                //Si encuentra 4 coincidencias corta la iteración para que no siga.
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
