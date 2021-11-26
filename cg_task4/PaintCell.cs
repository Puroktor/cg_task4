namespace cg_task4
{
    class PaintCell
    {
        public float LocationX { set; get; }

        public float LocationY { set; get; }

        private int intValue;

        public int IntValue
        {
            set
            {
                intValue = value;
                StrValue = intValue.ToString();
            }
            get => intValue;
        }
        public string StrValue { private set; get; }

        public PaintCell(float locationX, float locationY, int value)
        {
            LocationX = locationX;
            LocationY = locationY;
            IntValue = value;
        }
    }
}
