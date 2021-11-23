namespace cg_task4
{
    public class Action
    {
        public Action(Operation operation, int i, int j)
        {
            Operation = operation;
            I = i;
            J = j;
        }

        public Operation Operation { get; set; }
        public int I { get; set; }
        public int J { get; set; }
    }
}
