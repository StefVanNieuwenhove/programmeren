using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H09_CarList {
    public class Car {

        public int Id { get; set; }
        public string Name { get; set; }

        public Car(int id, string name) {
            Id = id;
            Name = name;
        }

        public override string ToString() {
            return $"[{Id}] {Name}";
        }
    }
}
