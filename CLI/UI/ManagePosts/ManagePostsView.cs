using RepositoryContracts;
namespace CLI.UI.ManagePost
{
    public class ManagePostsView
    {
        private readonly IPostRepository _postRepository;

        public ManagePostsView(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task DisplayAsync()
        {
            Console.WriteLine("Managing Posts:");
            Console.WriteLine("1. Create a new post");
            Console.WriteLine("2. List all posts");
            Console.WriteLine("3. View a single post");
            Console.WriteLine("0. Go back");

            var input = Console.ReadLine();

            if (input == "1")
            {
                var createPostView = new CreatePostView(_postRepository);
                await createPostView.CreatePostAsync();
            }
            else if (input == "2")
            {
                var listPostView = new ListPostView(_postRepository);
                await listPostView.DisplayPostsAsync();
            }
            else if (input == "3")
            {
                Console.WriteLine("Enter post ID:");
                var postId = Convert.ToInt32(Console.ReadLine());
                var singlePostView = new SinglePostView(_postRepository, postId);
                await singlePostView.DisplayPostAsync();
            }
            else if (input == "0")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
                await DisplayAsync();
            }
        }
    }
}
