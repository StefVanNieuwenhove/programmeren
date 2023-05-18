using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Model {
    public class User {

        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        // overview dayplans
        // private List<DayPlan> _dayPlans;
        private decimal _budget;

        public User(int id, string firstName, string lastName, string email, decimal budget) {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Budget = budget;
        }

        #region properties

        public int Id { get => _id; set => _id = value;}
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }
        public decimal Budget { get => _budget; set => _budget = value; }

        #endregion
    }
}
