using System.Text.Json; // för att kunna serializera och deserializera json-data

namespace posts
{
    public class JsonPostStorage : IPostStorage //klassen implementerar interfacet
    {
        //det här fältet tilldelas när objektet av det skapas via konstruktorn
        private readonly string file;

        //konstruktor
        public JsonPostStorage(string file)
        {
            this.file = file;
        }

        //implementerar metoderna Load och Save från interfacet
        public List<Post> Load()
        {
            //om fil ej existerar så returnera en ny lista med Post
            if (!File.Exists(file))
            {
                return new List<Post>();
            }

            //Om filen finns så läs filen som en json-sträng
            string jsonString = File.ReadAllText(file);

            //returnera den deserializerade jsonsträngen eller tom lista om ej funkar
            return JsonSerializer.Deserialize<List<Post>>(jsonString) ?? new List<Post>();

        }
        public void Save(List<Post> posts)
        {
            //Serializera till jsonformat
            string jsonString = JsonSerializer.Serialize(posts);
            //spara den serializerade strängen i jsonfilen 
            File.WriteAllText(file, jsonString);
        }
    }
}