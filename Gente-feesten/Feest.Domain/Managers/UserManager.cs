using Feest.Domain.DTO;
using Feest.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Managers {
    public class UserManager {
        private readonly IUserRepository _userRepo;

        public UserManager(IUserRepository userRepo) {
            this._userRepo = userRepo;
        }

        public List<UserDTO> GetAllUsers() {
            return _userRepo.GetAllUsers().Select(x => new UserDTO(x.Id, x.FirstName, x.LastName, x.Budget)).OrderBy(x => x.FirstName).ToList();
        }

        public UserDTO GetUserById(int id) {
            var user = _userRepo.GetUserById(id);
            return new UserDTO(user.Id, user.FirstName, user.LastName, user.Budget);
        }

        public List<UserDTO> SearchUser(string username) {
            return _userRepo.GetUserByName(username).Select(x => new UserDTO(x.Id, x.FirstName, x.LastName, x.Budget)).OrderBy(x => x.FirstName).ToList();
        }
    }
}
