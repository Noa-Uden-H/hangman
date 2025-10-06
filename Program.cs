using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] gallows = {
@"
  +---+
  |   |
      |
      |
      |
      |
=========
",
@"
  +---+
  |   |
  O   |
      |
      |
      |
=========
",
@"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========
",
@"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========
",
@"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========
",
@"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========
",
@"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
=========
"
            };
            Word word = new Word();
            word.show_word();
            Console.Write(gallows[0]);
        }
    }
    class Word
    {
        char[] word;
        string[] wordlist = {"apple", "river", "mountain", "dream", "light", "forest", "shadow", "ocean", "storm", "music", "flame", "whisper", "mirror", "stone", "gold", "silver", "cloud", "garden", "path", "wind", "star", "flower", "sand", "sky", "rain", "tree", "valley", "island", "echo", "fire", "wave", "heart", "night", "sun", "moon", "bird", "leaf", "glass", "snow", "rose", "bridge", "tower", "field", "door", "voice", "dreamer", "seed", "song", "time", "hope", "biatch"};
        char[] correct_guesses;
        int letter_pos;

        public Word()
        {
            string temp_word = randomize();
            word = temp_word.ToCharArray(0,temp_word.Length);
        }

        public string randomize()
        {
            Random rnd = new Random();
            return wordlist[rnd.Next(0, wordlist.Length)];
        }

        public void show_word()
        {
            Console.WriteLine(word);
        }
    }

    class Wrong_guesses
    {
        int num_wrong = 0;
        char[] wrong_guesses;
    }
}
