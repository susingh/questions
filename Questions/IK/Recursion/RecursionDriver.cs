namespace Questions.IK.Recursion
{
    public class RecursionDriver : IQuestion
    {
        public void Run()
        {
            var result
                // = AllSubsets.generate_all_subsets("xy");
                // = Expressions.generate_all_expressions("222", 24);
                // = WellFormedBrackets.find_all_well_formed_brackets(3);
                = TargetSum.check_if_sum_possible(new long[] { 1 }, 0);
        }
    }
}
