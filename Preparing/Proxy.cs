using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotgen
{
    internal class Proxy
    {
        public static IEnumerable<string> Load()
        {
            if (Variables.ProxyType == "PROXYLESS")
            {
                return Enumerable.Empty<string>();

            }
            else
            {
                IEnumerable<string> result;
                for (; ; )
                {
                    try
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog
                        {
                            Title = "Load your proxies",
                            Filter = "Text File|*.txt",
                            DefaultExt = "txt",
                            RestoreDirectory = true
                        };
                        bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
                        if (flag)
                        {
                            IEnumerable<string> enumerable = File.ReadLines(openFileDialog.FileName);
                            bool flag2 = enumerable.Count<string>() > 0;
                            if (flag2)
                            {
                                result = enumerable;
                                break;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                return result;
            }

        }
    }
}
