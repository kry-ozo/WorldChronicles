using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KronikiPodwalaV2.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public bool isReported { get; set; }
        public string CommentOwner { get; set; }
        public int CommentedEvent { get; set; }
        public AppUser Owner { get; set; }
        public EventModel Event { get; set; }
    }
}
