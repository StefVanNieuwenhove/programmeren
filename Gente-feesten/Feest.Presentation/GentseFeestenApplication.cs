using Feest.Domain.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Presentation {
    public class GentseFeestenApplication {

        private readonly DomainManager _manager;

        public GentseFeestenApplication(DomainManager manager) {
            _manager = manager;

            MainWindow window = new MainWindow();
            window.Show();

            window.Events = GetAllUsers();
        }

        public List<string> GetAllUsers() {
            return _manager.GetAllEvents(); ;
        }
    }
}
