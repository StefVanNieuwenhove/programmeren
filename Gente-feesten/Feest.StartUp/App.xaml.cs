using Feest.ADO.Mappers;
using Feest.Domain.Interface;
using Feest.Domain.Managers;
using Feest.Presentation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Feest.StartUp {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private void Application_Startup(object sender, StartupEventArgs e) {

            IEventRepository eventRepository = new EventMapper();
            IUserRepository userRepository = new UserMapper();
            IDayPlanRepository dayPlanRepository = new DayPlanMapper();

            DomainManager manager = new(userRepository, eventRepository, dayPlanRepository);

            new GentseFeestenApplication(manager);
        }
    }
}
