using eastnetic.Shared.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eastnetic.Shared.DTO
{
    public class WindowDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public string Order { get; set; } = string.Empty;

        public int QuantityOfWindows { get; set; }

        public int TotalSubElements { get; set; }
    }
}