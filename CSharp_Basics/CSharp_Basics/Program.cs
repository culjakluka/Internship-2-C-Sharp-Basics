using System;
using System.Collections.Generic;

namespace CSharp_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<int, string>();
            var action = 1;
           
            while (action != 0) 
            {
                Console.WriteLine("Odaberite akciju:\n-1 - Ispis cijele liste\n2 - Ispis imena pjesme unosom pripadajućeg rednog broja\n3 - Ispis rednog broja pjesme unosom pripadajućeg imena\n4 - Unos nove pjesme\n5 - Brisanje pjesme po rednom broju\n6 - Brisanje pjesme po imenu\n7 - Brisanje cijele liste\n8 - Uređivanje imena pjesme\n9 - Uređivanje rednog broja pjesme, odnosno premještanje pjesme na novi redni broj u listi\n0 - Izlaz iz aplikacije");
                action = int.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        IspisListe(dict);
                        break;
                    case 2:
                        IspisPoBroju(dict);
                        break;
                    case 3:
                        IspisPoImenu(dict);
                        break;
                    case 4:
                        UnosPjesme(dict);
                        break;
                    case 5:
                        BrisanjePjesmePoRednomBroju(dict);
                        break;
                    default:
                        break;
                }
            }
        }
        static void IspisListe(Dictionary<int, string> dict) 
        {
            foreach (var song in dict)
            {
                Console.WriteLine(song.Key + ". " + song.Value);
            }
        }
        static void IspisPoBroju(Dictionary<int, string> dict)
        {
            Console.WriteLine("Unesite redni broj pjesme za koju zelite saznati ime: ");
            var songNumber = int.Parse(Console.ReadLine());
            var succ = 0;

            foreach (var song in dict)
            {
                if (song.Key == songNumber) 
                { 
                    Console.WriteLine("Trazena pjesma se zove: " + song.Value);
                    succ = 1;
                }
            }
            if (0 == succ) { Console.WriteLine("Pjesma nije nadena!"); }
        }
        static void IspisPoImenu(Dictionary<int, string> dict)
        {
            Console.WriteLine("Unesite ime pjesme za koji zelite saznati redni broj: ");
            var songName = Console.ReadLine();
            var succ = 0;

            foreach(var song in dict)
            {
                if (song.Value == songName) 
                {
                    Console.WriteLine("Trazena pjesma je na broju: " + song.Key);
                    succ = 1;
                }
            }
            if (0 == succ) { Console.WriteLine("Pjesma nije nadena!"); }
        }
        static void UnosPjesme(Dictionary<int, string> dict)
        {
            Console.WriteLine("Unesite ime pjesme: ");
            var songName = Console.ReadLine();            
            var index = 1;
            foreach (var song in dict)
            {
                index++;
            }
            Console.WriteLine("Jeste li sigurni da zelite dodati pjesmu " + "'" + songName + "' u listu? (da/ne)");
            if (Console.ReadLine() == "da")
            {
                dict.Add(index, songName);
            }
        }
        static void BrisanjePjesmePoRednomBroju(Dictionary<int, string> dict) //TU SI BURAZ
        {   
            Console.WriteLine("Pjesmu po kojem rednom broju zelite izbrisati?");
            var index = int.Parse(Console.ReadLine());
            var tempKey = 0;
            var tempName = "";
            var tempDict = new Dictionary<int, string>();
            Console.WriteLine("Jeste li sigurni da zelite ukloniti pjesmu na broju " + index + "? (da/ne)");
            if (Console.ReadLine() == "da")
            {
                if (dict.Remove(index))
                {
                    Console.WriteLine("Pjesma uspjesno izbrisana.");
                }
            }
            foreach (var song in dict)
            {
             
            }
        }
    }
}
