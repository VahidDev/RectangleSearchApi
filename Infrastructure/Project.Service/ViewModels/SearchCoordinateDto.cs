using System.ComponentModel.DataAnnotations;

namespace Project.Service.ViewModels
{
    public class SearchCoordinateDto
    {
        [Required]
        public int X { get; set; }
        [Required]
        public int Y { get; set; }
    }
}
