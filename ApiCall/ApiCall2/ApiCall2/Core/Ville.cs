using System;
using Realms;

namespace ApiCall2.Core
{
    public class Ville : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string nom { get; set; }
        public string weather { get; set; }
        public string weatherDetail { get; set; }
        public string image { get; set; }
        public string temp { get; set; }
        public string tmpMin { get; set; }
        public string tmpMax { get; set; }
        public string windspeed { get; set; }
    }
}
