using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generator
{
    class Program
    {
        static char[] data = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };


        delegate string Algoritm(char[] args);

        static void Main(string[] args)
        {
            Algoritm[] programs = { new Algoritm(RecBase), new Algoritm(RecBaseOpt), new Algoritm(RecMulti), new Algoritm(RecMultiOpt), new Algoritm(LinConverter) };
            for (int i = 1; i < 25; i++)
            {
                Random random = new Random();
                int len = (int)Math.Pow(2, i);
                char[] input = new char[len];
                for (int j = 0; j < len; j++)
                {
                    input[j] = (char)random.Next(48, 50);
                }
                for (int j = 0; j < programs.Length; j++)
                {
                    DateTime start = DateTime.Now;
                    string res = programs[j].Invoke(input);
                    TimeSpan time = DateTime.Now - start;
                    Console.WriteLine(i + " " + j + " " + time);
                }
            }
            Console.ReadLine();
        }



        static string LinConverter(char[] args)
        {
            args = args.Reverse().ToArray();
            int N = 0;
            for (int k = args.Length; k > 1; k /= 2) N++;
            Stack<(char, bool)> stack = new Stack<(char, bool)>();
            stack.Push((data[0], true));
            int j = 0;
            string res = "(" + stack.Peek().Item1 + " ? ";
            while (stack.Count > 0)
            {
                if (stack.Count < N)
                {
                    stack.Push((data[stack.Count], true));
                    res += "(" + stack.Peek().Item1 + " ? ";
                }
                else
                {
                    res += args[j] + " : " + args[j + 1];
                    j += 2;
                    do
                    {
                        stack.Pop();
                        res += ")";
                    }
                    while (stack.Count > 0 && !stack.Peek().Item2);
                    if (stack.Count > 0)
                    {
                        char buffer = stack.Pop().Item1;
                        stack.Push((buffer, false));
                        res += " : ";
                    }
                }
            }
            return res;
        }


        static string RecBase(char[] args)
        {
            args = args.Reverse().ToArray();
            int[] input = args.ToList().ConvertAll(t => Convert.ToInt32(t)).ToArray();
            string res = Converter(input, 0);
            return res;
        }

        static string Converter(int[] input, int i)
        {
            if (input.Length != 1)
                return "(" + data[i] + " ? " + Converter(input.Take(input.Length / 2).ToArray(), i + 1) + " : " + Converter(input.Skip(input.Length / 2).ToArray(), i + 1) + ")";
            else
                return Convert.ToString(input[0]);
        }

        static string RecBaseOpt(char[] args)
        {
            args = args.Reverse().ToArray();
            string res = ConverterOpt(args, 0);
            return res;
        }

        static string ConverterOpt(char[] input, int i)
        {
            if (input.Length == 2)
            {
                if (input[0] == '1' && input[1] == '0') return data[i] + "";
                else if (input[0] == '0' && input[1] == '1') return "(" + data[i] + " ? " + input[0] + " : " + input[1] + ")";
                else if (input[0] == '0') return "0";
                else return "1";
            }
            char[] first = input.Take(input.Length / 2).ToArray(), second = input.Skip(input.Length / 2).ToArray();
            if (Enumerable.SequenceEqual(first,second))
            {
                return ConverterOpt(first, i + 1);
            }
            else
            {
                string[] res = { ConverterOpt(first, i + 1) , ConverterOpt(second, i + 1) };
                if (res[0].Length == 1 && res[1].Length == 1 && (res[0][0] == '0' || res[0][0] == '1') && (res[1][0] == '0' || res[1][0] == '1')) return ConverterOpt(new char[] { res[0][0], res[1][0] }, i);
                else
                {
                    return "(" + data[i] + " ? " +
                        res[0] + " : " +
                        res[1] + ")";
                }
            }
        }

        static string RecMulti(char[] args)
        {
            args = args.Reverse().ToArray();
            int[] input = args.ToList().ConvertAll(t => Convert.ToInt32(t)).ToArray();
            string res = Converter(input, 0);
            return res;
        }

        static string ConverterMulti(int[] input, int i)
        {
            if (input.Length != 1)
            {
                Task<string> task = new Task<string>(()=>ConverterMulti(input.Take(input.Length / 2).ToArray(), i + 1));
                task.Start();
                string s = Converter(input.Skip(input.Length / 2).ToArray(), i + 1);
                task.Wait();
                return "(" + data[i] + " ? " + task.Result + " : " + s + ")";
            }
            else
                return Convert.ToString(input[0]);
        }

        static string RecMultiOpt(char[] args)
        {
            args = args.Reverse().ToArray();
            string res = ConverterMultiOpt(args, 0);
            return res;
        }

        static string ConverterMultiOpt(char[] input, int i)
        {
            if (input.Length == 2)
            {
                if (input[0] == '1' && input[1] == '0') return data[i] + "";
                else if (input[0] == '0' && input[1] == '1') return "(" + data[i] + " ? " + input[0] + " : " + input[1] + ")";
                else if (input[0] == '0') return "0";
                else return "1";
            }
            char[] first = input.Take(input.Length / 2).ToArray(), second = input.Skip(input.Length / 2).ToArray();
            if (Enumerable.SequenceEqual(first, second))
            {
                return ConverterMultiOpt(first, i + 1);
            }
            else
            {
                Task<string> task = new Task<string>(()=>ConverterMultiOpt(first, i + 1));
                task.Start();
                string s = ConverterMultiOpt(second, i + 1);
                task.Wait();
                string[] res = { task.Result, s };
                if (res[0].Length == 1 && res[1].Length == 1 && (res[0][0] == '0' || res[0][0] == '1') && (res[1][0] == '0' || res[1][0] == '1')) return ConverterMultiOpt(new char[] { res[0][0], res[1][0] }, i);
                else
                {
                    return "(" + data[i] + " ? " +
                        res[0] + " : " +
                        res[1] + ")";
                }
            }
        }

    }
}
