using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3.Class
{
    public class FirstClass : IClass
    {
        public string GetClassName()
        {
            return "eerste klas";
        }

        public int GetColumnIndex()
        {
            return 3;
        }
    }
}
