using System;
using System.Collections.Generic;

namespace Logic
{
    class Value_ : Params_
    {

        public Value_(string input, if_ params_) : base(input, params_)
        {
            if (input.Length == 1 && (input[0] == '0' || input[0] == '1' || (input[0] >= 'A' && input[0] <= 'Z') || (input[0] >= 'a' && input[0] <= 'z'))) ;
            else throw new Exception("Недопустимый аргумент");
        }


        public override string Value
        {
            get
            {
                return input;
            }
        }

        public override void Ifer()
        {

        }

        public override void DownReplace(Params_ true_, Params_ false_)
        {
            if (input == "0") parrent.Replace(this, false_.Clone(parrent));
            else if (input == "1") parrent.Replace(this, true_.Clone(parrent));
            else parrent.Replace(this, new if_(this, true_, false_, parrent));
        }

        public override Params_ Clone(if_ parrent)
        {
            return new Value_(input, parrent);
        }

        public override void ReplaceRepeatToConst(List<(char, char)> know)
        {
            foreach (var element in know)
            {
                if (input[0] == element.Item1) { input = element.Item2 + ""; break; }
            }
        }

        public override void RemoveConstFromIf()
        {
        }

        public override void Comparator()
        {

        }

        public override void Equivalence()
        {

        }

        public override bool RemoveConst(List<(char, char)> know)
        {
            if (input[0] == '0' || input[0] == '1')
            {
                bool mark = false;
                foreach (var element in know)
                {
                    if (input[0] == element.Item2) { input = element.Item1 + ""; mark = true; break; }
                }
                if (!mark) return false;
            }
            return true;
        }

        public override bool Truer()
        {
            if (input[0] != '0') return true;
            return false;
        }

        public override bool Falser()
        {
            if (input[0] != '1') return true;
            return false;
        }
    }
}
