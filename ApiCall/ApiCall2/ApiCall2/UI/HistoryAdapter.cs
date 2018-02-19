using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using ApiCall2.Core;
using FFImageLoading;
using FFImageLoading.Views;

namespace ApiCall2.UI
{
    public class HistoryAdapter : ArrayAdapter<Ville>
    {
        private List<Ville> items;

        public HistoryAdapter(Context context, List<Ville> objects) : base(context, 0, objects){
            items = objects;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.FromContext(Context).Inflate(Resource.Layout.HistoryAdapter, null, false);
            }

            Ville currentItem = GetItem(position);
            TextView Ville = convertView.FindViewById<TextView>(Resource.Id.Ville);
            TextView Temperature = convertView.FindViewById<TextView>(Resource.Id.Temperature);
            ImageViewAsync weatherImg = convertView.FindViewById<ImageViewAsync>(Resource.Id.weatherImg);

            Ville.Text = currentItem.nom;
            Temperature.Text = currentItem.temp + "° C";
            string URL = currentItem.image;
            ImageService.Instance.LoadUrl(URL).Into(weatherImg);


            return convertView;
        }

        public new Ville GetItem(int position)
        {
            return items[position];
        }

        public override int Count => items.Count;
    }
}
