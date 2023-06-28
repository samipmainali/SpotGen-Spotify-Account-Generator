using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotgen
{
    internal class Combo
    {
        public static IEnumerable<string> asd;
        public static List<string> lst = new List<string>();
        public static void EmptyLoad()
        {  
            for (int i = 0; i < Variables.totalfreeaccount; i++) //add as many lines as many accs u wanna generate
            {
                lst.Add("empty"); //adds empty line to a list
                Variables.accounts.Add("empty"); //adds empty list to accounts list
            }
            asd = lst; //adds that "empty" lines to asd
            //its important cuz of parallel shit
            Variables.Total = Variables.totalfreeaccount;
           
        }
    }
}
