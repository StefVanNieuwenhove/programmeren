using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.DTO {
    public class DayPlanDTO {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public UserDTO User { get; set; }
        public List<EventDTO> Events { get; set; }
        public decimal Price;

        public DayPlanDTO(int id, DateTime date, UserDTO user, List<EventDTO> events, decimal price) {
            Id = id;
            Date = date;
            User = user;
            Events = events;
            Price = price;
        }

        public override string ToString() {
            return $"Day plan for {Date.ToShortDateString()} \n" +
                $"\tId: {Id}\n" +
                $"\tDate: {Date.ToShortDateString()}\n" +
                $"\tPrice: {Price}\n" +
                $"\tEvents: ";
        }


        // domeinregel 1: 

        // domeinregel 4: user mag 1 dagplan aanmaken per dag
        public bool CheckDates(int id, DateOnly date) {
            if (this.Id == id && !Date.Equals(date)) {
                    return false;
            }
            return false;
        }

        // domeinregel 6: kostprijs van events mag totaal bedrag user niet overschrijden
        public bool CalculateTotalePrice() {
            decimal amount = 0;
            Events.ForEach(x => {
                amount += x.Price;
            });

            if (amount > User.Budget)
                return false;
            return true;
        }
    }
}
