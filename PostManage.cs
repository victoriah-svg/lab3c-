namespace posts
{
    public class PostManage
    {
        private List<Post> posts; 

//Konstruktor 
        public PostManage()
    {
        posts = new List<Post>();
    }

         public Post AddPost(string name, string postText)
        {
            Post newPost = new Post(); //skapar instans av Post
            //sätter värdena för namn och postText 
            newPost.Name = name;
            newPost.PostText = postText;
            posts.Add(newPost);//lägger till i listan posts 
            return newPost;
        }
    }

   
}