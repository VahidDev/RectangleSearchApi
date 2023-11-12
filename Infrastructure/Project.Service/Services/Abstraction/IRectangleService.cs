using Project.Core.Utilities.Results;
using Project.Service.ViewModels;

namespace Project.Service.Services.Abstraction
{
    public interface IRectangleService
    {
        Result GetAllRectangles(IEnumerable<SearchCoordinateDto> coordinates);
    }
}
