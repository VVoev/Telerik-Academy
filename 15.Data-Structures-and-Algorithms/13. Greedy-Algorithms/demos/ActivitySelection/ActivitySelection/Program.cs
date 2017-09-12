using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitySelection
{
  public class Program
  {
    private static void MockInput()
    {
      Console.SetIn(new StringReader(@"11
1 4
3 5
0 6
5 7
3 8
5 9
6 10
8 11
8 12
2 13
12 14"));
    }

    private static List<Activity> GetNotOverlappingActivities(List<Activity> activities)
    {
      activities.Sort();

      var selectedActivities = new List<Activity>();

      Activity lastSelectedActivity = activities.First();

      selectedActivities.Add(lastSelectedActivity);

      for (int i = 1; i < activities.Count; i++)
      {
        Activity activity = activities[i];
        if (lastSelectedActivity.IsCompatible(activity))
        {
          selectedActivities.Add(activity);
          lastSelectedActivity = activity;
        }
      }

      return selectedActivities;
    }

    private static List<Activity> ReadActivities()
    {
      int numberOfActivities = int.Parse(Console.ReadLine());

      var activities = new List<Activity>();
      for (int i = 0; i < numberOfActivities; i++)
      {
        int[] fromTo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int from = fromTo[0];
        int to = fromTo[1];
        activities.Add(new Activity(from, to));
      }

      return activities;
    }

    static void Main()
    {
      MockInput();
      List<Activity> activities = ReadActivities();

      List<Activity> selectedActivities = GetNotOverlappingActivities(activities);

      Console.WriteLine("Count: {0}", selectedActivities.Count);
      selectedActivities.ForEach(Console.WriteLine);
    }
  }
}
