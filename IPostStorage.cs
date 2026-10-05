namespace posts
{
    //Ett interface för lagring av poster
    public interface IPostStorage
    {
        List<Post> Load(); //metod för att ladda poster som returnerar Lista av Post
        void Save(List<Post> posts); // metod för att spara poster som tar emot Post lista
    }
}