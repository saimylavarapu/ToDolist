using EFCore;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        
        public UserRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public async Task<bool> AddUser(AddUserDTO user)
        {
            try
            {
                var person = new User();
                person.UserName = user.UserName;
                person.Addresss = user.Addresss;
                person.EmailAddress = user.EmailAddress;
                person.Password = user.Password;
                person.CreatedDate = DateTime.UtcNow;
                person.ISDelete = false;
                person.IsActive= true;
                person.MobileNo=user.MobileNo;
                await _context.Users.AddAsync(person);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteUser(int ID)
        {
            try
            {
                var user= _context.Users.Where(x=>x.UserID==ID).FirstOrDefault();

                if (user != null)
                {
                    user.IsActive=false;
                    user.ISDelete = true;
                   await _context.SaveChangesAsync();

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<List<UserTaskDTO>> GetAllTaskByID(int ID)
        {
            try
            {
                var result = await _context.tasks.Where(x => !x.ISDelete && x.FKUserID == ID ).Select(x=>new UserTaskDTO
                {
                    PKTaskID=x.TaskID,
                    TaskName=x.TaskName
                }).ToListAsync();
                return result;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserDTOALL>> GetAllUsers()
        {
            try
            {

                var users = await _context.Users.Where(x => x.IsActive && !x.ISDelete).Include(y=>y.Tasks).Select(x => new UserDTOALL
                {
                    UserID = x.UserID,
                    UserName = x.UserName,
                    CreatedDate = x.CreatedDate,
                    EmailAddress = x.EmailAddress,
                    Addresss = x.Addresss,
                    MobileNo = x.MobileNo,
                    Password = x.Password,
                    IsActive = x.IsActive,
                    ISDelete = x.ISDelete,
                    Tasks=x.Tasks.ToList(),
                }).ToListAsync();
                return users;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<GetByIDDTO>> GetUserBYId(int ID)
        {
           
                var USER = await _context.Users.Where(X => X.UserID == ID).Select(X=>new GetByIDDTO
                {
                    UserName= X.UserName,
                    EmailAddress= X.EmailAddress,
                    Addresss= X.Addresss,
                    MobileNo=X.MobileNo,
                    Password=X.Password,
                    IsActive=X.IsActive,
                    ISDelete=X.ISDelete,
                    CreatedDate=X.CreatedDate,
                    
                } ).ToListAsync();
            return USER;
           
        }

        public async Task UpdateUser(UpdateUerDTO user)
        {
            var person = await _context.Users.Where(x => x.UserID == user.UserID && x.IsActive).FirstOrDefaultAsync();
            if(person != null)
            {
                person.UserName = user.UserName;
                person.EmailAddress = user.EmailAddress;
                person.Addresss = user.Addresss;
                person.MobileNo = user.MobileNo;
                person.Password = user.Password;
            
                 
               await _context.SaveChangesAsync();
            }
            else
            {
                throw new ApplicationException("User not Found");
            }
        }
    }
}
