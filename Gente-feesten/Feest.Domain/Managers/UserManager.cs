using Feest.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Managers {
    internal class UserManager {
        private readonly IUserRepository _userRepo;

        public UserManager(IUserRepository userRepo) {
            this._userRepo = userRepo;
        }
    }
}
