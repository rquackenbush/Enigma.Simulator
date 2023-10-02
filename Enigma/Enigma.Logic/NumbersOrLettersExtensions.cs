﻿namespace Enigma.Logic
{
    public static class NumbersOrLettersExtensions
    {
        public static int[] ToInidicies(this NumbersOrLetters numberOrLetters, Alphabet alphabet)
        {
            if (numberOrLetters is null) throw new ArgumentNullException(nameof(numberOrLetters));
            if (alphabet is null) throw new ArgumentNullException(nameof(alphabet));

            if (numberOrLetters.Numbers == null && string.IsNullOrWhiteSpace(numberOrLetters.Letters))
                throw new InvalidOperationException("Please specify either NUmbers or Letters.");

            if (numberOrLetters.Numbers != null && !string.IsNullOrWhiteSpace(numberOrLetters.Letters))
                throw new InvalidOperationException("Please specify ONLY Numbers or Letters.");

            int[] indicies;

            if (numberOrLetters.Numbers != null)
            {
                indicies = new int[numberOrLetters.Numbers.Length];

                for(int i = 0; i < numberOrLetters.Numbers.Length; i++)
                {
                    var number = numberOrLetters.Numbers[i];

                    if (number > alphabet.Count)
                        throw new InvalidOperationException($"Number {number} does not represent a letter in the alphabet which has {alphabet.Count} characters.");

                    indicies[i] = number - 1;
                }
            }
            else
            {
                indicies = new int[numberOrLetters.Letters.Length];

                for(int i = 0; i < numberOrLetters.Letters.Length; i++)
                {
                    indicies[i] = alphabet.IndexOf(numberOrLetters.Letters[i]);
                }
            }

            return indicies;
        }
    }
}