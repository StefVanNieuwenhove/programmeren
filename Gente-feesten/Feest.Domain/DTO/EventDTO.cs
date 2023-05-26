using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.DTO {
    public class EventDTO {

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public EventDTO(int id, string title, DateTime startDate, DateTime endDate, decimal price, string description) {
            Id = id;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            Description = description;
        }

        public string ShowDetails() {
            return $"Id: {Id}\n" +
                   $"Title: {Title}\n" +
                   $"Price: {Price:C2} \n" +
                   $"Description: {Description}\n";

        }

        public override string ToString() {
            return $"{Title}";
        }
    }
}
