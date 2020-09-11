namespace Domain.Evaluators
{
    public abstract class Evaluator
    {
        private int _matchesNeeded => 3;

        protected int Evaluate(char[] letters)
        {
            var amountMatches = 0;

            for (int i = 0; i < letters.Length - 1; i++)
            {
                if (letters[i].Equals(letters[i + 1]))
                {
                    amountMatches += 1;
                }
                else
                {
                    //Si encuentra 4 coincidencias corta la iteración para que no siga.
                    if (amountMatches == _matchesNeeded)
                    {
                        return 1;
                    }

                    amountMatches = 0;
                }
            }

            return 0;
        }
    }
}
