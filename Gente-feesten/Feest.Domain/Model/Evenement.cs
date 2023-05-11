using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Model
{
    internal class Evenement
    {
        private string _id;
        private string _title;
        private DateTime _start;
        private DateTime _end;
        private decimal _price;
        private string _description;

        public Evenement(string id, string title, DateTime start, DateTime end, decimal price, string description)
        {
            Id = id;
            Title = title;
            Start = start;
            End = end;
            Price = price;
            Description = description;
        }

        #region properties

        public string Id { get { return _id; } init {  _id = value; } }

        public string Title { get { return _title; } init { _title = value; } }

        public DateTime Start { get { return _start; } init { _start = value; } }

        public DateTime End { get { return _end; } init { _end = value; } }

        public decimal Price { get { return _price; } init { _price = value; } }

        public string Description { get { return _description; } init { _description = value; } }

        #endregion

        // methodes
        public TimeSpan CalculateDuration()
        {
            return Start - End;
        }

    }
}
