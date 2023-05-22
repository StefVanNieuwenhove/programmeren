using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.DTO {
    public class UserDTO {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Budget { get; set; }

        public UserDTO(int id, string firstName, string lastName, decimal budget) {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Budget = budget;
        }

        public override string ToString() {
            return $"{FirstName} {LastName}";
        }
    }
}
