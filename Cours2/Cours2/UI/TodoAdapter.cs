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
using Cours2.Core;

namespace Cours2.UI
{
    class TodoAdapter : ArrayAdapter<Todo>
    {
        private List<Todo> items;

        public TodoAdapter(Context context, List<Todo> objects) : base(context, 0, objects){
            items = objects;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.FromContext(Context).Inflate(Resource.Layout.item_todo, null, false);
            }

            Todo currentItem = GetItem(position);
            TextView name = convertView.FindViewById<TextView>(Resource.Id.nom);
            TextView description = convertView.FindViewById<TextView>(Resource.Id.description);
            TextView priority = convertView.FindViewById<TextView>(Resource.Id.priorite);

            name.Text = currentItem.Nom;
            priority.Text = currentItem.Priorite.ToString();
            priority.SetTextColor(Context.Resources.GetColor(GetItemPriorityColor(currentItem)));
            description.Text = currentItem.Description;

            return convertView;
        }

        public new Todo GetItem(int position)
        {
            return items[position];
        }

        public override int Count => items.Count;

        public int GetItemPriorityColor (Todo item){
            switch(item.Priorite){
                case Todo.PrioriteEnum.Bas:
                    return Resource.Color.priority_low;
                case Todo.PrioriteEnum.Normal:
                    return Resource.Color.priority_medium;
                case Todo.PrioriteEnum.Haut:
                    return Resource.Color.priority_high;
            }
            return 0;
        }
    }
}