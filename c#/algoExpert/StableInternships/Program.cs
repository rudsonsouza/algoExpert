/*
 * Stable internships
 *
 * A company has hired N interns to each join one of N different teams. Each intern has
 * ranked their preferences for which teams they wish to join, and each team has ranked
 * their preferences for which interns they perfer.
 *
 * Given these preferences, assign 1 intern to each team. These assignments should be
 * "stable", meaning that there is no unmatched pair of an intern and a team such that both
 * that intern and that team would prefer they be matched with each other.
 *
 * In the case there are multiple valid stable matchings, the solution that is most optimal for
 * the interns should be chosen (i.e. every intern should be matched with the best team
 * possible for them).
 *
 * Your function should take in 2 2 - dimensional lists, one for interns and one for teams. Each
 * inner list represents a single intern or team's preferences, ranked from most preferable to
 * least preferable. These lists will always be of length N, with integers as elements. Each of
 * these integers corresponds to the index of the team/intern being ranked. Your function
 * should return a 2-dimensional list of matchings in no particular order. Each matching
 * should be in the format [internIndex, teamIndex].
 * 
*/

int[][] interns = new int[][] { new int[] { 0, 1, 2 }, new int[] { 0, 2, 1 }, new int[] { 1, 2, 0 }};
int[][] teams = new int[][] { new int[] { 2, 1, 0 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 } };

var result = StableInternships(interns, teams);

static int[][] StableInternships(int[][] interns, int[][] teams)
{
     Dictionary<int, int> chosenInterns = new Dictionary<int, int>();
     Stack<int> freeInterns = new Stack<int>();
     for (int i = 0; i < interns.Length; i++)
     {
         freeInterns.Push(i);
     }
     
     int[] currentInternChoices = new int[interns.Length];
     List<Dictionary<int, int>> teamDictionarys = new List<Dictionary<int, int>>();
     foreach (var team in teams)
     {
         Dictionary<int, int> rank = new Dictionary<int, int>();
         for (int i = 0; i < team.Length; i++)
         {
             rank[team[i]] = i;
         }
         
         teamDictionarys.Add(rank);
     }

     while (freeInterns.Count > 0)
     {
         int interNum = freeInterns.Pop();
         int[] intern = interns[interNum];
         int teamPreference = intern[currentInternChoices[interNum]];
         currentInternChoices[interNum]++;

         if (!chosenInterns.ContainsKey(teamPreference))
         {
             chosenInterns[teamPreference] = interNum;
             continue;
         }
         
         int previousIntern = chosenInterns[teamPreference];
         int previousInterRank = teamDictionarys[teamPreference][previousIntern];
         int currentInterRank = teamDictionarys[teamPreference][interNum];

         if (currentInterRank < previousInterRank)
         {
             freeInterns.Push(previousIntern);
             chosenInterns[teamPreference] = interNum;
         }
         else
         {
             freeInterns.Push(interNum);
         }
     }

     int[][] matches = new int[interns.Length][];
     int index = 0;
     foreach (var chosenIntern in chosenInterns)
     {
         matches[index] = new int[] { chosenIntern.Value, chosenIntern.Key };
         index++;
     }

     return matches;
}