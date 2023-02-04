using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        #region Constants
        public const int NAMELENGTH = 50;
        public const int PASSWORDLENGTH = 50;
        public const int MOBILENUMBERLENGTH = 10;
        public const int ADDRESSLENGTH = 100;



        #endregion
        #region Properties
        [Key]
        public int UserID { get; set; }
        [Required]
        [StringLength(NAMELENGTH)]
        public string UserName { get; set; }
        
        [StringLength(NAMELENGTH)]
        public string? EmailAddress { get; set; }
        [StringLength(PASSWORDLENGTH)]
        public string? Password { get; set; }
        [StringLength(MOBILENUMBERLENGTH)]
        public int? MobileNo { get; set; }
        [StringLength(ADDRESSLENGTH)]
        public string? Addresss { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool ISDelete { get; set; }
        #endregion
        #region Associations 
        [InverseProperty("Users")]
        public List<ToDoTask> Tasks { get; set; }
        #endregion
    }
}
