using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public static class MyR
    {
        public static string GetRandom(ref Random random)
        {
            return random.Next(1, 36).ToString();
        }
        public static string GetRandom_card(ref Random random, int a)
        {
            return random.Next(1, a).ToString();
        }
    }
}
