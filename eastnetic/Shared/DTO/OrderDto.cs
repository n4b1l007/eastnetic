using System.ComponentModel.DataAnnotations;

namespace eastnetic.Shared.Model
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
    }
}