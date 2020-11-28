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
                Console.WriteLine("\nOdaberite akciju:\n1 - Ispis cijele liste\n2 - Ispis imena pjesme unosom pripadajućeg rednog broja\n3 - Ispis rednog broja pjesme unosom pripadajućeg imena\n4 - Unos nove pjesme\n5 - Brisanje pjesme po rednom broju\n6 - Brisanje pjesme po imenu\n7 - Brisanje cijele liste\n8 - Uređivanje imena pjesme\n9 - Uređivanje rednog broja pjesme, odnosno premještanje pjesme na novi redni broj u listi\n0 - Izlaz iz aplikacije");
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
                    case 6:
                        BrisanjePjesmePoImenu(dict);
                        break;
                    case 7:
                        BrisanjeListe(dict);
                        break;
                    case 8:
                        UrediIme(dict);
                        break;
                    case 9:
                        UrediRedniBroj(dict);
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
            foreach (var song in dict)
            {
                if (songName == song.Value) 
                {
                    Console.WriteLine("Ne mozete dodati pjesmu koja vec postoji u listi.");
                    return; 
                }
            }
            if (Console.ReadLine() == "da")
            {
                dict.Add(index, songName);
            }
        }
        static void BrisanjePjesmePoRednomBroju(Dictionary<int, string> dict) //TU SI BURAZ
        {   
            Console.WriteLine("Pjesmu po kojem rednom broju zelite izbrisati?");
            var index = int.Parse(Console.ReadLine());
            var tempDict = new Dictionary<int, string>();
            Console.WriteLine("Jeste li sigurni da zelite ukloniti pjesmu na broju " + index + "? (da/ne)");
            if (Console.ReadLine() == "da")
            {
                if (dict.Remove(index))
                {
                    Console.WriteLine("Pjesma uspjesno izbrisana.");
                }
            }
            else return;

            foreach (var song in dict)
            {
                if (song.Key > index)
                {
                    tempDict.Add(song.Key, song.Value);
                    dict.Remove(song.Key);
                }
            }
            foreach (var song in tempDict)
            {
                dict.Add(song.Key - 1, song.Value);
            }
        }
        static void BrisanjePjesmePoImenu(Dictionary<int, string> dict)
        {
            Console.WriteLine("Pjesmu kojeg imena zelite izbrisati?");
            var songName = Console.ReadLine();
            var index = 0;
            var tempDict = new Dictionary<int, string>();
            Console.WriteLine("Jeste li sigurni da zelite ukloniti pjesmu " + songName + "? (da/ne)");
            foreach (var song in dict)
            {
                if (song.Value == songName)
                    index = song.Key;
            }
            if (Console.ReadLine() == "da")
            {
                if (dict.Remove(index))
                {
                    Console.WriteLine("Pjesma uspjesno izbrisana.");
                }
            }
            else
            {
                Console.WriteLine("Brisanje pjesme prekinuto.");
                return;
            }

            foreach (var song in dict)
            {
                if (song.Key > index)
                {
                    tempDict.Add(song.Key, song.Value);
                    dict.Remove(song.Key);
                }
            }
            foreach (var song in tempDict)
            {
                dict.Add(song.Key - 1, song.Value);
            }
            
        }
        static void BrisanjeListe(Dictionary<int, string> dict)
        {
            Console.WriteLine("Jeste li sigurni da zelite izbrisati cijelu listu?(da/ne) ");
            var sure = Console.ReadLine();
            if (sure == "da")
            {
                dict.Clear();
                Console.WriteLine("Brisanje liste uspjesno.");
            }
            else
            {
                Console.WriteLine("Brisanje liste prekinuto.");
                return;
            }
        }
        static void UrediIme(Dictionary<int, string> dict)
        {
            var index = 0;
            var tempDict = new Dictionary<int, string>();
            Console.WriteLine("Unesite ime pjesme koje zelite urediti: ");
            var songName = Console.ReadLine();
            Console.WriteLine("Jeste li sigurni da zelite urediti ime pjesme " + songName + "?(da/ne)");
            var sure = Console.ReadLine();

            if (sure == "da")
            {
                Console.WriteLine("Unesite novo ime pjesme: ");
                var newSongName = Console.ReadLine();
                foreach (var song in dict)
                {
                    if (songName == song.Value)
                    {
                        index = song.Key;
                        dict.Remove(index);
                    }
                }
                foreach (var song in dict)
                {
                    if (song.Key > index)
                    {
                        tempDict.Add(song.Key, song.Value);
                        dict.Remove(song.Key);
                    }
                }
                dict.Add(index, newSongName);
                foreach (var song in tempDict)
                {
                    if (song.Key > index)
                    {
                        dict.Add(song.Key, song.Value);
                    }
                }
                Console.WriteLine("Uredivanje imena pjesme uspjesno.");
            }
            else 
            {
                Console.WriteLine("Uredivanje imena pjesme prekinuto.");
                return;
            }
        }
        static void UrediRedniBroj(Dictionary<int, string> dict)
        {
            var tempDictBetween = new Dictionary<int, string>();
            var tempDictAfter = new Dictionary<int, string>();
            var tempKey1 = 0;
            var tempName1 = "";
            var tempKey2 = 0;
            var tempName2 = "";
            int counter = 0;
            Console.WriteLine("Kojoj pjesmi zelite urediti redni broj?(na kojem rednom broju)");
            var index = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite novi redni broj pjesme: ");
            var newIndex = int.Parse(Console.ReadLine());
            Console.WriteLine("Jeste li sigurni da zelite promijeniti redni broj pjesme iz " + index + " u " + newIndex + "?(da/ne)");
            var sure = Console.ReadLine();
            if (sure == "da")
            {
                if (index < newIndex)
                {
                    foreach (var song in dict)
                    {
                        if (song.Key == index)
                        {
                            tempKey1 = song.Key;
                            tempName1 = song.Value;
                            dict.Remove(song.Key);
                        }
                        else if (song.Key == newIndex)
                        {
                            tempKey2 = song.Key;
                            tempName2 = song.Value;
                            dict.Remove(song.Key);
                        }
                        else if (song.Key > index && song.Key < newIndex)
                        {
                            tempDictBetween.Add(song.Key, song.Value);
                            dict.Remove(song.Key);
                        }
                        else if (song.Key > newIndex)
                        {
                            tempDictAfter.Add(song.Key, song.Value);
                            dict.Remove(song.Key);
                        }
                    }
                    counter++;
                    dict.Add(counter, tempName2);
                    foreach (var song in tempDictBetween)
                    {
                        counter++;
                        dict.Add(counter, song.Value);
                    }
                    counter++;
                    dict.Add(counter, tempName1);
                    foreach (var song in tempDictAfter)
                    {
                        counter++;
                        dict.Add(counter, song.Value);
                    }
                }
                else if (index > newIndex)
                {
                    foreach (var song in dict)
                    {
                        if (song.Key == index)
                        {
                            tempKey1 = song.Key;
                            tempName1 = song.Value;
                            dict.Remove(song.Key);
                        }
                        else if (song.Key == newIndex)
                        {
                            tempKey2 = song.Key;
                            tempName2 = song.Value;
                            dict.Remove(song.Key);
                        }
                        else if (song.Key > newIndex && song.Key < index)
                        {
                            tempDictBetween.Add(song.Key, song.Value);
                            dict.Remove(song.Key);
                        }
                        else if (song.Key > index)
                        {
                            tempDictAfter.Add(song.Key, song.Value);
                            dict.Remove(song.Key);
                        }
                    }
                    counter++;
                    dict.Add(counter, tempName2);
                    foreach (var song in tempDictBetween)
                    {
                        counter++;
                        dict.Add(counter, song.Value);
                    }
                    counter++;
                    dict.Add(counter, tempName1);
                    foreach (var song in tempDictAfter)
                    {
                        counter++;
                        dict.Add(counter, song.Value);
                    }
                }
            }
        }
    }
}
