namespace posts
{
    public class PostManage
    {
        private readonly IPostStorage storage; // Referens till objekt som implementerar IPostStorage
        private List<Post> posts; //Referens till lista med Post-objekt


        public PostManage(IPostStorage storage)
        {
            this.storage = storage;
            posts = storage.Load();
        }

        //Lägg till poster
        public Post AddPost(string name, string postText)
        {
            Post newPost = new Post(); //skapar instans av Post
            //sätter värdena för namn och postText 
            newPost.Name = name;
            newPost.PostText = postText;
            posts.Add(newPost);//lägger till i listan posts 
            //anropa metod från interface för att spara i jsonfil här
            storage.Save(posts);
            return newPost;
        }

        //Hämta poster
        public List<Post> GetPosts()
        {
            return posts; //returnerar listan med posts
        }
    }


}