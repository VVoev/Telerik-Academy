namespace StateMachines
{
  using System;
  using System.Linq;
  using System.Collections.Generic;
  using System.IO;

  using Extensions;

  class Program
  {    
    static void Main()
    {
      var grammarRules = (new string[] { "a->b", "a->l", "a->a", "a-> ", "l->a", "b-a", " ->b" })
          .Select(rule => new
          {
            From = rule[0],
            To = rule[rule.Length - 1]
          });

      string startStates = "ab";
      string endStates = "al";
      GrammarChecker<char> checker = BuildGrammarCheckerFrom(grammarRules, startStates, endStates);

      (new string[] { "ala bala", "alal", "abab", "lala", "alalala", "a" })
        .ForEach(word => Console.WriteLine("{0} -> {1}", word, checker.Check(word)));

      using (StreamWriter writer = new StreamWriter("..\\..\\words.txt"))
      {
        checker.GetPossibleWordsWithLength(8)
            .Select(word => string.Join(string.Empty, word))
            .ForEach(writer.WriteLine);
      }
    }

    private static GrammarChecker<T> BuildGrammarCheckerFrom<T>(IEnumerable<dynamic> rules, IEnumerable<T> startRules, IEnumerable<T> endRules)
    {
      var checker = new GrammarChecker<T>();
      rules.ForEach(rule => checker.AddRule(rule.From, rule.To));

      startRules.ForEach(checker.AddStartState);
      endRules.ForEach(checker.AddEndState);
      return checker;
    }
  }
}
