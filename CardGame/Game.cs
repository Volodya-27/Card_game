using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Game
    {
        //поняв шо у мене проблеми з солід тут можна було під карти зробити окремий клас колода
        //який би мав масив цих карт 
        //під масив іграків зробити клас іграки....
        //але поняв це вжєе підкінець а переробляти не хочеться
        // постараюсь в наступних дз більше приділяти уваги соліду

        private string[] arr_card = { "6", "7", "8", "9", "10", "B", "D", "K", "T" };
        private static Random random = new Random();
        private List<Player> players = new List<Player>();
        private List<Card> carder = new List<Card>();
        private int[] arr1;
        private List<Card> ar1;
        private int[] players2;
    
        private void Random_generate_card()
        {
            arr1 = new int[carder.Count];

            for (int i = 1; i < carder.Count; i++)
                arr1[i] = Convert.ToInt32(MyR.GetRandom(ref random));  // тут просто генерую числа(карти) і заношу у масив інтів
            for (int i = 1; i < carder.Count; i++)  //цикл який перевіряє чи нема часом одинакових карт згенеровано якщо є то заново перегенеровуємо і перевіряємо
            {
                for (int r = i + 1; r < carder.Count; r++)
                {
                    if (arr1[r] == arr1[i])
                    {
                        arr1[i] = Convert.ToInt32(MyR.GetRandom(ref random));
                        i = 0;
                        r = i + 1;
                    }
                }
            }
            arr1[0] = 0; //невеличикий костиль мусів так зробити бо інакше при генерації бувало шо 0 і 1 карта одинакові
        }
        private char Generating_trump_card()
        {
            int a = Convert.ToInt32(MyR.GetRandom(ref random));
            char r = carder[a].Suit_card;
            return r;
        }
        private void delete()
        {
            arr1 = arr1.Where(val => val != arr1[0]).ToArray();
        }
        private int search_big_card()
        {
            char q = Generating_trump_card();
            int[] a1=new int[players.Count];
            int a3=0;
            try
            {
                for (int i = 0; i < players.Count; i++)
                {
                    a3 = 0;
                    for (int j = 0; j < arr_card.Length; j++)
                    {
                        if (players[i].cards[0].Number_card != arr_card[j]) a3++;
                        else break;
                    }
                    a1[i] = a3 ;
                }
                for (int i = 0; i < a1.Length; i++)
                {
                    if (i + 1 == a1.Length)
                        break;
                    if (a1[i] < a1[i + 1])
                    {
                        a1[i] = a1[i + 1];
                        i = -1;
                    }
                    else
                        a1[i + 1] = a1[i];
                }
                a3 = a1[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"the vast player\n{ex.Message}");
            }
            return a3;
        }
        private void check()
        {
            int a = 1;
            for (int i = 0, j =0 ; i <players.Count ; i++)
            {
                j = i + 1;
                for (; j < players.Count; j++)
                {
                    if (players[i].cards.Count <= 2|| players[i].cards.Count==0|| players[j].cards.Count == 0|| players[j].cards.Count <= 2)
                        break;
                    if (players[i].cards[0].Number_card == players[j].cards[0].Number_card)
                    {
                        if (a > players[i].cards.Count)
                            a = 1;
                        var r = players[i].cards[0];
                        players[i].cards[0] = players[i].cards[a];
                        players[i].cards[a] = r;
                        a++;
                        j = 1;
                        i = -1;
                        break;
                    }
                }
            }
        }
        private void Taking_cards_from_players(int e)
        {
            ar1 = new List<Card>(players.Count - 1);
            
            check();
            
            for (int i = 0, j = 0; i < players.Count; i++)
            {
                if (players[i].cards.Count == 0)
                    break;
                if (players[i].cards[0].Number_card != arr_card[e])
                {
                    ar1.Add(players[i].cards[0]);
                    j++;
                }
            }
        }
        private void Determine_players_where_need_delete_card(int e)
        {
            players2 = new int[players.Count - 1];
            for (int i = 0, j = 0; i < players.Count; i++)
            {
                if (players[i].cards[0].Number_card != arr_card[e])
                {
                    players2[j] = i;
                    j++;
                }
            }
            for (int i = 0, j =1; i < players2.Length; i++)
            {
                for (; j < players2.Length; j++)
                {
                    if(players2[i]==players2[j])
                    {
                        players2[i] = i + 1;
                        j = 1;
                        i = -1;
                        break;
                    }
                }
            }
        }
        private void Delete_card_in_player()
        {
            for (int i = 0; i < players2.Length; i++)
                players[players2[i]].cards.Remove(players[players2[i]].cards[0]);
        }
        private void Add_cards_from_the_deck_to_the_players()
        {
            for (int i = 0; i < players2.Length; i++)
            {
                if (arr1.Length == 0)
                    break;
                players[players2[i]].cards.Add(carder[arr1[0]]);
                delete();
            }
        }
        private void Add_card_loserPlayer(int e)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].cards[0].Number_card == arr_card[e])
                {
                    players[i].cards.AddRange(ar1);
                }
            }
        }


        public void Add_player()
        {
            players.AddRange(new Player[] //можна добавляти любу кількість іграків!!!
            {
                new Player { number_player = 1, Name_player ="Volodya" },
                new Player { number_player = 51, Name_player ="Ivan" },
                new Player { number_player = 881, Name_player ="Koil"},
                //new Player { number_player = 7, Name_player ="Dima"},
                //new Player { number_player = 81, Name_player ="Igor"},
               // new Player { number_player = 851, Name_player ="Ior"},//добавите цих двох іграків ігра не буде працювати
               // new Player { number_player = 871, Name_player ="Ir"}, 
            });
        }
        public bool check_player()
        {
            if (players.Count >= 6)
                return false;
            else return true;
        }
        public void Add_Card()
        {
            for (int i = 6; i < 15; i++)
            {
                carder.AddRange(new Card[]
                {
                    new Card { Number_card = arr_card[i-6], Color_card = "Red", Suit_card = Convert.ToChar(3) } ,
                    new Card { Number_card = arr_card[i-6], Color_card = "Red", Suit_card = Convert.ToChar(4) } ,
                    new Card { Number_card = arr_card[i-6], Color_card = "Black", Suit_card = Convert.ToChar(5) } ,
                    new Card { Number_card = arr_card[i-6], Color_card = "Black", Suit_card = Convert.ToChar(6) }
                });
            }
        }
        public void show()   
        {
            int number_players=0;
            for (int i = 0; i < players.Count; i++)
            {
                if (i + 1 >= players.Count)
                    break;
                if (players[number_players].cards.Count < players[i + 1].cards.Count)
                    number_players = i+1;
            }
            for (int t = 0; t < players[number_players].cards.Count; t++)
            {
                    if (players[number_players].cards[t].Suit_card == Convert.ToChar(3) || players[number_players].cards[t].Suit_card == Convert.ToChar(4))
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(players[number_players].cards[t].show);
            }
            Console.WriteLine($"Win players {players[number_players].Name_player}\nCards count {players[number_players].cards.Count}");
        }
        public void add_cards_player()
        {
            Random_generate_card();
            for (int i = 0; i < players.Count; i++)
            {
                for (int u = 0; u < 6; u++)
                {
                    players[i].cards.Add(carder[arr1[0]]);
                    
                    delete();
                }
            }
           
        }


        public void Game_Proces()
        {
            while(arr1.Length!=0)
            {
                int e = search_big_card();
                Taking_cards_from_players(e);
                Determine_players_where_need_delete_card(e);
                Add_card_loserPlayer(e);
                Delete_card_in_player();
                Add_cards_from_the_deck_to_the_players();
            }

        }
        
    }
}
