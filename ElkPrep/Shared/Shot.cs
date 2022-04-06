namespace ElkPrep.Shared
{
    public class Shot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Vital { get; set; }
        public int PointValue { get; set; }
        public Arrow Arrow { get; set; }


        public Shot(bool vital, int pointValue, Arrow arrow )
        {
            Vital = vital;
            PointValue = pointValue;

        }
    }
}