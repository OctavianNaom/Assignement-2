namespace Entities;

public class SubForum
{
    public bool SubForumId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

  
    public ICollection<Post> Posts { get; set; }
}