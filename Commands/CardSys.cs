using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidlunnia_tushi_discord.Commands
{
    public class CardSys
    {
        public int[] cardNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
        public string[] CardSuits = { "clubs", "Spades", "Diamonds", "Hearts" };

    }
    public CardSys() 
    {
        var random = new Random();
        int numberindex = random.Next(0, cardNumbers.Length - 1);
    }

}
