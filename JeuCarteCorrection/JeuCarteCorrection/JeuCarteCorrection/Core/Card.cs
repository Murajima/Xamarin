using System;
using Android.Graphics;
using Android.Widget;

namespace JeuCarteCorrection.Core
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

        public Card(string value, string color)
        {
            this.value = value;
            this.color = color;
        }

        public void setCardColor(string color, ImageView iv, ImageView ivR) {
            switch (color)
            {
                case "Carreau":
                    iv.SetImageResource(Resource.Drawable.diamond);
                    ivR.SetImageResource(Resource.Drawable.diamond);
                    iv.SetColorFilter(Color.Red);
                    ivR.SetColorFilter(Color.Red);
                    break;
                case "Coeur":
                    iv.SetImageResource(Resource.Drawable.heart);
                    ivR.SetImageResource(Resource.Drawable.heart);
                    iv.SetColorFilter(Color.Red);
                    ivR.SetColorFilter(Color.Red);
                    break;
                case "Pique":
                    iv.SetImageResource(Resource.Drawable.spades);
                    ivR.SetImageResource(Resource.Drawable.spades);
                    iv.SetColorFilter(Color.Black);
                    ivR.SetColorFilter(Color.Black);
                    break;
                case "Trefle":
                    iv.SetImageResource(Resource.Drawable.clover);
                    ivR.SetImageResource(Resource.Drawable.clover);
                    iv.SetColorFilter(Color.Black);
                    ivR.SetColorFilter(Color.Black);
                    break;
                    
                default:
                    iv.SetImageResource(Resource.Drawable.dot);
                    ivR.SetImageResource(Resource.Drawable.dot);
                    iv.SetColorFilter(Color.Transparent);
                    ivR.SetColorFilter(Color.Transparent);
                    break;
            }
        }
    }
}
