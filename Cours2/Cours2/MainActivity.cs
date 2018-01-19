using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Cours2.UI;
using Cours2.Core;
using Android;

namespace Cours2
{
    [Activity(Label = "Liste TODO", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private ListView listView;
        private List<Todo> todos;
        private TodoAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            listView = FindViewById<ListView>(Resource.Id.listView);
            todos = new List<Todo>{
                new Todo{ Nom ="Manger",
                    Description ="des pizzas par exemple !",
                    Priorite =Todo.PrioriteEnum.Haut
            },
            new Todo
            {
                Nom = "Boire des bieres",
                Description = "en boire beuacoup",
                Priorite = Todo.PrioriteEnum.Normal
            },
            new Todo
            {
                Nom = "Faire des courses",
                Description = "pas beaucoup d'argent",
                Priorite = Todo.PrioriteEnum.Bas
            }
            };

            adapter = new TodoAdapter(this, todos);
            listView.Adapter = adapter;
        }
    }
}

