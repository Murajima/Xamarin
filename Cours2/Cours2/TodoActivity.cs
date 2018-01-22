using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cours2.Core;

namespace Cours2
{
    [Activity(Label = "TodoActivity")]
    public class TodoActivity : Activity
    {
        private EditText nom;
        private EditText description;
        private Button save;
        private Button cancel;
        private Spinner spinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddTask);

            nom = FindViewById<EditText>(Resource.Id.editNom);
            description = FindViewById<EditText>(Resource.Id.editDescription);
            save = FindViewById<Button>(Resource.Id.save);
            cancel = FindViewById<Button>(Resource.Id.cancel);


            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.priority_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            save.Click += delegate
            {
                Intent myIntent = new Intent();
                Bundle extras = new Bundle();
                extras.PutString("Nom", nom.Text);
                extras.PutString("Description", description.Text);
                extras.PutString("Priorite", spinner.SelectedItem.ToString());
                myIntent.PutExtras(extras);
                SetResult(Result.Ok, myIntent);
                Finish();
            };
            cancel.Click += delegate
            {
                SetResult(Result.Canceled);
                Finish();
            };



        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            //string toast = string.Format("The priority is {0}", spinner.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}