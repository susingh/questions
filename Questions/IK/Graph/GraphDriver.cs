namespace Questions.IK.Graph
{
    class GraphDriver : IQuestion
    {
        public void Run()
        {
            var result
                //= KnightsTour.find_minimum_number_of_moves(2, 7, 0, 5, 1, 1);
                // = ZombieClusters.zombieCluster(new string[] { "1100", "1110", "0110", "0001"});
                = KeysAndDoors.find_shortest_path(new string[] { "a.@.A.+" });
        }
    }
}