using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserPanel.Core
{
    static class Utils
    {
        private static readonly Random random;

        public static Random Rand
        {
            get
            {
                return random;
            }
        }

        static Utils() => random = new Random();

        /// <summary>
        /// Generates a random string
        /// </summary>
        /// <param name="length">length of the string</param>
        /// <returns>random string</returns>
        public static string GenString(int length)
        {
            StringBuilder randomString = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                switch (Rand.Next(3))
                {
                    case 0:
                        randomString.Append(Convert.ToChar(Rand.Next(48,58))); // 0-9
                        break;
                    case 1:
                        randomString.Append(Convert.ToChar(Rand.Next(97, 123))); // a-z
                        break;
                    case 2:
                        randomString.Append(Convert.ToChar(Rand.Next(65, 91))); // A-Z
                        break;
                    default:
                        break;
                }
            }
            return randomString.ToString();
        }
    }
}
