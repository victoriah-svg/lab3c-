/*
* Författare: Victoria Helin
* Datum 2026-10-05
* Kurs: Programmering i C# .NET DT071G
* 
* Beskrivning: 
* Programmet ger användaren möjlighet att skapa och radera inlägg i en gästbok.
* Inläggen sparas via serializering till json-format.
*/

using System;
using System.Linq.Expressions;

namespace posts
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0; 
            string? name;
            string? text;
            string? index;



            //lagrar referenst till objekt av JsonPostStorage i variabeln management
            IPostStorage management = new JsonPostStorage("poststore.json");
            //Skickar in referensen i konstruktorn för PostManage
            PostManage manage = new PostManage(management);

            //Oändlig loop (avslutas när någon avslutar programmet genom att klicka X-tangenten)
            while (true)
            {
                Console.Clear(); //rensa konsoll
                Console.WriteLine("Gästbok: "); //Skriv ut i konsoll
                Console.WriteLine("1. Skriv i gästboken");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("X. Avsluta");

                i = 0;

                //Skriver ut poster från listan 
                foreach (Post post in manage.GetPosts())
                {
                    Console.WriteLine($"[ {i++} ] {post.Name} - {post.PostText}");
                }
                //läser in värdet på tangenten 
                int input = (int)Console.ReadKey(true).Key;

                //Kontroll vilket tangentval som gjorts
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

                        //loop som körs minst 1 gång och så länge text är tomt 
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
                        break;

                    case '2': //val nr 2

                        //loopn som körs minst 1 gång och så länge som index är tomt
                        do
                        {
                            Console.WriteLine("Vilket index vill du radera?");
                            index = Console.ReadLine();
                            
                            if (string.IsNullOrWhiteSpace(index)) //om index är tomt skriv ut felmeddelande
                            {
                                Console.WriteLine("Du måste ange ett index");
                            }
                            else //annars - försök konvertera index till int 
                            {
                                try {
                                    manage.DeletePost(Convert.ToInt32(index));
                                }catch(Exception) //om indexet ej matchar så skriv ut felmeddelande 
                                {
                                    Console.WriteLine("Indexet du valt finns inte. Klicka på någon tangen och börja om");
                                    Console.ReadLine();
                                }
                            }
                        } while (string.IsNullOrWhiteSpace(index));

                        break;

                    case 88: //val X
                        Environment.Exit(0); //Avsluta programm
                        break;

                }


            }
        }
    }
}
