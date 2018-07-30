namespace Questions.IK.Recursion
{
    public class RecursionDriver : IQuestion
    {
        public void Run()
        {
            var result
                // = AllSubsets.generate_all_subsets("xy");
                = Expressions.generate_all_expressions("222", 24);
        }
    }
}
