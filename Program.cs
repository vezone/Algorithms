#define New //Past

using System;
using System.Collections.Generic;

namespace Algo_List
{

    class Algo_List
    {
        /// <summary>
        /// Шифр Цезаря
        /// </summary>
        /// <param name="input">Строка, которую требуется зашифровать или расшифровать</param>
        /// <param name="mode">1 - зашифровать, 0 - расшифровать</param>
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
        /// Шифр Виженера
        /// </summary>
        /// <param name="input">Строка, которую требуется зашифровать или расшифровать</param>
        /// <param name="encryptionWord">Слово для зашифровки или расшифровки</param>
        /// <param name="mode">1 - зашифровать, 0 - расшифровать</param>
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

        /// <summary>
        /// Наибольший общий делитель (Евклид)
        /// </summary>
        /// <param name="firstNum">Первое число</param>
        /// <param name="secondNum">Второе число</param>
        public static int GCD(int firstNum, int secondNum)
        {
            while (secondNum != 0)
            {
                int remainder = firstNum % secondNum;
                firstNum = secondNum;
                secondNum = remainder;
            }
            return firstNum;
        }
        

        /// <summary>
        /// Функция для проверки числа на простоту
        /// </summary>
        /// <param name="number">Число для проверки на простоту</param>
        public static bool IsPrime(int number)
        {
            return (FindFactors(number).Count > 1 ? false : true);
        }

        /// <summary>
        /// Функция для поиска множителей числа
        /// </summary>
        /// <param name="number">Число, для которого требуется найти множители</param>
        public static List<int> FindFactors(int number)
        {
            List<int> factors = new List<int>();
            while ((number % 2) == 0)
            {
                factors.Add(2);
                number /= 2;
            }

            int divider = 3;
            double maxFactor = Math.Sqrt(number);
            while (divider <= maxFactor)
            {
                while ((number % divider) == 0)
                {
                    factors.Add(divider);
                    number /= divider;
                    maxFactor = Math.Sqrt(number);
                }
                divider += 2;
            }

            if (number > 1) { factors.Add(number); }

            return factors;
        }

        /// <summary>
        /// Функция для поиска простых чисел до некоторого числа
        /// </summary>
        /// <param name="maxNumber">Число, до которого требуется найти простые числа</param>
        public static List<int> SieveOfEratosthenes(int maxNumber)
        {
            bool[] isCompositeArray = new bool[maxNumber+1];

            for (int i = 4; i <= maxNumber; i+=2)
            {
                isCompositeArray[i] = true;
            }

            int nextPrime = 3;
            
            while (nextPrime <= maxNumber)
            {
                int var = nextPrime;
                for (int i = nextPrime*var; 
                    i <= maxNumber;
                    i = nextPrime * var,
                    var++)
                {
                    isCompositeArray[i] = true;
                }

                nextPrime += 2;
            }

            List<int> primes = new List<int>();
            for (int i = 2; i <= maxNumber; i++)
            {
                if (!isCompositeArray[i]) { primes.Add(i); }
            }

            return primes;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            //
#if Past
            string newWord  = Algo_List.CaesarsCipher("Armor", 1);
            string reversed = Algo_List.CaesarsCipher(newWord, 2);
            Console.WriteLine("CC: " + newWord + "\n" + "reversed: " + reversed);

            newWord  = Algo_List.VegenereCipher("Armor", "hi", 1);
            reversed = Algo_List.VegenereCipher(newWord, "hi", 2);
            Console.WriteLine("VC: " + newWord + "\n" + "reversed: " + reversed);
            
            int GCD = Algo_List.GCD(1668, 600);
            Console.WriteLine("GCD: " + GCD);
            bool isPrime = Algo_List.IsPrime(607_049);
            Console.WriteLine($"Number is prime: {isPrime}");

            List<int> primes = Algo_List.SieveOfEratosthenes(1000);
            Console.Write("Prime numbers: \n");
            int var = 0;
            foreach (var prime in primes)
            {
                Console.Write(prime + " ");
                ++var;
                if (var > 15)
                {
                    var = 0;
                    Console.Write("\n");
                }
            }
#else

#endif
            Console.Read();
        }
    }
}
