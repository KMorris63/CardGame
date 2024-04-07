using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsoleApp
{
    class Deck
    {
        public List<Card> CardsList { get; set; }
        public int NumOfDecks { get; set; }
        public Deck()
        {
            NumOfDecks = 1;
            Init();
        }
        public Deck(int numOfDecks)
        {
            if (numOfDecks > 0 && numOfDecks <= 10)
            {
                NumOfDecks = numOfDecks;
            }
            else
            {
                NumOfDecks = 1;
            }
            Init();
        }
        public void Init()
        {
            CardsList = new List<Card>();
            for (int i = 0; i < NumOfDecks; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    Card card = new Card(j);
                    CardsList.Add(card);
                }
            }
        }
        override
        public string ToString()
        {
            string display = "";
            foreach (Card card in CardsList)
            {
                display += card.ToString() + "\n";
            }
            return display;
        }
        public List<Card> Shuffle()
        {
            List<Card> tempList = new List<Card>(CardsList);
            CardsList.Clear();
            Random random = new Random();
            while (tempList.Count > 0)
            {
                int randIndex = random.Next(0, tempList.Count);
                Console.WriteLine("Random card at index " + randIndex + " with upper exclusive bound of " + tempList.Count);
                CardsList.Add(tempList[randIndex]);
                tempList.RemoveAt(randIndex);
            }
            return CardsList;
        }

        public void ReverseVisibility()
        {
            foreach(Card card in CardsList)
            {
                card.Hidden = !card.Hidden;
            }
        }
    }
}
