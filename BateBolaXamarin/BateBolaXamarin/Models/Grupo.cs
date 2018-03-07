using System;
using System.Collections.Generic;

namespace BateBolaXamarin.Models
{
    public class Grupo
    {
        public int id { get; set; }
        public int approved { get; set; }
        public string name { get; set; }
        public User owner { get; set; }
        public List<User> users { get; set; }
        public List<Events> events { get; set; }

        public string isMemberIcon {
            get {
                if (approved == 1)
                {
                    return "icon_ok.png";
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
