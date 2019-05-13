using System.Collections.Generic;

namespace Questions.IK.Graph
{
    class GraphDriver : IQuestion
    {
        public void Run()
        {
            var result
            //= KnightsTour.find_minimum_number_of_moves(2, 7, 0, 5, 1, 1);
            // = ZombieClusters.zombieCluster(new string[] { "1100", "1110", "0110", "0001"});
            // = KeysAndDoors.find_shortest_path(new string[] { "a.@.A.+" });
            // = StringTransformation.string_transformation(new string[] { "cat", "hat", "bad", "had" }, "bat", "had");
            // = AlienDictionary.find_order(new string[] { "baa", "abcd", "abca", "cab", "cad" });
            // = WordsIndices.find_words("aabbjuk kndad$ adarew2 12313141nj krbard r1b34jb1da 11 adarew2123 adarew2", new List<string> { "aa", "bb", "kndad$", "rew2", "adarew2" });

            //= DAGCycle.hasCycle(5, 7, new List<List<int>>
            //   {
            //       new List<int> { 0, 1},
            //       new List<int> { 0, 3},
            //       new List<int> { 1, 3},
            //       new List<int> { 1, 2},
            //       new List<int> { 2, 3},
            //       new List<int> { 4, 0},
            //       new List<int> { 2, 4},
            //   });

            //= LongestPath.find_longest_path(5, new int[] { 5, 4, 3, 2, 5, 5, 3}, new int[] { 4, 3, 2, 1, 1, 3, 1}, new int[] { 1, 1, 1, 1, 3, 3, 1 }, 5, 1);
//            = GuardDistance.find_shortest_distance_from_a_guard(new char[5, 5]
//            {
//                { 'O','O','O','O','G'},

//                {'O','W','W','O','O' },

//{ 'O','O','O','W','O' },

//{ 'G','W','W','W','O'},

//{'O','O','O','O','G' }

//            });

            = Itinerary.FindItinerary(new List<List<string>>
            {
                new List<string>{ "JFK", "SFO" },
                new List<string>{ "JFK", "ATL" },
                new List<string>{ "SFO", "ATL" },
                new List<string>{ "ATL", "JFK" },
                new List<string>{ "ATL", "SFO" },
            });
        }
    }
}