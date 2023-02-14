using System.ComponentModel.DataAnnotations.Schema;

namespace eastnetic.Shared.DTO
{
    public class SubElementDto
    {
        public int Id { get; set; }
        public int WindowId { get; set; }
        public string Window { get; set; } = string.Empty;
        public int Element { get; set; }
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}