using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{[Serializable]
    public class StringManager
    {
        public static string GetExtendedAsciiCodeAsString(byte code)
        {
            // Used to get Extended Ascii characters
            Encoding cp437 = Encoding.GetEncoding(437);

            // Get string using cp437 encoding
            return cp437.GetString(new byte[] { code });
        }
    }
}
