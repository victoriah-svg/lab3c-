namespace posts
{
    public class PostManage
    {
        private readonly IPostStorage storage; // Referens till objekt som implementerar IPostStorage
        private List<Post> posts; //Referens till lista med Post-objekt

        //Konstruktor
        public PostManage(IPostStorage storage)
        {
            this.storage = storage; // Sparar en referens till storage-objektet för att kunna använda det senare 
            posts = storage.Load(); //läser in inlägg och lägger i posts
        }

        //Lägg till poster
        public Post AddPost(string name, string postText)
        {
            Post newPost = new Post(); //skapar instans av Post
            //sätter värdena för namn och postText med argument som skickats med
            newPost.Name = name;
            newPost.PostText = postText;
            posts.Add(newPost);//lägger till i listan posts 
            //anropa metod från interface för att spara i jsonfil
            storage.Save(posts);
            return newPost;
        }

        //Ta bort post med specifikt id
        public int DeletePost(int indexToDelete)
        {
            posts.RemoveAt(indexToDelete); //tar bort post med medskickat index från listan
            storage.Save(posts); //sparar om den ändrade listan 
            return indexToDelete; //returnerar
        }

        //Hämta poster
        public List<Post> GetPosts()
        {
            return posts; //returnerar listan med posts
        }
    }


}