
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
using ApiCall2.Core;
using Realms;

namespace ApiCall2.UI
{
    [Activity(Label = "HistoryActivity")]
    public class HistoryActivity : Activity
    {
        private HistoryAdapter adapter;
        private ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.History);

            var config = RealmConfiguration.DefaultConfiguration;
            config.SchemaVersion = 2;
            var realm = Realm.GetInstance();

            var key = realm.All<Ville>();

            listView = FindViewById<ListView>(Resource.Id.listView);

            adapter = new HistoryAdapter(this, key.ToList());
            listView.Adapter = adapter;

            // Create your application here
        }
    }
}
