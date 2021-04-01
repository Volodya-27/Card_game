using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    static class Menu
    {
        static public void menu_game()
        {
            Game game = new Game();
            game.Add_player();
            if(game.check_player()==true)
            {
                game.Add_Card();
                game.add_cards_player();
                game.Game_Proces();
                game.show();
            }

            else Console.WriteLine("More Players");
        }
    }
}
