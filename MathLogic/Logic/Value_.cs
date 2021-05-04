using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Value_:Params_
    {

        public Value_(string input):base(input)
        {
            if (input.Length == 1 && (input[0] == '0' || input[0] == '1' || (input[0] >= 'A' && input[0] <= 'Z') || (input[0] >= 'a' && input[0] <= 'z')));
            else throw new Exception("Недопустимый аргумент");
        }


        public override string Value
        {
            get
            {
                return input;
            }
        }
    }
}
