
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JeuCarteCorrection.Core;
using Newtonsoft.Json;

namespace JeuCarteCorrection.UI
{
    [Activity(Label = "CardListActivity")]
    public class CardListActivity : Activity
    {
        private CardAdapter adapter;
        private ListView listView;
        private List<Card> cardsList;
        private string value, color;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            string json = Intent.GetStringExtra("cards");
            listView = FindViewById<ListView>(Resource.Id.listView);
            cardsList = JsonConvert.DeserializeObject<List<Card>>(json);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CardListActivity);

            adapter = new CardAdapter(this, cardsList);
            listView.Adapter = adapter;



            // Create your application here
        }
    }
}
