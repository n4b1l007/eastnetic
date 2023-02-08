using System.ComponentModel.DataAnnotations;

namespace eastnetic.Shared.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string State { get; set; }

        public List<Window> Windows { get; set; }
    }
}