using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidlunnia_tushi_discord.Commands
{
    public class CardSys
    {
        private int[] cardNum = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        private string[] CardSuits = { "clubs", "Spades", "Diamonds", "Hearts" };

        public int SelectedNUM { get; set; }
        public string SelectedCARD { get; set; }
        public CardSys()
        {
            var random = new Random();
            int numberindex = random.Next(0, cardNum.Length - 1);
            int suitindex = random.Next(0, CardSuits.Length - 1);
            this.SelectedNUM = cardNum[numberindex];
            this.SelectedCARD = $"{cardNum[numberindex]} of { CardSuits[suitindex]}";
            
        }

    }
}
