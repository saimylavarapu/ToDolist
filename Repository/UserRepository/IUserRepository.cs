using Models.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<List<UserDTOALL>> GetAllUsers();
        Task<GetByIDDTO> GetUserBYId(int ID);
        Task UpdateUser(UpdateUerDTO user);
        Task DeleteUser(int ID);

        Task<bool> AddUser(AddUserDTO user);
    }
}
