using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Player
    {
        public List<Card> cards = new List<Card>();
        public int number_player { get; set; }
        public string Name_player { get; set; }
        public string show(int i)
        {
            return 
                $" Name Player --> {Name_player}\n" +
                $"Number player --> {number_player}\n" +
                $"cards \n{cards[i].show}";
        }

    }
}
