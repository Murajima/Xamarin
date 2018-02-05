
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
            listView = FindViewById<ListView>(Resource.Id.listView);
            cardsList = new List<Card>();
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CardListActivity);
            adapter = new CardAdapter(this, cardsList);
            listView.Adapter = adapter;

            // Create your application here
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                
                Card tmpCard = JsonConvert.DeserializeObject<Card>(data.Extras.GetString("cards"));
                cardsList.Add(tmpCard);
                adapter.NotifyDataSetChanged();

                Toast.MakeText(this, Resource.String.operation_success, ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, Resource.String.operation_failure, ToastLength.Short).Show();
            }
        }
    }
}
