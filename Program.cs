#define New //Past

using System;
using System.Collections.Generic;

namespace Algo_List
{

    public class Algo_List
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

        /*
         Численное интегрирование
         */
        public delegate double FunctionPrototype(double x);
        public delegate double MethodePrototype(
            FunctionPrototype function,
            double a, double b, int n);

        public static double[] TestIntegrationRule(
            MethodePrototype method,
            FunctionPrototype function,
            double a, double b, int n,
            double eps)
        {
            int iterations = 0;
            double result = 0, oldResult;
            do
            {
                n *= 2;
                oldResult = result;
                result = method(function, a, b, n);
                ++iterations;
            }
            while (Math.Abs(oldResult - result) > eps);

            return new double[] { result, iterations, n };
        }

        public static double RectangleRule(
            FunctionPrototype function,
            double a, double b, int n)
        {
            double h = (b - a) / n;
            double result = 0;

            for (double x = a; x < b; x += h)
            {
                result += h * function(x);
            }

            return result;
        }

        public static double TrapezoidRule(
            FunctionPrototype function,
            double a, double b, int n)
        {
            double h = (b - a) / n;
            double result = 0;

            for (double x = a; x < b; x += h)
            {
                result += h * (function(x) + function(x+h))/2;
            }

            return result;
        }

        public static double SimpsonRule(
            FunctionPrototype function,
            double a, double b, int n)
        {
            double h = (b - a) / n;
            double result = function(a) + function(b);
            double x = a; //x < b; x += h
            for (int node = 0; node < (n-1); node++, x+=h)
            {
                if ((node % 2) == 0)
                {
                    result += 4*function(x);
                }
                else
                {
                    result += 2 * function(x);
                }
            }

            result *= h / 3;

            return result;
        }

        public static double AdaptiveQuadrature(
            FunctionPrototype function,
            double a, double b, int n,
            double maxSliceError)
        {
            double result = 0.0;
            double h = (b - a) / n;
            double x = a;

            for (int i = 1; i <= n; i++, x += h)
            {
                result += SliceArea(function, x, x+h, maxSliceError);
            }

            return result;
        }

        public static double SliceArea(
            FunctionPrototype function,
            double x1, double x2, double maxSliceError)
        {
            double y1 = function(x1);
            double y2 = function(x2);
            double xMid = (x1 + x2) / 2;
            double yMid = (y1 + y2) / 2;

            double area12 = (x2 - x1) * (y1 + y2) / 2.0;
            double area1Mid = (xMid - x1) * (y1 + yMid) / 2.0;
            double areaMid2 = (x2 - xMid) * (yMid + y2) / 2.0;
            double areaSum = area1Mid + areaMid2;

            double error = (areaSum - area12) / area12;

            if (Math.Abs(error) < maxSliceError)
            {
                return areaSum;
            }

            return SliceArea(function, x1, xMid, maxSliceError) + 
                   SliceArea(function, xMid, x2, maxSliceError);
        }

