using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic
{
    public class if_ : Params_
    {
        string output;

        Params_ ask;
        Params_ true_;
        Params_ false_;

        public if_(string input, if_ params_) : base(input, params_)
        {
            if (input.Length < 5) throw new Exception();
            output = null;
        }

        public if_(Params_ ask, Params_ true_, Params_ false_, if_ parrent)
        {
            this.ask = ask;
            ask.parrent = this;
            this.true_ = true_;
            true_.parrent = this;
            this.false_ = false_;
            false_.parrent = this;
            this.parrent = parrent;
            output = "(" + ask.Value + ")?(" + true_.Value + "):(" + false_.Value + ")";
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
                                tasks[i] = new Task<(Params_, string)>(() => ValueAsync(s1, this));
                                tasks[i].Start();
                                pos += 2;
                                continue;
                            }
                            else throw new Exception();
                        }
                        int len = 1;
                        for (int j = pos + 1; j < input.Length; j++)
                        {
                            if (input[j] == '(') len++;
                            else if (input[j] == ')')
                            {
                                len--;
                                if (len == 0)
                                {
                                    if (j + 1 == input.Length) throw new Exception();
                                    if (input[j + 1] != consts[i] || j + 2 == input.Length) throw new Exception("Некоректный синтаксис");
                                    string s2 = input.Substring(pos, j + 1 - pos);
                                    tasks[i] = new Task<(Params_, string)>(() => ValueAsync(s2, this));
                                    tasks[i].Start();
                                    pos = j + 2;
                                    break;
                                }
                            }
                        }
                    }
                    string s3 = input.Substring(pos);
                    tasks[2] = new Task<(Params_, string)>(() => ValueAsync(s3, this));
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

        public static (Params_, string) ValueAsync(string input, if_ parrent)
        {
            Console.WriteLine("Начата обработка: " + input);
            Params_ params_ = Typer(input, parrent);
            Console.WriteLine("Получен params из: " + input);
            return (params_, params_.Value);
        }

        public override void Ifer()
        {
            if (ask.GetType() == typeof(if_))
            {
                if (parrent != null)
                {
                    parrent.Replace(this, ask);
                    ask.DownReplace(true_, false_);
                    parrent.Ifer();
                    parrent.output = "(" + parrent.ask.Value + ")?(" + parrent.true_.Value + "):(" + parrent.false_.Value + ")";
                }
                else
                {
                    root = ask;
                    ask.DownReplace(true_, false_);
                    root.Ifer();
                    (root as if_).output = "(" + (root as if_).ask.Value + ")?(" + (root as if_).true_.Value + "):(" + (root as if_).false_.Value + ")";
                }
            }
            else
            {
                Task task = new Task(() => true_.Ifer());
                task.Start();
                false_.Ifer();
                task.Wait();
            }
        }

        public void Replace(Params_ params_, Params_ params_new)
        {
            if (ask == params_) ask = params_new;
            else if (true_ == params_) true_ = params_new;
            else false_ = params_new;
            params_new.parrent = this;
        }

        public override void DownReplace(Params_ true_, Params_ false_)
        {
            Task task = new Task(() => this.true_.DownReplace(true_, false_));
            task.Start();
            this.false_.DownReplace(true_, false_);
            task.Wait();
            output = "(" + ask.Value + ")?(" + this.true_.Value + "):(" + this.false_.Value + ")";
        }

        public override Params_ Clone(if_ parrent)
        {
            if_ if_ = new if_(ask.Clone(this), true_.Clone(this), false_.Clone(this), parrent);
            string i = if_.Value;
            return if_;
        }

        public override void ReplaceRepeatToConst(List<(char, char)> know)
        {
            Value_ value = ask as Value_;
            bool mark = false;
            foreach (var element in know)
            {
                if (value.Value[0] == element.Item1)
                {
                    ask = new Value_(element.Item2 + "", this);
                    mark = true;
                    break;
                }
            }
            if (mark)
            {
                Task task = new Task(() => true_.ReplaceRepeatToConst(new List<(char, char)>(know)));
                task.Start();
                false_.ReplaceRepeatToConst(new List<(char, char)>(know));
                task.Wait();
            }
            else
            {
                List<(char, char)> forTrue = new List<(char, char)>(know), forFalse = new List<(char, char)>(know);
                forTrue.Add((ask.Value[0], '1'));
                forFalse.Add((ask.Value[0], '0'));
                Task task = new Task(() => true_.ReplaceRepeatToConst(forTrue));
                task.Start();
                false_.ReplaceRepeatToConst(forFalse);
                task.Wait();
            }
            output = "(" + ask.Value + ")?(" + this.true_.Value + "):(" + this.false_.Value + ")";
        }

        public override void RemoveConstFromIf()
        {
            if (parrent != null)
            {
                if (ask.Value == "0")
                {
                    parrent.Replace(this, false_);
                    false_.RemoveConstFromIf();
                }
                else
                {
                    if (ask.Value == "1")
                    {
                        parrent.Replace(this, true_);
                        true_.RemoveConstFromIf();
                    }
                    else
                    {
                        Task task = new Task(() => true_.RemoveConstFromIf());
                        task.Start();
                        false_.RemoveConstFromIf();
                        task.Wait();
                    }
                }
                parrent.output = "(" + parrent.ask.Value + ")?(" + parrent.true_.Value + "):(" + parrent.false_.Value + ")";
            }
            else
            {
                if (ask.Value == "0")
                {
                    root = false_;
                    false_.RemoveConstFromIf();
                }
                else
                {
                    if (ask.Value == "1")
                    {
                        root = true_;
                        true_.RemoveConstFromIf();
                    }
                    else
                    {
                        Task task = new Task(() => true_.RemoveConstFromIf());
                        task.Start();
                        false_.RemoveConstFromIf();
                        task.Wait();
                    }
                }
                if (root.GetType() == typeof(if_)) (root as if_).output = "(" + (root as if_).ask.Value + ")?(" + (root as if_).true_.Value + "):(" + (root as if_).false_.Value + ")";
            }
        }

        public override void Comparator()
        {
            if (true_.Value == false_.Value)
            {
                if (parrent != null)
                {
                    parrent.Replace(this, true_);
                    parrent.Comparator();
                    parrent.output = "(" + parrent.ask.Value + ")?(" + parrent.true_.Value + "):(" + parrent.false_.Value + ")";
                }
                else
                {
                    root = true_;
                    root.Comparator();
                    if (root.GetType() == typeof(if_)) (root as if_).output = "(" + (root as if_).ask.Value + ")?(" + (root as if_).true_.Value + "):(" + (root as if_).false_.Value + ")";
                }
            }
            else
            {
                Task task = new Task(() => true_.Comparator());
                task.Start();
                false_.Comparator();
                task.Wait();
            }
        }

        public override void Equivalence()
        {
            if (true_.GetType() == typeof(Value_) && false_.GetType() == typeof(Value_))
            {
                if (true_.Value[0] == '1' && false_.Value[0] == '0')
                {
                    if (parrent != null)
                    {
                        parrent.Replace(this, ask);
                        parrent.output = "(" + parrent.ask.Value + ")?(" + parrent.true_.Value + "):(" + parrent.false_.Value + ")";
                    }
                    else
                    {
                        root = ask;
                        if (root.GetType() == typeof(if_)) (root as if_).output = "(" + (root as if_).ask.Value + ")?(" + (root as if_).true_.Value + "):(" + (root as if_).false_.Value + ")";
                    }
                }
            }
            else
            {
                Task task = new Task(() => true_.Equivalence());
                task.Start();
                false_.Equivalence();
                task.Wait();
            }
        }

        public override bool RemoveConst(List<(char, char)> know)
        {
            Value_ value = ask as Value_;
            List<(char, char)> forTrue = new List<(char, char)>(know), forFalse = new List<(char, char)>(know);
            forTrue.Add((ask.Value[0], '1'));
            forFalse.Add((ask.Value[0], '0'));
            Task<bool> task = new Task<bool>(() => true_.RemoveConst(forTrue));
            task.Start();
            if (!false_.RemoveConst(forFalse)) return false;
            task.Wait();
            if (!task.Result) return false;
            output = "(" + ask.Value + ")?(" + this.true_.Value + "):(" + this.false_.Value + ")";
            return true;
        }
    }
}
