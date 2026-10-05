using System;

namespace posts
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;

           // while (true)
           // {
                PostManage manage = new PostManage(); //objekt av postmanage 
                Console.Clear(); //rensa konsoll
                Console.WriteLine("Gästbok: ");

                Console.WriteLine("Skriv ditt namn: ");
                string? name = Console.ReadLine()?.Trim();

                //Felhantering om name är tomt

                Console.WriteLine("Skriv ditt inlägg: ");
                string? text = Console.ReadLine()?.Trim();

                //felhantering om text är tomt 
               if(!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(text))
                {
                    Post addedPost = manage.AddPost(name, text);
                    Console.WriteLine(addedPost.Name);
                    Console.WriteLine(addedPost.PostText);
                } 

            //}
        }
    }
}
