using System.ComponentModel.DataAnnotations;

namespace KronikiPodwalaV2.Models
{
    public class EventModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string EventDescription { get; set; }
        [Required]
        public int EventYear { get; set; }

    }
}
