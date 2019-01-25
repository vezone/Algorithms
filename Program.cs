using System;

namespace Algo_List
{

    class Algo_List
    {
        /// <summary>
        /// The Caesar's cipher
        /// </summary>
        /// <param name="input">Input string that you need encrypt or decipher</param>
        /// <param name="mode">Use 1 - encrypt, 2 - decipher</param>
        /// <returns></returns>
        public static string CaesarsCipher(
            string input,
            int mode)
        {
            char[] output = new char[input.Length];
            char[] inputChars = input.ToCharArray();
            if (mode == 1)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    int code = inputChars[i] + 3;
                    if ((code > 90 && code < 97) ||
                        (code > 122))
                    {
                        output[i] = (char)(code - 26);
                    }
                    else
                    {
                        output[i] = (char)(code);
                    }
                }
            }
            else if (mode == 2)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    int code = inputChars[i] - 3;
                    if ((code < 65) ||
                        (code < 97 && code > 90))
                    {
                        output[i] = (char)(code + 26);
                    }
                    else
                    {
                        output[i] = (char)(code);
                    }
                }
            }
            else
            {
                Console.WriteLine("You can use only 1 or 2 for paramter mode!");
                return "error";
            }

            return new string(output);
        }
        
        /// <summary>
        /// The Vegenere Cipher
        /// </summary>
        /// <param name="input">Input string that you need encrypt or decipher</param>
        /// <param name="mode">Use 1 - encrypt</param>
        /// <returns></returns>
        public static string VegenereCipher(
            string input,
            string encryptionWord,
            int mode)
        {
            int inputLength = input.Length;
            int encWordLength = encryptionWord.Length;
            if (encWordLength > inputLength)
            {
                Console.WriteLine("encWordLength should be greater then inputLength");
                return "error";
            }

            int code;
            char[] output = new char[inputLength];
            char[] inputChars = input.ToCharArray();
            char[] encWord = encryptionWord.ToCharArray();

            if (mode == 1)
            {
                for (int i = 0; i < inputLength; i++)
                {
                    code = inputChars[i] - (encWord[i%encWordLength] - 97);
                    if ((code < 65) ||
                        (code > 90 && code < 97))
                    {
                        output[i] = (char)(code + 26);
                    }
                    else
                    {
                        output[i] = (char)(code);
                    }
                }
            }
            else if (mode == 2)
            {
                for (int i = 0; i < inputLength; i++)
                {
                    code = inputChars[i] + (encWord[i % encWordLength] - 97);
                    if ((code < 97 && code > 90) ||
                        code > 122)
                    {
                        output[i] = (char)(code - 26);
                    }
                    else
                    {
                        output[i] = (char)code;
                    }
                }
            }
            else
            {
                Console.WriteLine("You can use only 1 for ecnription!");
                return "error";
            }

            return new string(output);
        }
            //

    }


    class Program
    {
        static void Main(string[] args)
        {
            //
            string newWord  = Algo_List.CaesarsCipher("Armor", 1);
            string reversed = Algo_List.CaesarsCipher(newWord, 2);
            Console.WriteLine("CC: " + newWord + "\n" + "reversed: " + reversed);

            newWord  = Algo_List.VegenereCipher("Armor", "hi", 1);
            reversed = Algo_List.VegenereCipher(newWord, "hi", 2);
            Console.WriteLine("VC: " + newWord + "\n" + "reversed: " + reversed);

            Console.Read();
        }
    }
}
