using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HangmanConsole
{
    class Hangman
    {
        static void Main(string[] args)
        {
            IWord playingWord;
            playingWord = ChoseLanguage();

            Play(playingWord);
        }

        static public IWord ChoseLanguage()
        {
            string userEntry;
            do
            {
                Console.WriteLine("Choose your language : FR | EN");
                userEntry = Console.ReadLine();
            }while(userEntry == "FR" && userEntry == "EN");
            switch (userEntry)
            {
                case "FR" :
                    return new WordFR();
                case "EN"  : 
                    return new WordEN();
                default:
                    return new WordEN();
            }
        }

        static public void Play(IWord play)
        {
            string userString;
            char charEnter;
            do
            {
                Console.Clear();
                Console.WriteLine("Hp left : {0}", play.getHp());
                Console.WriteLine(play.ToString());
                Console.WriteLine("Type a letter");
                userString = Console.ReadLine();
                charEnter = userString[0];
                charEnter = char.ToUpper(charEnter);

                if ( charEnter >= 'A' && charEnter <= 'Z')
                {
                    if ( !play.CharacterCheck(charEnter) )
                    {
                        play.HpRemove();
                    }
                }
            }while(play.getHp() != 0 && play.CharacterRemaining() != 0);

            if ( play.getHp() == 0)
            {
                Console.Clear();
                Console.WriteLine(play.LoseMessage());
            } else
            {
                Console.Clear();
                Console.WriteLine(play.WinMessage());
            }
        }
    }
}
