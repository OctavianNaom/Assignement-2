namespace Entities;

public class Comment
{public int CommentId { get; set; }
    public string Content { get; set; }
    public DateTime DateCreated { get; set; }

        
    public int PostId { get; set; }
    public Post Post { get; set; }

    public int AuthorId { get; set; }
    public User Author { get; set; }

       
    public ICollection<Vote> Votes { get; set; }
   
}