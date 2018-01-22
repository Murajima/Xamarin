using Android.App;
using Android.Widget;
using Android.OS;
using JeuCarte.Core;
using System;

namespace JeuCarte
{
    [Activity(Label = "JeuCarte", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private int defausseCpt = 0;
        private int piocheCpt = 52;

        private ListCards listCard;
        private Card selectedCard;

        private Button tirer;
        private Button shuffle;
        private TextView defausse;
        private TextView pioche;
        private TextView value;
        private TextView color;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            tirer = FindViewById<Button>(Resource.Id.tirer);
            shuffle = FindViewById<Button>(Resource.Id.shuffle);
            defausse = FindViewById<TextView>(Resource.Id.defausse);
            pioche = FindViewById<TextView>(Resource.Id.pioche);
            value = FindViewById<TextView>(Resource.Id.value);
            color = FindViewById<TextView>(Resource.Id.color);

            pioche.Text = piocheCpt.ToString();
            defausse.Text = defausseCpt.ToString();

            listCard = new ListCards();

            tirer.Click += delegate {
                if (piocheCpt != 0) {
                    Random r = new Random();
                    int index = r.Next(0, piocheCpt);

                    selectedCard = listCard.getCard(index);
                    listCard.removeCard(index);

                    piocheCpt -= 1;
                    defausseCpt += 1;
                    pioche.Text = piocheCpt.ToString();
                    defausse.Text = defausseCpt.ToString();
                    value.Text = selectedCard.value;
                    color.Text = selectedCard.color;
                } else {
                    pioche.Text = piocheCpt.ToString();
                    defausse.Text = defausseCpt.ToString();
                    value.Text = " ";
                    color.Text = "La pioche est vide, videz la defausse en appuyant sur Reset";
                }

            };

            shuffle.Click += delegate {
                listCard = new ListCards();
                piocheCpt = 52;
                defausseCpt = 0;
                pioche.Text = piocheCpt.ToString();
                defausse.Text = defausseCpt.ToString();
            };
        }
    }
}

