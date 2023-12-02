using Project.Core.Utilities.Results;
using Project.Infrastructure.Repositories.Abstraction;
using Project.Service.Services.Abstraction;
using Project.Service.ViewModels;
using System.Net;

namespace Project.Service.Services.Implementation
{
    public class RectangleService : IRectangleService
    {
        private readonly IRectangleRepository _rectangleRepository;

        public RectangleService(IRectangleRepository rectangleRepository)
        {
            _rectangleRepository = rectangleRepository;
        }

        public Result GetAllRectangles(IEnumerable<SearchCoordinateDto> coordinates)
        {
            var result = new Result();
            var coordinateDtos = new List<CoordinateDto>();

            try
            {
                var xMax = coordinates.Max(c => c.X);
                var yMax = coordinates.Max(c => c.Y);

                var dbRectangles = _rectangleRepository.GetAllAsNoTracking(r => r.X <= xMax && r.Y <= yMax)
                                                       .ToList();

                foreach (var coordinate in coordinates)
                {
                    var x = coordinate.X;
                    var y = coordinate.Y;

                    var subRectangles = dbRectangles.Where(r => r.X <= x && r.Y <= y)
                                                    .ToList();

                    var coordinateDto = new CoordinateDto(x, y)
                    {
                        Rectangles = subRectangles,
                        RectangleCount = subRectangles.Count
                    };

                    coordinateDtos.Add(coordinateDto);
                }

                result.Data = coordinateDtos;
                result.StatusCode = (int)HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
                result.Success = false;
                result.StatusCode = (int)HttpStatusCode.BadRequest;
            }
           
            return result;
        }
    }
}