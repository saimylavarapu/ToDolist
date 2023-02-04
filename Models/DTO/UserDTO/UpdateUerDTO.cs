using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.UserDTO
{
    public class UpdateUerDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public int? MobileNo { get; set; }
        public string? Addresss { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool ISDelete { get; set; }
    }
}
