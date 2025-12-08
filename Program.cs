using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    public static class Globals
    {
        public static string[] gallows = {
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
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Word word = new Word();
            Mistakes mistakes = new Mistakes();
            word.show_word();
            word.show_correct_guesses();
            Console.Write(Globals.gallows[0]);

            word.guess(mistakes);

            word.show_correct_guesses();
        }

    }
    
    class Word
    {
        char[] word;
        string[] wordlist = {"apple", "river", "mountain", "dream", "light", "forest", "shadow", "ocean", "storm", "music", "flame", "whisper", "mirror", "stone", "gold", "silver", "cloud", "garden", "path", "wind", "star", "flower", "sand", "sky", "rain", "tree", "valley", "island", "echo", "fire", "wave", "heart", "night", "sun", "moon", "bird", "leaf", "glass", "snow", "rose", "bridge", "tower", "field", "door", "voice", "dreamer", "seed", "song", "time", "hope", "biatch"};
        char[] correct;

        public Word()
        {
            string temp_word = randomize();
            word = temp_word.ToCharArray(0,temp_word.Length);

            correct = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                correct[i] = '_';
            }
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

        public void show_correct_guesses()
        {
            for (int i = 0; i < correct.Length; i++)
            {
                Console.Write(correct[i]);
                Console.Write(" ");
            }
        }

        public void guess(Mistakes mistakes)
        {
            Console.WriteLine("Guess: ");
            char guess = Char.ToLower(Convert.ToChar(Console.ReadLine()));

            if (word.Contains(guess))
            {
                guess_loop(guess);
            }
            else
            {
                mistakes.wrong_guess(guess);
            }
        }

        private void guess_loop(char guess)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == guess)
                {
                    correct[i] = guess;
                }
            }
        }
    }

    class Mistakes
    {
        private int num_wrong = 0;
        public int Num_wrong
        {
            get { return num_wrong; }
            set { num_wrong = value; }
        }
        private List<char> wrong_guesses = new List<char>();
        public List<char> Wrong_guesses
        {
            get { return wrong_guesses; }
        }

        public void wrong_guess(char letter)
        {
            num_wrong++;
            wrong_guesses.Append(letter);
        }
    }
}
