using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task1.Tools
{
    public static class EncodingConvert
    {
        /// <summary>
        /// UTF8 => Win1251 bytetable
        /// </summary>
        internal static byte[] WIN1251;

        static EncodingConvert()
        {
            WIN1251 = new byte[UInt16.MaxValue];
            byte ru = 192;
            for (char c = 'А'; c <= 'я'; c++)
            {
                WIN1251[c] = ru;
                ru++;
            }
            for (byte c = 0; c <= '~'; c++)
                WIN1251[c] = c;
        }

        public static string Utf8ToWin1251(string text)
        {
            var Win1251 = new List<byte>(text.Length);

            foreach (char c in text)
                Win1251.Add(WIN1251[c]);

            string result;

            using (var ms = new MemoryStream(Win1251.ToArray()))
            {
                using (var sr = new StreamReader(ms))
                    result = sr.ReadToEnd();
            }
            
            return result;
        }
    }
}
