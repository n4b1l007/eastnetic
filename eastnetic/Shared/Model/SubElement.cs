using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eastnetic.Shared.Model
{
    public class SubElement
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Window")]
        public int WindowId { get; set; }

        public int Element { get; set; }
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Window Window { get; set; }
    }
}