using System;
namespace JeuCarte.Core
{
    public class Card
    {
        public string value;
        public string color;
        public Card()
        {
            this.value = "Une fausse valeur";
            this.color = "Une fausse couleur";
        }

        public Card(string value, string color) {
            this.value = value;
            this.color = color;
        }
    }
}
