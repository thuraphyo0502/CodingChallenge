using System.Text;

namespace CodingChallenge.Modules
{
    public class OldPhoneKeyPad
    {
        // define special characters
        private const char Backspace = '*';
        private const char Endofinput = '#';
        private const char Delay = ' ';

        // store the key pad mappings in an array
        private static readonly string[] keyPadMappging = [
            " ",
            "&'(",
            "ABC",
            "DEF",
            "GHI",
            "JKL",
            "MNO",
            "PQRS",
            "TUV",
            "WXYZ"
        ];

        /// <summary>
        /// Starts an interactive loop that prompts the user to input a numeric sequence representing
        /// old phone keypad presses and writes the converted text to the console. The loop continues
        /// indefinitely; a valid input must end with the configured end-of-input character ('#').
        /// </summary>
        public static void Process()
        {
            // The program will keep running and asking for input until the user explicitly exits
            while (true)
            {
                Console.WriteLine("Input the number to change letter(end with '#'):");
                string input = Console.ReadLine() ?? string.Empty;

                if (IsValidInput(input))
                {
                    Console.WriteLine(ConvertToText(input));
                }
                else
                {
                    Console.WriteLine("Please input a valid number sequence ending with '#'.");
                }
            }
        }

        /// <summary>
        /// Converts a sequence of numeric keypad presses into the corresponding text using
        /// old-style multi-tap phone keypad mappings. Special characters are interpreted as:
        /// '*' for backspace, ' ' (space) as a delay between presses, and '#' to mark the end
        /// of input. Consecutive identical digits represent multiple presses of the same key.
        /// </summary>
        /// <param name="input">The input string containing digits, special characters and ending with '#'.</param>
        /// <returns>The converted text produced by interpreting the keypad presses.</returns>
        public static string ConvertToText(string input)
        {
            StringBuilder convertedText = new();
            for (int charIndex = 0; charIndex < input.Length; charIndex++)
            {
                char currentKey = input[charIndex];

                if (currentKey == Endofinput)
                {
                    // Go to the end and stop from loop
                    break;
                }
                else if (currentKey == Backspace)
                {
                    RemoveLastCharacter(ref convertedText);
                    // Go to the next and read the next char
                    continue;
                }
                else if (currentKey == Delay)
                {
                    // Go to the next and read the next char
                    continue;
                }

                // Determine the presses is the same key?
                int sameCharCount = 0;
                for (int nextCharIndex = charIndex; nextCharIndex < input.Length; nextCharIndex++)
                {
                    // if the next char is space or not equal, then stop from loop
                    if (input[nextCharIndex] == Delay || input[nextCharIndex] != currentKey)
                        break;

                    // if the current char and the next char is same, then increase same char count
                    if (input[nextCharIndex] == currentKey)
                        sameCharCount++;
                }

                // Check the key is a digit?
                if (char.IsDigit(currentKey))
                {
                    // Convert char to int to take the value from keyPadMappgings
                    int keyPadIndex = currentKey - '0';

                    // keyPadIndex must be between 0 and 9
                    if (keyPadIndex >= 0 && keyPadIndex <= 9)
                    {
                        // Take the letters by keyPadIndex, E.g., key '2' -> "ABC"
                        string letters = keyPadMappging[keyPadIndex];

                        if (letters.Length == 0)
                            continue;

                        // array start from index 0 and substract 1 from sameCharCount
                        int letterIndex = (sameCharCount - 1) % letters.Length;
                        convertedText.Append(letters[letterIndex]);
                    }
                }

                // Skip processed char
                charIndex += sameCharCount - 1;
            }

            return convertedText.ToString();
        }

        /// <summary>
        /// Validates the raw input string. Returns true when the input is non-empty and
        /// ends with the configured end-of-input character ('#').
        /// </summary>
        /// <param name="input">The raw input string read from the console.</param>
        /// <returns>True when the input is not null or empty and ends with '#', otherwise false.</returns>
        private static bool IsValidInput(string input)
        {
            return !string.IsNullOrEmpty(input) && input.EndsWith(Endofinput);
        }

        /// <summary>
        /// Removes the last character from the provided StringBuilder if it contains at least
        /// one character. The StringBuilder is passed by reference and modified in place.
        /// </summary>
        /// <param name="result">The StringBuilder instance to modify by removing its last character.</param>
        private static void RemoveLastCharacter(ref StringBuilder result)
        {
            if (result.Length > 0)
            {
                // Remove the last character
                result.Length--;
            }
        }
    }
}