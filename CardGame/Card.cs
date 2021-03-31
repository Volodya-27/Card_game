using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Card
    {
        public string Color_card { get; set; }
        public char Suit_card { get; set; }
        public string Number_card { get; set; }
        public string show
        {
              get =>
                    $"|----------------|\n" +
                    $"|{Number_card} {Suit_card}             |\n" +
                    $"|                |\n" +
                    $"|                |\n" +
                    $"|                |\n" +
                    $"|                |\n" +
                    $"|                |\n" +
                    $"|                |\n" + 
                    $"|                |\n" +
                    $"|             {Number_card} {Suit_card}|\n" +
                    $"|----------------|\n\n\n";
        }
    }
}
