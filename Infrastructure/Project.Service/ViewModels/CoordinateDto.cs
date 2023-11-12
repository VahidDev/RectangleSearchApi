using Project.Core.Models;

namespace Project.Service.ViewModels
{
    public class CoordinateDto
    {
        public int X { get; set; }
        public int Y { get; set; }
        public required int RectangleCount { get; init; }
        public required IEnumerable<RectangleModel> Rectangles { get; init; }

        public CoordinateDto(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
