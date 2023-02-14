using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eastnetic.Shared.Model
{
    public class Window
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public string Name { get; set; }

        public int QuantityOfWindows { get; set; }

        [NotMapped]
        public int TotalSubElements
        {
            get
            {
                return SubElements.Count;
            }
        }

        public Order Order { get; set; }
        public List<SubElement> SubElements { get; set; }
    }
}