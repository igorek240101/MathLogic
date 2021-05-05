using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Logic
{
    public abstract class Params_
    {
        protected string input;

        public Params_(string input)
        {
            this.input = input;
        }

        public static readonly Dictionary<string, (string, int)> transformation;

        static Params_()
        {
            transformation = new Dictionary<string, (string, int)>();
            FileStream fileStream = new FileStream("transformation.txt", FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);
            while (!reader.EndOfStream)
            {
                transformation.Add(reader.ReadLine(), (reader.ReadLine(), Convert.ToInt32(reader.ReadLine())));
            }
        }

        public abstract string Value { get; }

        public static Params_ Typer(string input)
        {
            if (input.Length == 0) throw new Exception("Передана пустая строка");
            if (input.Length == 1) return new Value_(input);
            if (input[0] == '(')
            {
                int len = 1;
                for (int i = 1; i < input.Length; i++)
                {
                    if (input[i] == '(') len++;
                    else if (input[i] == ')')
                    {
                        len--;
                        if (len == 0)
                        {
                            if (i + 1 == input.Length) return Typer(input.Substring(1, input.Length - 2));
                            if (input[i + 1] == '?') return new if_(input);
                            string beginOP = input.Substring(i + 1, input.Length-i-1);
                            foreach(var element in transformation)
                            {
                                if (beginOP.StartsWith(element.Key) && element.Value.Item2 > 1)
                                {
                                    if (element.Value.Item2 == 2)
                                    {
                                        return new if_(element.Value.Item1.Replace("α", input.Substring(0, i)));
                                    }
                                    else
                                    {
                                        return new if_(element.Value.Item1.Replace("α", input.Substring(0, i+1)).Replace("ω", input.Substring(i + element.Key.Length + 1)));
                                    }
                                }
                            }
                            new Exception("Данный оператор не зарегестрирован");
                        }
                    }
                }
                throw new Exception("Не все скобки закрыты");
            }
            else
            {
                if (input.Length >= 2 && input[1] == '?') return new if_(input);
                foreach (var element in transformation)
                {
                    if(element.Value.Item2 == 1 && input.StartsWith(element.Key))
                    {
                        return new if_(element.Value.Item1.Replace("α", input.Substring(element.Key.Length, input.Length - element.Key.Length)));
                    }
                    else
                    {
                        if (input.Substring(1).StartsWith(element.Key) && element.Value.Item2 > 1)
                        {
                            if (element.Value.Item2 == 2)
                            {
                                return new if_(element.Value.Item1.Replace('α', input[0]));
                            }
                            else
                            {
                                return new if_(element.Value.Item1.Replace('α', input[0]).Replace("ω", input.Substring(element.Key.Length + 1)));
                            }
                        }
                    }
                }
                throw new Exception();
            }
        }
    }
}
