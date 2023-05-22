﻿using Feest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Interface {
    public interface IUserRepository {

        List<User> GetAllUsers();
        User GetUserById(int id);
        List<User> GetUserByName(string username);
    }
}
