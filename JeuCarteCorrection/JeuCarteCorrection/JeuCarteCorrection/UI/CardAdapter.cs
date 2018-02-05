using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using JeuCarteCorrection.Core;

namespace JeuCarteCorrection.UI
{
    public class CardAdapter: ArrayAdapter<Card>
    {
        private List<Card> items;

        public CardAdapter(Context context, List<Card> objects) : base(context, 0, objects){
            items = objects;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.FromContext(Context).Inflate(Resource.Layout.CardAdapter, null, false);
            }

            Card currentItem = GetItem(position);
            TextView valeur = convertView.FindViewById<TextView>(Resource.Id.valeur);
            TextView couleur = convertView.FindViewById<TextView>(Resource.Id.couleur);

            valeur.Text = currentItem.value;
            couleur.Text = currentItem.color;

            return convertView;
        }

        public new Card GetItem(int position)
        {
            return items[position];
        }

        public override int Count => items.Count;

    }
}
