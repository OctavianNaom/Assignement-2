namespace Entities;

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime DateCreated { get; set; }

    
    public int AuthorId { get; set; }
    public User Author { get; set; }

    public int SubForumId { get; set; }
    public SubForum SubForum { get; set; }


    public ICollection<Comment> Comments { get; set; }
    public ICollection<Vote> Votes { get; set; }
}