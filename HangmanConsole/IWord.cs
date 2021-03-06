namespace HangmanConsole
{
    public interface IWord
    {
        bool CharacterCheck(char pChar); // check if a character is in the word
        int CharacterRemaining(); // return the number of character to find
        string BlankString(string word); // create the blank string for playing word
        void HpRemove(); // remoove 1 hp for the acutal word to find
        int getHp(); // return the number of hp remaining
        string ToString(); // return the word to guess in the state of player discovery
        string LoseMessage();
        string WinMessage();
    }
}