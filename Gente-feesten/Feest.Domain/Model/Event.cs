using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Model {
    public class Event {

        private string _id;
        private string _title;
        private DateTime _startDate;
        private DateTime _endDate;
        private decimal _price;
        private string _description;

        public Event(string id, string title, DateTime startDate, DateTime endDate, decimal price, string description) {
            Description = description;
            Id = id;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            Description = description;
        }

        #region properties

        public string Id { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public decimal Price { get => _price; set => _price = value; }
        public string Description { get => _description; set => _description = value; }

        #endregion

        public override string ToString() {
            return $"{_title} - {_description}";
        }

    }
}
