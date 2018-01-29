using Android.App;
using Android.Widget;
using Android.OS;
using JeuCarteCorrection.Core;
using System;
using Android.Graphics;

namespace JeuCarteCorrection
{
    [Activity(Label = "JeuCarteCorrection", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private int defausseCpt = 0;
        private int piocheCpt = 54;

        private Deck listCard;
        private Card selectedCard;

        private Button tirer;
        private Button reset;
        private TextView defausse;
        private TextView pioche;
        private TextView value;
        private TextView valueBottom;
        private ImageView color;
        private ImageView colorBottom;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            tirer = FindViewById<Button>(Resource.Id.tirer);
            reset = FindViewById<Button>(Resource.Id.reset);
            defausse = FindViewById<TextView>(Resource.Id.defausse);
            pioche = FindViewById<TextView>(Resource.Id.pile);
            value = FindViewById<TextView>(Resource.Id.valeur);
            valueBottom = FindViewById<TextView>(Resource.Id.valeurBottom);
            color = FindViewById<ImageView>(Resource.Id.couleur);
            colorBottom = FindViewById<ImageView>(Resource.Id.couleurBottom);

            Reset();

            tirer.Click += delegate {
                if (piocheCpt != 0)
                {
                    Random r = new Random();
                    int index = r.Next(0, piocheCpt);

                    selectedCard = listCard.getCard(index);
                    listCard.removeCard(index);

                    piocheCpt -= 1;
                    defausseCpt += 1;
                    pioche.Text = piocheCpt.ToString();
                    defausse.Text = defausseCpt.ToString();
                    value.Text = selectedCard.value;
                    valueBottom.Text = selectedCard.value;
                    selectedCard.setCardColor(selectedCard.color, color, colorBottom);
                }
                else
                {
                    pioche.Text = piocheCpt.ToString();
                    defausse.Text = defausseCpt.ToString();
                    value.Text = " ";
                    valueBottom.Text = " ";

                    color.SetImageResource(Resource.Drawable.dot);
                    colorBottom.SetImageResource(Resource.Drawable.dot);
                    color.SetColorFilter(Color.Transparent);
                    colorBottom.SetColorFilter(Color.Transparent);
                }

            };

            reset.Click += delegate {
                Reset();
            };


            // Get our button from the layout resource,
            // and attach an event to it

        }

        public void Reset() {
            listCard = new Deck();
            piocheCpt = 54;
            defausseCpt = 0;
            pioche.Text = piocheCpt.ToString();
            defausse.Text = defausseCpt.ToString();
            value.Text = " ";
            valueBottom.Text = " ";
            color.SetImageResource(Resource.Drawable.dot);
            colorBottom.SetImageResource(Resource.Drawable.dot);
            color.SetColorFilter(Color.Transparent);
            colorBottom.SetColorFilter(Color.Transparent);
        }
    }
}

