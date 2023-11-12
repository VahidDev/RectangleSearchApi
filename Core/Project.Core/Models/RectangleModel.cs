namespace Project.Core.Models
{
    public class RectangleModel
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public RectangleModel(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X}:{Y}"; 
        }
    }
}
