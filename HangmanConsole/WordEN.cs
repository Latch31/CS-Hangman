using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;


namespace HangmanConsole
{
    public class WordEN : IWord
    {
        string wordChoose;
        string playingWord;
        int hp;

        public WordEN()
        {
            Random rng = new Random();
            JObject jFile = JObject.Parse(File.ReadAllText(@".\ENWord.json"));
            IList<JToken> jFileList = jFile["Word"].Children().ToList();
            IList<String> wordList = new List<String>();

            foreach (JToken i in jFileList)
            {
                String patate = i.ToObject<String>();
                wordList.Add(patate);
            }

            wordChoose = wordList[rng.Next(0, wordList.Count())];
            playingWord = BlankString(wordChoose);
            hp = 6;
        }
        public bool CharacterCheck(char pChar)
        {
            StringBuilder tWord = new StringBuilder(playingWord);
            bool oneFound = false;
            for ( int i = 0; i < wordChoose.Length; i++)
            {
                if ( playingWord[i] == '_' )
                {
                    if ( wordChoose[i] == Char.ToUpper(pChar))
                    {
                        tWord[i] = Char.ToUpper(pChar);
                        oneFound = true;
                    }
                }
            }
            playingWord = tWord.ToString();
            return oneFound;
        }
        public int CharacterRemaining()
        {
            int nbWord = 0;
            foreach( char c in playingWord)
            {
                if ( c == '_')
                {
                    nbWord++;
                }
            }
            return nbWord;
        }
        public string BlankString(string word)
        {
            string blank = "";
            foreach ( char i in word )
            {
                blank += "_";
            }
            return blank;
        }
        public void HpRemove()
        {
            this.hp = hp-1;
        }
        public int getHp()
        {
            return hp;
        }
        public override string ToString()
        {
            return this.playingWord;
        }

        public string LoseMessage()
        {
            return ("-- YOU LOSE -- \nThe word was " + this.playingWord + "\n\nPlay Again ?");
        }
        public string WinMessage()
        {
            return ("-- YOU WIN !!! -- \nYou find the word " + this.playingWord + "\n\nPlay Again ?");
        }
    }
}