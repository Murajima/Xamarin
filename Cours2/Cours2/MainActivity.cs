using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Cours2.UI;
using Cours2.Core;
using Android;
using Android.Content;
using System;

namespace Cours2
{
    [Activity(Label = "Liste TODO", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private ListView listView;
        private List<Todo> todos;
        private TodoAdapter adapter;
        private Button ajouter;
        private string nom, description, priorite;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            listView = FindViewById<ListView>(Resource.Id.listView);
            ajouter = FindViewById<Button>(Resource.Id.ajouter);
            todos = new List<Todo>{
                new Todo
                {
                    Nom ="Manger", Description ="des pizzas par exemple !", Priorite =Todo.PrioriteEnum.Haut
                },
                new Todo
                {
                    Nom = "Boire des bieres", Description = "en boire beaucoup", Priorite = Todo.PrioriteEnum.Normal
                },
                new Todo
                {
                    Nom = "Faire des courses", Description = "pas beaucoup d'argent", Priorite = Todo.PrioriteEnum.Bas
                }

            };

            adapter = new TodoAdapter(this, todos);
            listView.Adapter = adapter;

            ajouter.Click += delegate
            {
                StartActivityForResult(typeof(TodoActivity), 0);
            };

        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                nom = data.Extras.GetString("Nom");
                description = data.Extras.GetString("Description");
                priorite = data.Extras.GetString("Priorite");
                todos.Add(new Todo { Nom = nom, Description = description, Priorite = (Todo.PrioriteEnum)Enum.Parse(typeof(Todo.PrioriteEnum), priorite) });
                adapter.NotifyDataSetChanged();

                Toast.MakeText(this, Resource.String.operation_success, ToastLength.Short).Show();
            } else {
                Toast.MakeText(this, Resource.String.operation_failure, ToastLength.Short).Show();
            }
        }
    }
}

