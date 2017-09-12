namespace StateMachines.Tests
{
  using System;
  using System.Linq;
  using System.Collections.Generic;

  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Extensions;

  [TestClass]
  public class GrammarCheckerTests
  {
    private static GrammarChecker<T> BuildGrammarCheckerFrom<T>(IEnumerable<dynamic> rules, IEnumerable<T> startRules, IEnumerable<T> endRules)
    {
      var checker = new GrammarChecker<T>();
      rules.ForEach(rule => checker.AddRule(rule.From, rule.To));

      startRules.ForEach(checker.AddStartState);
      endRules.ForEach(checker.AddEndState);
      return checker;
    }

    private GrammarChecker<char> GetChecker()
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
      return checker;
    }

    [TestMethod]
    public void Check_WhenWordThanCanBeDone_ShouldReturnTrue()
    {
      var checker = GetChecker();

      var word = "ala bala";

      var actual = checker.Check(word);

      Assert.IsTrue(actual);
    }

    [TestMethod]
    public void Check_WhenWordThanCannotBeDone_ShouldReturnTrue()
    {
      var checker = GetChecker();

      var word = "allalalalalal";

      var actual = checker.Check(word);

      Assert.IsFalse(actual);
    }

    [TestMethod]
    public void Check_AllWordsWithLengthFrom5To15_ShouldReturnTrue()
    {
      GrammarChecker<char> checker = GetChecker();
      Enumerable.Range(start: 5, count: 10)
          .SelectMany(length => checker.GetPossibleWordsWithLength(length))
          .ForEach(word =>
          {
            Assert.IsTrue(checker.Check(word));
          });

    }
  }
}
