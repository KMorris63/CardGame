using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsoleApp
{
    class Card
    {
        public int CardNum { get; set; }
        public int SuitNum { get; set; }
        public string SuitName { get; set; }
        public int RankNum { get; set; }
        public string RankName { get; set; }
        public int RankValue { get; set; }
        public bool Hidden { get; set; }
        public Card(int cardNum)
        {
            CardNum = cardNum;
            SuitNum = cardNum / 13;
            switch (SuitNum)
            {
                case 0:
                    SuitName = "Spades";
                    break;
                case 1:
                    SuitName = "Hearts";
                    break;
                case 2:
                    SuitName = "Clubs";
                    break;
                case 3:
                    SuitName = "Diamonds";
                    break;
                default:
                    SuitName = "";
                    break;
            }
            RankNum = cardNum % 13;
            if (RankNum == 0)
            {
                RankName = "Ace";
                RankValue = 11;
            }
            else if (RankNum == 10)
            {
                RankName = "Jack";
                RankValue = 10;
            }
            else if (RankNum == 11)
            {
                RankName = "Queen";
                RankValue = 10;
            }
            else if (RankNum == 12)
            {
                RankName = "King";
                RankValue = 10;
            }
            else
            {
                RankValue = RankNum + 1;
                RankName = RankValue.ToString();
            }
            Hidden = true;
        }
        override
        public string ToString()
        {
            if (Hidden)
            {
                return "<hidden>";
            }
            return RankName + " of " + SuitName;
        }
    }
}