        /// <summary>
        /// Функция для поиска решения функции
        /// </summary>
        /// <param name="f">Фунция</param>
        /// <param name="df">Производная функции</param>
        /// <param name="x0">Начальное приближение</param>
        /// <param name="maxError">Максимально доступная ошибка (отклонение)</param>
        public static double[] FunctionDecisionNewton(
            FunctionPrototype f,
            FunctionPrototype df,
            double x0,
            double maxError)
        {
            double y = 0.0;
            for (int i = 0; i < 100; i++)
            {
                y = f(x0);
                if (Math.Abs(y) < maxError)
                {
                    return new double[] { x0, i };
                }
                x0 -= y / df(x0);
            }


            return new double[] { x0, 100 };
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
            double[] results = Algo_List.TestIntegrationRule(
                Algo_List.RectangleRule,
                (double x)=>(1+x+Math.Sin(2*x)),
                0, 3, 5, 0.01);
            Console.WriteLine($"Result: {results[0]}\nIterations: {results[1]}\nIntervals: {results[2]}");

            results = Algo_List.TestIntegrationRule(
                Algo_List.TrapezoidRule,
                (double x) => (1 + x + Math.Sin(2 * x)),
                0, 3, 5, 0.01);
            Console.WriteLine($"Result: {results[0]}\nIterations: {results[1]}\nIntervals: {results[2]}");

            results = Algo_List.TestIntegrationRule(
                Algo_List.SimpsonRule,
                (double x) => (1 + x + Math.Sin(2 * x)),
                0, 3, 5, 0.01);
            Console.WriteLine($"Result: {results[0]}\nIterations: {results[1]}\nIntervals: {results[2]}");

            results[0] = Algo_List.AdaptiveQuadrature(
                (double x) => (1 + x + Math.Sin(2 * x)),
                0, 3, 5, 0.01);
            Console.WriteLine($"Result: {results[0]}");

            double[] results = Algo_List.FunctionDecisionNewton(
                (x)=>Math.Sin(x),
                (x)=>Math.Cos(x),
                3,
                0.1);
            Console.WriteLine($"x0: {results[0]}\nIters: {results[1]}");

            /*
             using class LinkedListOneWay
             */
            LinkedListOneWay top = new LinkedListOneWay();

            LinkedListOneWay pointer = top;
            for (int i = 1; i < 10; i++)
            {
                LinkedListOneWay.Add(ref pointer, i);
                LinkedListOneWay.Next(ref pointer);
            }

            LinkedListOneWay value = 
                LinkedListOneWay.FindCell(ref top, 5);
            Console.Write($"Value we find: {value.Data}\n" +
                $"Next value: {value.Link.Data}\n");
            LinkedListOneWay.Print(top);
            for (int i = 0; i < 5; i++)
            {
                LinkedListOneWay.RemoveCell(ref top, i);
            }

            LinkedListOneWay.AddForward(ref top, -1);
            LinkedListOneWay.Print(top);
#else



#endif
            Console.Read();
        }

    }
    
    public class LinkedListOneWay
    {
        public int Data;
        public LinkedListOneWay Link;
        
        public static void Add(ref LinkedListOneWay @this, int data)
        {
            LinkedListOneWay linkedList = new LinkedListOneWay();
            linkedList.Data = data;
            @this.Link = linkedList;
        }

        public static void AddForward(ref LinkedListOneWay root, 
            int data)
        {
            LinkedListOneWay linkedList = new LinkedListOneWay();
            linkedList.Data = data;
            linkedList.Link = root;
            root = linkedList;
        }

        public static void Next(ref LinkedListOneWay @this)
        {
            if (@this != null)
                @this = @this.Link;
        }

        public static LinkedListOneWay FindCell(
            ref LinkedListOneWay root, 
            int valueToFind)
        {
            LinkedListOneWay pointer = root;

            while (pointer.Link != null)
            {
                if (pointer.Data == valueToFind)
                {
                    return pointer;
                }
                else
                {
                    Next(ref pointer);
                }
            }

            return null;
        }

        public static void RemoveCell(
            ref LinkedListOneWay root,
            int valueToFind)
        {
            LinkedListOneWay pointer = root;

            while (pointer.Link != null)
            {
                if (pointer.Data == valueToFind)
                {
                    //delete root
                    LinkedListOneWay temp = root.Link;
                    root = null;
                    root = temp;
                    return;
                }
                else if (pointer.Link.Data == valueToFind)
                {
                    LinkedListOneWay temp = pointer.Link.Link;
                    pointer.Link = null;
                    pointer.Link = temp;
                    return;
                }
                else
                {
                    Next(ref pointer);
                }
            }
        }

        public static void Print(LinkedListOneWay root)
        {
            LinkedListOneWay pointer = root;
            while (pointer != null)
            {
                Console.Write(pointer.Data + " ");
                Next(ref pointer);
            }
            Console.Write("\n");
        }

    }

    public class LinkedListTwoWay
    {
        public int Data;
        public LinkedListTwoWay Prev;
        public LinkedListTwoWay Next;



    }


}
