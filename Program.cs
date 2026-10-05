using System;

namespace posts
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            string? name;
            string? text;



           // PostManage manage = new PostManage(); //objekt av postmanage 
           IPostStorage management = new JsonPostStorage("poststore.json");
           PostManage manage = new PostManage(management);
            while (true)
            {
                Console.Clear(); //rensa konsoll
                Console.WriteLine("Gästbok: "); //Skriv ut i konsoll
                Console.WriteLine("1. Skriv i gästboken");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("X. Avsluta");
                
                i= 0; 
                //Skriver ut poster från listan 
                foreach(Post post in manage.GetPosts())
                {
                    Console.WriteLine($"[ {i++} ] {post.Name} - {post.PostText}");
                }
                //läser in värdet på tangenten 
               int input = (int)Console.ReadKey(true).Key;

                switch (input)
                {
                    case '1': //val nr 1
                        //körs alltid minst en gång
                        do
                        {
                            Console.WriteLine("Skriv ditt namn: ");
                            name = Console.ReadLine()?.Trim(); //läser in namn och sparar i name variabel

                            //Felhantering om name är tomt
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("Du måste fylla i ett namn");
                            }

                        } while (string.IsNullOrWhiteSpace(name)); //sålänge som namn är tomt eller whitespace

                        do
                        {
                            Console.WriteLine("Skriv ditt inlägg: ");
                            text = Console.ReadLine()?.Trim();

                            if (string.IsNullOrWhiteSpace(text)) //om text är tomt skriv ut felmeddelande
                            {
                                Console.WriteLine("Du måste skriva något för att göra ett inlägg");
                            }


                        } while (string.IsNullOrWhiteSpace(text)); //loop körs sålänge som text är tomt eller whitespace

                        //När namn och text är korrekt ifyllt anropas AddPost med name och text som fyllts i 
                        Post addedPost = manage.AddPost(name, text);
                        Console.WriteLine(addedPost.Name);
                        Console.WriteLine(addedPost.PostText);
                        break;

                    case '2':
                        Console.WriteLine("Du har valt nr 2");
                        Console.ReadKey();
                        break;

                    case 88:
                        Environment.Exit(0);
                        break;
                }


            }
        }
    }
}
