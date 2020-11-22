using System;
using System.Collections.Generic;

namespace CSharp_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<int, string>();
            var akcija = 1;
            Console.WriteLine("Odaberite akciju:\n1 - Ispis cijele liste\n2 - Ispis imena pjesme unosom pripadajućeg rednog broja\n3 - Ispis rednog broja pjesme unosom pripadajućeg imena\n4 - Unos nove pjesme\n5 - Brisanje pjesme po rednom broju\n6 - Brisanje pjesme po imenu\n7 - Brisanje cijele liste\n8 - Uređivanje imena pjesme\n9 - Uređivanje rednog broja pjesme, odnosno premještanje pjesme na novi redni broj u listi\n0 - Izlaz iz aplikacije");

            while (akcija != 0) 
            {
                akcija = int.Parse(Console.ReadLine());
                switch (akcija)
                {
                    case 1:
                        ispisListe(dict);
                        break;
                    case 2:
                        ispisPoBroju(dict);
                        break;
                    case 3:
                        ispisPoImenu(dict);
                        break;
                    default:
                        break;
                }
            }
        }
        static void ispisListe(Dictionary<int, string> dict) 
        {
            foreach (var song in dict)
            {
                Console.WriteLine(song.Key + ". " + song.Value);
            }
        }
        static void ispisPoBroju(Dictionary<int, string> dict)
        {
            Console.WriteLine("Unesite redni broj pjesme za koju zelite saznati ime: ");
            var broj = int.Parse(Console.ReadLine());
            var succ = 0;

            foreach (var song in dict)
            {
                if (song.Key == broj) 
                { 
                    Console.WriteLine("Trazena pjesma se zove: " + song.Value);
                    succ = 1;
                }
            }
            if (0 == succ) { Console.WriteLine("Pjesma nije nadena!"); }
        }
        static void ispisPoImenu(Dictionary<int, string> dict)
        {
            Console.WriteLine("Unesite ime pjesme za koji zelite saznati redni broj: ");
            var ime = Console.ReadLine();
            var succ = 0;

            foreach(var song in dict)
            {
                if (song.Value == ime) 
                {
                    Console.WriteLine("Trazena pjesma je na broju: " + song.Key);
                    succ = 1;
                }
            }
            if (0 == succ) { Console.WriteLine("Pjesma nije nadena!"); }
        }
    }
}
