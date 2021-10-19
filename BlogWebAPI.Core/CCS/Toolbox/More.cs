using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Core.CCS.Toolbox
{
    public static class More
    {
        public static string SafeSubstring(string text, int uzunluk)
        {
            if (text.Length > uzunluk)
            {
                return text.Substring(0, uzunluk);
            }
            return text;
        }
    }
}
