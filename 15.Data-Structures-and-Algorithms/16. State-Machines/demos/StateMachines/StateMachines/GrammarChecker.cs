namespace StateMachines
{
  using System.Collections.Generic;
  using System.Linq;

  using Extensions;

  public class GrammarChecker<T>
  {
    private readonly IDictionary<T, ISet<T>> rules;

    private readonly ISet<T> startStates;

    private readonly ISet<T> endStates;

    public GrammarChecker()
    {
      this.rules = new Dictionary<T, ISet<T>>();
      this.startStates = new SortedSet<T>();
      this.endStates = new HashSet<T>();
    }

    public void AddRule(T from, T to)
    {
      if (!this.rules.ContainsKey(from))
      {
        this.rules[from] = new SortedSet<T>();
      }

      this.rules[from].Add(to);
    }

    public void AddStartState(T state)
    {
      this.startStates.Add(state);
    }

    public void AddEndState(T state)
    {
      this.endStates.Add(state);
    }

    public bool Check(IEnumerable<T> wordToCheck)
    {
      T[] word = wordToCheck.ToArray();

      if (!this.startStates.Contains(word[0]) ||
         !this.endStates.Contains(word[word.Length - 1]))
      {
        return false;
      }

      T state = word[0];

      for (int i = 1; i < word.Length; i++)
      {
        T nextState = word[i];

        if (!this.rules.ContainsKey(state) ||
            !this.rules[state].Contains(nextState))
        {
          return false;
        }
      }

      return true;
    }

    public IEnumerable<IEnumerable<T>> GetPossibleWordsWithLength(int length)
    {
      var words = new List<IEnumerable<T>>();
      var word = new List<T>();

      this.startStates.ForEach(startState =>
      {
        word.Clear();
        word.Add(startState);
        BuildWordsWithPrefix(word, length, words);
      });
      return words;
    }

    private void BuildWordsWithPrefix(List<T> word, int length, List<IEnumerable<T>> words)
    {
      if (word.Count > length)
      {
        return;
      }
      var currentState = word.Last();
      if (this.endStates.Contains(currentState))
      {
        words.Add(new List<T>(word));
      }

      foreach (var next in this.rules[currentState])
      {
        word.Add(next);
        this.BuildWordsWithPrefix(word, length, words);
        word.RemoveAt(word.Count - 1);
      }
    }
  }
}
