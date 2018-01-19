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

namespace App3.UI
{
    class TodoAdapter : ArrayAdapter<Todo>
    {
        public TodoAdapter(Context context, int textViewResourceId, Todo[] objects) : base(context, textViewResourceId, objects)
        {
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            return convertView;
        }
    }
}