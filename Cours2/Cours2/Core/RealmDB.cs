using System;
using Realms;

namespace Cours2.Core
{
    public enum PrioriteEnum { Bas, Normal, Haut }
    public class RealmDB : RealmObject
    {
        public RealmDB()
        {
        }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string enumDescription { get; set; }

        public void saveEnum(PrioriteEnum val)
        {
            this.enumDescription = val.ToString();
        }

        public PrioriteEnum getEnum()
        {
            PrioriteEnum tmpEnum = (PrioriteEnum)Enum.Parse(typeof(PrioriteEnum), enumDescription);
            return tmpEnum;
        }
    }
}
