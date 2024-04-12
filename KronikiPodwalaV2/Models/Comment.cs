using System.ComponentModel.DataAnnotations;

namespace KronikiPodwalaV2.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public bool isReported { get; set; }
        public string CommentOwner { get; set; }
        public int CommentedEvent { get; set; }
        public AppUser Owner { get; set; }
        public EventModel Event { get; set; }
    }
}
