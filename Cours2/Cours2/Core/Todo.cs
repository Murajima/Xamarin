﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Cours2.Core
{
    public class Todo
    {
        public enum PrioriteEnum { Bas, Normal, Haut}
        public string Nom { get; set; }
        public string Description { get; set; }
        public PrioriteEnum Priorite { get; set; }

        public static explicit operator Bundle(Todo v)
        {
            throw new NotImplementedException();
        }
    }
}