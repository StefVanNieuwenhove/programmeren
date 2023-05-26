using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Model {
    public class DayPlan {

        private int _id;
        private DateTime _date;
        private User _user;
        private List<Event> _events;
        private decimal _price;

        public DayPlan(int id, DateTime date, User user, List<Event> events, decimal price) {
            Id = id;
            Date = date;
            User = user;
            Events = events;
            Price = price;
        }



        #region properties

        public int Id { get => _id; set => _id = value; }
        public DateTime Date { get => _date; set => _date = value;}
        public User User { get => _user; set => _user = value; }
        public List<Event> Events { get =>  _events; set => _events = value;}
        public decimal Price { get => _price; set => _price = value; }
        #endregion


    }
}
