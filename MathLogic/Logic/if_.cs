using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    class if_:Params_
    {
        string output;

        Params_ ask;
        Params_ true_;
        Params_ false_;

        public if_(string input):base(input)
        {
            if (input.Length < 5) throw new Exception();
            output = null;
        }

        public override string Value
        {
            get
            {
                if (output == null)
                {
                    Task<(Params_, string)>[] tasks = new Task<(Params_, string)>[3];
                    char[] consts = { '?', ':' };
                    int pos = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        if (input.Length < 5 - 2 * i + pos) throw new Exception();
                        if (input[pos] != '(')
                        {
                            if (input[pos + 1] == consts[i])
                            {
                                string s1 = input[pos] + "";
                                tasks[i] = new Task<(Params_, string)>(() => ValueAsync(s1));
                                tasks[i].Start();
                                pos += 2;
                                continue;
                            }
                            else throw new Exception();
                        }
                        int len = 1;
                        for(int j = pos+1; j < input.Length; j++)
                        {
                            if (input[j] == '(') len++;
                            else if (input[j] == ')')
                            {
                                len--;
                                if (len == 0)
                                {
                                    if (j + 1 == input.Length) throw new Exception();
                                    if (input[j + 1] != consts[i] || j + 2 == input.Length) throw new Exception("Некоректный синтаксис");
                                    string s2 = input.Substring(pos, j + 1-pos);
                                    tasks[i] = new Task<(Params_, string)>(() => ValueAsync(s2));
                                    tasks[i].Start();
                                    pos = j + 2;
                                    break;
                                }
                            }
                        }
                    }
                    string s3 = input.Substring(pos);
                    tasks[2] = new Task<(Params_, string)>(()=>ValueAsync(s3));
                    tasks[2].Start();
                    Task.WaitAll(tasks);
                    ask = tasks[0].Result.Item1;
                    output = tasks[0].Result.Item2.Length > 1 ? "(" + tasks[0].Result.Item2 + ")?" : tasks[0].Result.Item2 + "?";
                    true_ = tasks[1].Result.Item1;
                    output += tasks[1].Result.Item2.Length > 1 ? "(" + tasks[1].Result.Item2 + "):" : tasks[1].Result.Item2 + ":";
                    false_ = tasks[2].Result.Item1;
                    output += tasks[2].Result.Item2.Length > 1 ? "(" + tasks[2].Result.Item2 + ")" : tasks[2].Result.Item2;
                }
                return output;
            }
        }

        public static (Params_,string) ValueAsync(string input)
        {
            Console.WriteLine("Начата обработка: " + input);
            Params_ params_ = Typer(input);
            Console.WriteLine("Получен params из: " + input);
            return (params_, params_.Value);
        }
    }
}
