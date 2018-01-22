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
                string value;
                string color = "Rien";

                if (i%13 == 1) {
                    value = "As";
                } else if (i%13 == 0) {
                    value = "Roi";
                } else if (i%13 == 12) {
                    value = "Dame";
                } else if (i%13 == 11) {
                    value = "Valet";
                } else {
                    value = (i % 13).ToString();
                }

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
                Card c1 = new Card(value, color);
                this.listCards.Add(c1);
            }
            Card c = new Card("Joker", "Joker");
            this.listCards.Add(c);
            this.listCards.Add(c);
        }

        public Card getCard(int index) {
            return listCards.ElementAt(index);
        }

        public void removeCard(int index) {
            listCards.RemoveAt(index);
        }
    }
}
