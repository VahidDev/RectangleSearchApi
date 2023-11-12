using Project.Core.Models;
using Project.Core.Settings;
using Project.Infrastructure.DAL;

namespace Project.Infrastructure.Tools
{
    public static class DbInitializer
    {
        public async static Task SeedAsync(AppDbContext context)
        {
            if (context.Rectangles.Any())
            {
                return;
            }

            var rectangles = GetRectangles(AppSettings.Settings.RectangleCount);
            await context.Rectangles.AddRangeAsync(rectangles);
            await context.SaveChangesAsync();
        }

        private static IEnumerable<RectangleModel> GetRectangles(int rectangleCount)
        {
            var rectangles = new List<RectangleModel>();

            int rows = (int)Math.Ceiling(Math.Sqrt(rectangleCount));
            int columns = (int)Math.Ceiling((double)rectangleCount / rows);

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    rectangles.Add(new RectangleModel(x, y));

                    if (rectangles.Count == rectangleCount)
                    {
                        return rectangles;
                    }
                }
            }

            return rectangles;
        }
    }
}
