using System;
using System.Collections.Generic;
using System.Linq;

namespace JeuCarte.Core
{
    public class ListCards
    {
        public List<Card> listCards;
        public ListCards()
        {
            listCards = new List<Card>();
            for (int i = 0; i < 52; i++) {
                string value = (i%13).ToString();
                string color = "Rien";

                switch(i%4){
                    case 0:
                        color = "Pique";
                        break;
                    case 1:
                        color = "Coeur";
                        break;
                    case 2:
                        color = "Trefle";
                        break;
                    case 3:
                        color = "Carreau";
                        break;
                }
                Card c = new Card(value, color);
                this.listCards.Add(c);
            }
        }

        public Card getCard(int index) {
            return listCards.ElementAt(index);
        }

        public void removeCard(int index) {
            listCards.RemoveAt(index);
        }
    }
}
