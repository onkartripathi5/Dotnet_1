using System.ComponentModel.DataAnnotations;

namespace StudentM.Models
{
    public class Car
    {
        public int Id { set; get; }
        [Required]
        public string Brand { set; get; }
        [Required]
        public string Model { set; get; }
        [Required]
        public string Number { set; get; }
        [Required]
        public string TopSpeed { set; get; }
    
    }
}