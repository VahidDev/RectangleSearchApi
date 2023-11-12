using System.Linq.Expressions;
using System.Net;
using Moq;
using Project.Core.Models;
using Project.Core.Utilities.Results;
using Project.Infrastructure.Repositories.Abstraction;
using Project.Service.Services.Implementation;
using Project.Service.ViewModels;

namespace Rectangle.Tests
{
    public class RectangleServiceTests
    {
        [Fact]
        public void GetAllRectangles_Should_Return_Valid_Result()
        {
            // Arrange
            var rectangleRepository = new Mock<IRectangleRepository>();
            var rectangleService = new RectangleService(rectangleRepository.Object);

            var coordinate = new SearchCoordinateDto { X = 1, Y = 1 };
            var coordinates = new List<SearchCoordinateDto>
            {
                coordinate
            };

            var rectangles = new List<RectangleModel>
            {
                new RectangleModel(0, 0),
                new RectangleModel(0, 1),
                new RectangleModel(1,0 ),
                new RectangleModel(1, 1),
            };

            var resultCoordinates = new List<CoordinateDto>
            {
                new CoordinateDto(coordinate.X, coordinate.Y)
                {
                    Rectangles = rectangles,
                    RectangleCount = rectangles.Count
                }
            };

            var result = new Result
            {
                Data = resultCoordinates,
                Success = true,
                StatusCode = (int)HttpStatusCode.OK
            };

            rectangleRepository
                .Setup(r => r.GetAllAsNoTracking(It.IsAny<Expression<Func<RectangleModel, bool>>>()))
                .Returns(resultCoordinates[0].Rectangles.AsQueryable());

            // Act
            var actualResult = rectangleService.GetAllRectangles(coordinates);

            // Assert
            Assert.NotNull(actualResult);
            Assert.True(actualResult.Success);
            Assert.Equal((int)HttpStatusCode.OK, actualResult.StatusCode);

            var data = Assert.IsType<List<CoordinateDto>>(result.Data);

            Assert.Single(data);
            var resultRectangle = data[0];
            Assert.Equal(resultRectangle.RectangleCount, rectangles.Count);
            Assert.Equal(resultRectangle.Rectangles, rectangles.AsEnumerable());
        }

        [Fact]
        public void GetAllRectangles_Should_Handle_Exception()
        {
            // Arrange
            var rectangleRepository = new Mock<IRectangleRepository>();
            var rectangleService = new RectangleService(rectangleRepository.Object);

            var coordinates = new List<SearchCoordinateDto>
            {
                new SearchCoordinateDto { X = 1, Y = 1 },
                new SearchCoordinateDto { X = 2, Y = 2 }
            };

            var result = new Result()
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Error = "Simulated exception"
            };

            rectangleRepository.Setup(r => r.GetAllAsNoTracking(It.IsAny<Expression<Func<RectangleModel, bool>>>()))
                                .Throws(new Exception("Simulated exception"));

            // Act
            var actualResult = rectangleService.GetAllRectangles(coordinates);

            // Assert
            Assert.NotNull(actualResult);
            Assert.False(actualResult.Success);
            Assert.Equal((int)HttpStatusCode.BadRequest, actualResult.StatusCode);
            Assert.NotNull(actualResult.Error);
            Assert.Contains("Simulated exception", actualResult.Error);
        }
    }
}