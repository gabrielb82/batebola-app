using System;
using System.Collections.Generic;
namespace BateBolaXamarin.Models
{
    public class Events
    {
        public int id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string local { get; set; }
        public List<User> users { get; set; }
        public Grupo group { get; set; }

        public DateTime dateTime {
            get {
                return Convert.ToDateTime(date);
            }
        }
    }
}
